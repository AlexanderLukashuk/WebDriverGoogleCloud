using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebDriverGoogleCloud
{
    public class PricingCalculatorPage
    {
        private IWebDriver webDriver;

        public PricingCalculatorPage(IWebDriver driver)
        {
            webDriver = driver;
        }

        public void SearchForCalculator()
        {
            IWebElement icon = webDriver.FindElement(By.XPath("//*[@id=\"kO001e\"]/div[2]/div[1]/div/div[2]/div[2]/div[1]/form/div/input"));
            icon.Click();

            IWebElement searchField = webDriver.FindElement(By.XPath("//*[@id=\"kO001e\"]/div[2]/div[1]/div/div[2]/div[2]/div[1]/form/div/input"));
            searchField.SendKeys("Google Cloud Platform Pricing Calculator");

            searchField.SendKeys(Keys.Enter);
        }
    }
}