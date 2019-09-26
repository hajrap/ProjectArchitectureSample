using System;
using System.Configuration;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework.Internal;
using NewWebPortal.Specs.Steps.Infrastructure.Enum;
using NewWebPortal.Specs.Steps.Infrastructure;

namespace NewWebPortal.Specs.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly ISeleniumDriver seleniumdriver;
        private readonly IWebDriver driver;

        public LoginSteps(ISeleniumDriver seleniumdriver) {

            this.seleniumdriver = seleniumdriver;
            this.driver = seleniumdriver.WebDriver;
        }

        [Given(@"Navigate to  Website")]
        public void GivenNavigateToASGWebsite()
        {
        }

        [When(@"I enter userID as (.*)")]
        public void WhenIEnterUserIDAs(string MemberId)
        {
            driver.FindElement(By.Id(ControlId.Textbox_UserName.ToString())).SendKeys(MemberId);
        }

        [When(@"I enter password as (.*)")]
        public void WhenIEnterPasswordAs(string Password)
        {
            driver.FindElement(By.Id(ControlId.Textbox_Password.ToString())).SendKeys(Password);
        }

        [When(@"I click Submit")]
        public void WhenIClickSubmit()
        {
            driver.FindElement(By.Id(ControlId.Button_LoginSubmit.ToString())).Click();
        }

        [Then(@"I see MyAsg page")]
        public void ThenISeeMyAsgPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);
            Assert.That(driver.FindElement(By.PartialLinkText(ControlId.Link_Home.ToString())).Displayed);
        }

    }
}
