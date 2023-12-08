using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebDriverGoogleCloud.Pages
{
    public class BasePage
    {
        protected IWebDriver WebDriver;

        public BasePage(IWebDriver driver)
        {
            WebDriver = driver;
        }
    }
}