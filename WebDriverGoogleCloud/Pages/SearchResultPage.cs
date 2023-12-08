using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebDriverGoogleCloud.Pages
{
    public class SearchResultPage : BasePage
    {
        public SearchResultPage(IWebDriver driver) : base(driver) {}

        public IWebElement SearchResultLink => WebDriver.FindElement(By.XPath("//*[@id=\"___gcse_0\"]/div/div/div/div[5]/div[2]/div/div/div[1]/div[1]/div/div[1]/div/a"));

        public void OpenSearchResult()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(driver => driver.FindElement(By.XPath("//*[@id=\"___gcse_0\"]/div/div/div/div[5]")).Displayed);
            SearchResultLink.Click();
        }
    }
}