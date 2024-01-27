using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebDriverGoogleCloud.Pages
{
    public class MainPage : BasePage
    {
        private const string BASE_URL = "https://cloud.google.com/";

        public MainPage(IWebDriver driver) : base(driver) {}

        public IWebElement SearchIcon => WebDriver.FindElement(By.XPath("//*[@id=\"kO001e\"]/div[2]/div[1]/div/div[2]/div[2]/div[1]/form/div/input"));

        public IWebElement SearchField => WebDriver.FindElement(By.XPath("//*[@id=\"kO001e\"]/div[2]/div[1]/div/div[2]/div[2]/div[1]/form/div/input"));

        public void Search(string searchString)
        {
            SearchIcon.Click();

            SearchField.SendKeys(searchString);

            SearchField.SendKeys(Keys.Enter);
        }

        public void OpenPage()
        {
            WebDriver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Google cloud main opened");
        }
    }
}