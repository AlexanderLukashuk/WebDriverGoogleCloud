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

        public void OpenSearchResult(string resultText)
        {
            // IWebElement searchResultLink = webDriver.FindElement(By.XPath("//*[@id=\"___gcse_0\"]/div/div/div/div[5]/div[2]/div/div/div[1]/div[1]/div/div[1]/div/a"));
            IWebElement searchResultLink = webDriver.FindElement(By.XPath($"//a[contains(text(), '{resultText}')]"));
            searchResultLink.Click();
        }

        public void CalculateEstimate()
        {
            IWebElement computeEngine = webDriver.FindElement(By.XPath("//*[@id=\"tab-item-1\"]/div[1]"));
            computeEngine.Click();

            IWebElement instanceNumber = webDriver.FindElement(By.XPath("//*[@id=\"input_744\"]"));
            instanceNumber.SendKeys("4");

            IWebElement operatingSystem = webDriver.FindElement(By.XPath("//*[@id=\"select_value_label_736\"]")); // id: select_value_label_736
            operatingSystem.Click();

            IWebElement ubuntuPro = webDriver.FindElement(By.XPath("//*[@id=\"select_option_746\"]")); // id: select_option_746
            ubuntuPro.Click();

            IWebElement provisioningModel = webDriver.FindElement(By.XPath("//*[@id=\"select_value_label_737\"]"));
            provisioningModel.Click();

            IWebElement regularProvisioningModel = webDriver.FindElement(By.XPath("//*[@id=\"select_option_759\"]"));
            regularProvisioningModel.Click();

            IWebElement machineFamily = webDriver.FindElement(By.XPath("//*[@id=\"select_value_label_737\"]"));
            machineFamily.Click();

            IWebElement generealPurposeMachineFamily = webDriver.FindElement(By.XPath("//*[@id=\"select_option_763\"]"));
            generealPurposeMachineFamily.Click();

            IWebElement series = webDriver.FindElement(By.XPath("//*[@id=\"select_value_label_739\"]"));
            series.Click();

            IWebElement seriesN1 = webDriver.FindElement(By.XPath("//*[@id=\"select_option_868\"]"));
            seriesN1.Click();

            IWebElement machineType = webDriver.FindElement(By.XPath("//*[@id=\"select_value_label_740\"]"));
            machineType.Click();

            IWebElement machineTypeN1Standard8 = webDriver.FindElement(By.XPath("//*[@id=\"select_option_1118\"]"));
            machineTypeN1Standard8.Click();

            IWebElement addGPUCheckbox = webDriver.FindElement(By.XPath("//*[@id=\"mainForm\"]/div[2]/div/md-card/md-card-content/div/div[1]/form/div[13]/div[1]/md-input-container/md-checkbox/div[1]"));
            addGPUCheckbox.Click();

            IWebElement GpuType = webDriver.FindElement(By.XPath("//*[@id=\"select_1163\"]"));
            GpuType.Click();

            IWebElement nvidiaTeslaP100 = webDriver.FindElement(By.XPath("//*[@id=\"select_option_1168\"]"));
            nvidiaTeslaP100.Click();

            IWebElement gpuNumber = webDriver.FindElement(By.XPath("//*[@id=\"select_value_label_1153\"]"));
            gpuNumber.Click();

            IWebElement gpuNumber1 = webDriver.FindElement(By.XPath("//*[@id=\"select_option_1173\"]"));
            gpuNumber1.Click();

            IWebElement localSsd = webDriver.FindElement(By.XPath("//*[@id=\"select_value_label_1112\"]"));
            localSsd.Click();

            IWebElement localSsd_2x375 = webDriver.FindElement(By.XPath("//*[@id=\"select_option_1139\"]"));
            localSsd_2x375.Click();

            IWebElement datacenterLocation = webDriver.FindElement(By.XPath("//*[@id=\"select_value_label_742\"]"));
            datacenterLocation.Click();

            IWebElement datacenterLocationFrankfurt = webDriver.FindElement(By.XPath("//*[@id=\"select_option_268\"]"));
            datacenterLocationFrankfurt.Click();

            IWebElement commitedUsage = webDriver.FindElement(By.XPath("//*[@id=\"select_value_label_99\"]"));
            commitedUsage.Click();

            IWebElement commitedUsageOneYear = webDriver.FindElement(By.XPath("//*[@id=\"select_option_138\"]"));
            commitedUsageOneYear.Click();

            IWebElement addToEstimateButton = webDriver.FindElement(By.XPath("//*[@id=\"mainForm\"]/div[2]/div/md-card/md-card-content/div/div[1]/form/div[20]/button"));
            addToEstimateButton.Click();
        }
    }
}