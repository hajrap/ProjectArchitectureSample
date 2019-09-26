using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace NewWebPortal.Specs.CodeFile
{
    [Binding]
    public class BrowsingSteps
    {
        IWebDriver driver;

        [Given(@"Url homelink")]
        public void GivenUrlHomelink()
        {
            driver = new ChromeDriver();
            driver.Url = "http://staging.asg.com.au/login?ReturnUrl=http://staging.asg.com.au/myasg-portal";// Convert.ToString(ConfigurationManager.AppSettings["RootUrl"]);
        }

        [When(@"I navigate to /www\.asg\.com\.au")]
        public void WhenINavigateToWww_Asg_Com_Au()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("31034468");
            driver.FindElement(By.Id("Password")).SendKeys("Asg3166!");
            driver.FindElement(By.Id("btnLoginSubmit")).Click();
        }


        [Then(@"I should see home page")]
        public void ThenIShouldSeeHomePage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);
            Assert.That(driver.FindElement(By.LinkText("MY ACCOUNT")).Displayed);
            driver.Quit();
        }
    }
}