using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverGoogleCloud.Test
{
    public class PricingCalculatorTest
    {
        private IWebDriver webDriver;

        private PricingCalculatorPage pricingCalculatorPage;

        private string searchResultString = "Google Cloud Pricing Calculator";

        [SetUp]
        public void SetUp()
        {
            webDriver = new ChromeDriver();
            pricingCalculatorPage = new PricingCalculatorPage(webDriver);
        }

        [Test]
        public void CalculateCloudCost_ReturnTextAboutCostFromEmail()
        {
            webDriver.Navigate().GoToUrl("https://cloud.google.com/");

            string email = pricingCalculatorPage.Calculate(searchResultString);

            Assert.AreEqual("Total Estimated Monthly Cost", email);
        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
        }
    }
}