using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public void TearDown()
        {
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
    }
}