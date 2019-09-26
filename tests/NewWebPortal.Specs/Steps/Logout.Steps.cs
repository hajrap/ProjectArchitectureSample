using System;
using System.Configuration;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework.Internal;
using NewWebPortal.Specs.Steps.Infrastructure;
using NewWebPortal.Specs.Steps.Infrastructure.Enum;

namespace NewWebPortal.Specs
{
    [Binding]
    public class LogintoWebsiteSteps
    {
        private readonly ISeleniumDriver seleniumdriver;
        private readonly IWebDriver driver;
        public LogintoWebsiteSteps(ISeleniumDriver seleniumdriver) {
            this.seleniumdriver = seleniumdriver;
            this.driver = seleniumdriver.WebDriver;
        }

        [Given(@"Navigate to ASG Website")]
        public void GivenNavigateToASGWebsite()
        {
        }
        
        [When(@"I enter UserID and Password and click Submit")]
        public void WhenIEnterUserIDAndPasswordAndClickSubmit()
        {
            driver.FindElement(By.Id(ControlId.Textbox_UserName.ToString())).SendKeys("31034468");
            driver.FindElement(By.Id(ControlId.Textbox_Password.ToString())).SendKeys("Asg3166!");
            driver.FindElement(By.Id(ControlId.Button_LoginSubmit.ToString())).Click();
        }
        
        [Then(@"I see welcome to MyAsg page")]
        public void ThenISeeWelcomeToMyAsgPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);
            Assert.That(driver.FindElement(By.PartialLinkText(ControlId.Link_Home.ToString())).Displayed);
        }

        [When(@"I click on Logout")]
        public void WhenIClickOnLogout()
        {
            driver.FindElement(By.Id(ControlId.Button_Logout.ToString())).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Then(@"I see Home page")]
        public void ThenISeeHomePage()
        {
            Assert.That(driver.FindElement(By.LinkText(ControlId.Link_GoToMyAsg.ToString())).Displayed);
    
        }
    }
}
