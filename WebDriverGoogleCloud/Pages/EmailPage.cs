using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebDriverGoogleCloud.Pages
{
    public class EmailPage : BasePage
    {
        public EmailPage(IWebDriver driver) : base(driver) {}

        public IWebElement EmailElement => WebDriver.FindElement(By.XPath("//*[@id=\"mail\"]"));
    }
}