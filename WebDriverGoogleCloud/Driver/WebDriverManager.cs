using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            webDriver = new ChromeDriver();
            webDriver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            webDriver.Manage().Window.Maximize();
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