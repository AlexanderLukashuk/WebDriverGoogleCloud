using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using WebDriverGoogleCloud.Driver;

namespace WebDriverGoogleCloud.Test
{
    public class CalculateEstimateTest
    {
        private Steps.Steps steps = new Steps.Steps();

        private const string SEARCH_STRING = "Google Cloud Platform Pricing Calculator";

        [SetUp]
        public void SetUp()
        {
            steps.InitBrowser();
        }

        [TearDown]
        [Obsolete]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                CaptureScrenshot();
            }
            steps.CloseBrowser();
        }

        [Test]
        public void CalcutateEstimate()
        {
            steps.SearchGoogleCloud(SEARCH_STRING);
            steps.OpenSearchResult();
            steps.CalculateEstimate();
            steps.GenerateEmail();
            string emailText = steps.SendEmail();

            Assert.AreEqual("Total Estimated Monthly Cost", emailText);
        }

        [Obsolete]
        public static void CaptureScrenshot()
        {
            var screenshot = ((ITakesScreenshot)WebDriverManager.Driver).GetScreenshot();
            var screenshotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            Console.WriteLine($"Screenshot saved: {screenshotPath}");
        }
    }
}