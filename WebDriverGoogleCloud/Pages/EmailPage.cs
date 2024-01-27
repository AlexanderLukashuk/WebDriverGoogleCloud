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

        public string GenerateEmail()
        {
            ((IJavaScriptExecutor)WebDriver).ExecuteScript("window.open();");

            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());

            WebDriver.Navigate().GoToUrl("https://temp-mail.org/");

            IWebElement emailElement = WebDriver.FindElement(By.XPath("//*[@id=\"mail\"]"));

            string email = emailElement.Text;

            return email;
        }

        public string CheckEmail()
        {
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());

            IWebElement emailTitleLink = WebDriver.FindElement(By.XPath("//*[@id=\"tm-body\"]/main/div[1]/div/div[2]/div[2]/div/div[1]/div/div[4]/ul/li[2]/div[1]/a"));
            emailTitleLink.Click();

            IWebElement emailTextElement = WebDriver.FindElement(By.XPath("//*[@id=\"tm-body\"]/main/div[1]/div/div[2]/div[2]/div/div[1]/div/div[2]/div[3]/div/table/tbody/tr[2]/td/table/tbody/tr[2]/td[1]/h3"));
            string emailText = emailTextElement.Text;

            return emailText;
        }
    }
}