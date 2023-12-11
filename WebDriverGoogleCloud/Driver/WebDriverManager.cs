using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace WebDriverGoogleCloud.Driver
{
    public class WebDriverManager
    {
        private static IWebDriver webDriver = null!;
        
        public static IConfiguration configuration;

        static WebDriverManager()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            configuration = builder.Build();
        }

        public static IWebDriver Driver
        {
            get
            {
                if (webDriver == null)
                {
                    InitializeDriver();
                }
                return webDriver!;
            }
        }

        public static void InitializeDriver()
        {
            string selectedBrowser = configuration["WebDriver:SelectedBrowser"]!;
            var browserOptions = configuration.GetSection($"WebDriver:Browsers:{selectedBrowser}");

            if (browserOptions == null)
            {
                throw new InvalidOperationException($"Browser configuration for '{selectedBrowser}' not found in appsettings.josn");
            }

            string browserType = browserOptions["Type"]!;

            switch(browserType.ToLower())
            {
                case "chrome":
                    InitializeChromeDriver(browserOptions);
                    break;
                case "firefox":
                    InitializeFirefoxDriver(browserOptions);
                    break;
                default:
                    throw new ArgumentException("Invalid browser type '{browserType}' specified in appsettings.json.");
            }

            webDriver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            webDriver.Manage().Window.Maximize();
        }

        private static void InitializeChromeDriver(IConfigurationSection options)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            ConfigureDriverOptions(options, chromeOptions);
            webDriver = new ChromeDriver(chromeOptions);
        }

        private static void InitializeFirefoxDriver(IConfigurationSection options)
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            ConfigureDriverOptions(options, firefoxOptions);
            webDriver = new FirefoxDriver(firefoxOptions);
        }

        private static void ConfigureDriverOptions(IConfigurationSection options, DriverOptions driverOptions)
        {
            foreach (var option in options.GetSection("Options").GetChildren())
            {
                string oprionName = option.Key;
                string optionValue = option.Value!;
                driverOptions.AddAdditionalOption(oprionName, optionValue);
            }
        }

        public static void QuitDriver()
        {
            if (webDriver != null)
            {
                webDriver.Quit();
                webDriver = null!;
            }
        }
    }
}