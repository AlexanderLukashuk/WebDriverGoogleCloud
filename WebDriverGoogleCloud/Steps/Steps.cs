using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WebDriverGoogleCloud.Driver;
using WebDriverGoogleCloud.Pages;

namespace WebDriverGoogleCloud.Steps
{
    public class Steps
    {
        IWebDriver webDriver = null!;

        MainPage mainPage = null!;

        SearchResultPage searchResultPage = null!;

        CalculatorPage calculatorPage = null!;

        EmailPage emailPage = null!;

        public void InitBrowser()
        {
            webDriver = WebDriverManager.Driver;
            mainPage = new MainPage(webDriver);
            searchResultPage = new SearchResultPage(webDriver);
            calculatorPage = new CalculatorPage(webDriver);
            emailPage = new EmailPage(webDriver);
        }

        public void CloseBrowser()
        {
            WebDriverManager.QuitDriver();
        }

        public void SearchGoogleCloud(string searchText)
        {
            mainPage.OpenPage();
            mainPage.Search(searchText);
        }

        public void OpenSearchResult()
        {
            searchResultPage.OpenSearchResult();
        }

        public void CalculateEstimate()
        {
            calculatorPage.CalculateEstimate();
        }

        public void GenerateEmail()
        {
            emailPage.GenerateEmail();
        }

        public string SendEmail()
        {
            calculatorPage.SendEmail();
            string textFromEmail = emailPage.CheckEmail();

            return textFromEmail;
        }
    }
}