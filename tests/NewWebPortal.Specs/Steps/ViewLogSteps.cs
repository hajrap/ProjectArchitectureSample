using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Configuration;
using OpenQA.Selenium.Support.UI;

namespace NewWebPortal.Specs.Steps
{
    [Binding]
    public class ViewLogSteps
    {
        IWebDriver driver;

        private const string LoggingTableData = ".//*/tbody[@id=\"loggDataTable\"]/tr[1]/td[1]";
        //private const string ErrorLevelDropDown = ".//*[@id=\"myForm\"]/div[1]/div[3]/div[1]/div[1]/button";
        private const string ErrorLevelDropDown = ".//*/button[@data-id=\"errorLevel\"]";
        private const string LevelError = ".//*[@id=\"myForm\"]/div[1]/div[3]/div[1]/div[1]/div[1]/ul[1]/li[4]";
        private const string LevelInfo = ".//*[@id=\"myForm\"]/div[1]/div[3]/div[1]/div[1]/div[1]/ul[1]/li[5]";

        [Given(@"I have open View log page")]
        public void GivenIHaveOpenViewLogPage()
        {
            driver = new ChromeDriver();
            driver.Url = Convert.ToString(ConfigurationManager.AppSettings["LoggingModule"]);
        }
        
        [Given(@"I have set start date as ""(.*)""")]
        public void GivenIHaveSetStartDateAs(string p0)
        {
            driver.FindElement(By.Id("startDate")).Clear();
            driver.FindElement(By.Id("startDate")).SendKeys(p0);
        }
        
        [Given(@"I have set end date as ""(.*)""")]
        public void GivenIHaveSetEndDateAs(string p0)
        {
            driver.FindElement(By.Id("endDate")).Clear();
            driver.FindElement(By.Id("endDate")).SendKeys(p0);
        }
        
        [Given(@"I click on search button")]
        public void GivenIClickOnSearchButton()
        {
            driver.FindElement(By.TagName("body")).Click();
            driver.FindElement(By.Id("btnSearch")).Click();
        }
        
        [Given(@"I have set level as ""(.*)""")]
        public void GivenIHaveSetLevelAs(string p0)
        {
            driver.FindElement(By.XPath(ErrorLevelDropDown)).Click();
            driver.FindElement(By.XPath(LevelError)).Click();
            driver.FindElement(By.XPath(LevelInfo)).Click();
            driver.FindElement(By.XPath(ErrorLevelDropDown)).Click();
        }
        
        [Given(@"I have set user id as ""(.*)""")]
        public void GivenIHaveSetUserIdAs(int p0)
        {
            driver.FindElement(By.Id("userId")).SendKeys(p0.ToString());
        }
        
        [Then(@"I see latest error log detail table")]
        public void ThenISeeLatestErrorLogDetailTable()
        {
            WebDriverWait webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement searchResult = webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                                    .ElementIsVisible(By.Id("loggDataTable")));

            var abc = driver.FindElement(By.XPath(LoggingTableData)).Text.ToString();
            Assert.That(!string.IsNullOrEmpty(abc));
        }
        
        [Then(@"I see search result")]
        public void ThenISeeSearchResult()
        {
            WebDriverWait webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement searchResult = webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                                    .ElementIsVisible(By.Id("loggDataTable")));

            var abc = driver.FindElement(By.XPath(LoggingTableData)).Text.ToString();
            Assert.That(!string.IsNullOrEmpty(abc));
        }
    }
}
