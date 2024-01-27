using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebDriverGoogleCloud.Pages
{
    public class CalculatorPage : BasePage
    {
        public CalculatorPage(IWebDriver driver) : base(driver) {}

        public EmailPage EmailPage => new EmailPage(WebDriver);

        public IWebElement NumberOfInstancesInput => WebDriver.FindElement(By.Id("input_101"));

        public IWebElement OperatingSystemInput => WebDriver.FindElement(By.XPath("//*[@id=\"select_value_label_736\"]"));

        public IWebElement OperatingSystemUbuntuPro => WebDriver.FindElement(By.XPath("//*[@id=\"select_option_746\"]"));

        public IWebElement ProvisioningModelInput => WebDriver.FindElement(By.XPath("//*[@id=\"select_value_label_737\"]"));

        public IWebElement ProvisioningModelRegular => WebDriver.FindElement(By.XPath("//*[@id=\"select_option_759\"]"));

        public IWebElement MachineFamilyInput => WebDriver.FindElement(By.XPath("//*[@id=\"select_value_label_737\"]"));

        public IWebElement MachineFamilyGeneralPurpose => WebDriver.FindElement(By.XPath("//*[@id=\"select_option_763\"]"));

        public IWebElement SeriesInput => WebDriver.FindElement(By.XPath("//*[@id=\"select_value_label_739\"]"));

        public IWebElement SeriesN1 => WebDriver.FindElement(By.XPath("//*[@id=\"select_option_868\"]"));

        public IWebElement MachineTypeInput => WebDriver.FindElement(By.XPath("//*[@id=\"select_value_label_740\"]"));

        public IWebElement MachineTypeN1Standard8 => WebDriver.FindElement(By.XPath("//*[@id=\"select_option_1118\"]"));

        public IWebElement AddGpuCheckBox => WebDriver.FindElement(By.XPath("//*[@id=\"mainForm\"]/div[2]/div/md-card/md-card-content/div/div[1]/form/div[13]/div[1]/md-input-container/md-checkbox/div[1]"));

        public IWebElement GpuTypeInput => WebDriver.FindElement(By.XPath("//*[@id=\"select_1163\"]"));

        public IWebElement GpuTypeNvidiaTeslaP100 => WebDriver.FindElement(By.XPath("//*[@id=\"select_option_1168\"]"));

        public IWebElement GpuTypeGpuNumberInput => WebDriver.FindElement(By.XPath("//*[@id=\"select_value_label_1153\"]"));

        public IWebElement GpuTypeGpuNumber1 => WebDriver.FindElement(By.XPath("//*[@id=\"select_option_1173\"]"));

        public IWebElement LocalSsdInput => WebDriver.FindElement(By.XPath("//*[@id=\"select_value_label_1112\"]"));

        public IWebElement LocalSsd_2x375 => WebDriver.FindElement(By.XPath("//*[@id=\"select_option_1139\"]"));

        public IWebElement DatacenterLocationInput => WebDriver.FindElement(By.XPath("//*[@id=\"select_value_label_742\"]"));

        public IWebElement DatacenterLocationFrankfurt => WebDriver.FindElement(By.XPath("//*[@id=\"select_option_268\"]"));

        public IWebElement CommitedUsageInput => WebDriver.FindElement(By.XPath("//*[@id=\"select_value_label_99\"]"));

        public IWebElement CommitedUsageOneYear => WebDriver.FindElement(By.XPath("//*[@id=\"select_option_138\"]"));

        public IWebElement AddToEstimateButton => WebDriver.FindElement(By.XPath("//*[@id=\"mainForm\"]/div[2]/div/md-card/md-card-content/div/div[1]/form/div[20]/button"));

        public void CalculateEstimate()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(driver => driver.FindElement(By.XPath("//*[@id=\"mainForm\"]/div[2]/div/md-card/md-card-content/div/div[1]/form/h2")).Displayed);
            NumberOfInstancesInput.SendKeys("4");

            OperatingSystemInput.Click();
            OperatingSystemUbuntuPro.Click();

            ProvisioningModelInput.Click();
            ProvisioningModelRegular.Click();

            MachineFamilyInput.Click();
            MachineFamilyGeneralPurpose.Click();

            SeriesInput.Click();
            SeriesN1.Click();

            MachineTypeInput.Click();
            MachineTypeN1Standard8.Click();

            AddGpuCheckBox.Click();

            GpuTypeInput.Click();
            GpuTypeNvidiaTeslaP100.Click();

            GpuTypeGpuNumberInput.Click();
            GpuTypeGpuNumber1.Click();

            LocalSsdInput.Click();
            LocalSsd_2x375.Click();

            DatacenterLocationInput.Click();
            DatacenterLocationFrankfurt.Click();

            CommitedUsageInput.Click();
            CommitedUsageOneYear.Click();

            AddToEstimateButton.Click();
        }

        public void SendEmail()
        {
            string email = EmailPage.GenerateEmail();

            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());

            IWebElement emailInput = WebDriver.FindElement(By.XPath("//*[@id=\"input_591\"]"));
            emailInput.Clear();
            emailInput.SendKeys(email);

            IWebElement sendEmailButton = WebDriver.FindElement(By.XPath("//*[@id=\"dialogContent_597\"]/form/md-dialog-actions/button[2]"));
            sendEmailButton.Click();
        }
    }
}