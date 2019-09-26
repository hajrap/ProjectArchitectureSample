using NewWebPortal.Specs.Steps.Infrastructure;
using NewWebPortal.Specs.Steps.Infrastructure.Enum;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace NewWebPortal.Specs.Steps
{
    [Binding]
    public class RemeberMeAndCancelSteps
    {
        private readonly ISeleniumDriver seleniumdriver;
        private readonly IWebDriver driver;
        string memberId = "";
        string password = "";

        public RemeberMeAndCancelSteps(ISeleniumDriver seleniumdriver)
        {
            this.seleniumdriver = seleniumdriver;
            this.driver = seleniumdriver.WebDriver;
        }

        [When(@"enter UserID and Password")]
        public void WhenEnterUserIDAndPassword(Table tbl)
        {
            memberId = tbl.Rows[0][0].ToString();
            password = tbl.Rows[0][1].ToString();

            driver.FindElement(By.Id(ControlId.Textbox_UserName.ToString())).SendKeys(memberId);
            driver.FindElement(By.Id(ControlId.Textbox_Password.ToString())).SendKeys(password);
        }

        [When(@"I checked Remeber me checkbox")]
        public void WhenICheckedRemeberMeCheckbox()
        {
            if (!driver.FindElement(By.Id(ControlId.CheckBox_RememberMe.ToString())).Selected)
            {
                driver.FindElement(By.Id(ControlId.CheckBox_RememberMe.ToString())).Click();
            }
        }

        [When(@"click Submit button")]
        public void WhenClickSubmitButton()
        {
            driver.FindElement(By.Id(ControlId.Button_LoginSubmit.ToString())).Click();
        }

        [When(@"Click on Logout button")]
        public void WhenClickOnLogoutButton()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            driver.FindElement(By.Id(ControlId.Button_Logout.ToString())).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.That(driver.FindElement(By.LinkText(ControlId.Link_GoToMyAsg.ToString())).Displayed);
        }

        [When(@"Go to Login page")]
        public void WhenGoToLoginPage()
        {
            driver.Url = Convert.ToString(ConfigurationManager.AppSettings["ApplicationUrl"]);
        }

        [Then(@"check UserID and Password are same")]
        public void ThenCheckUserIDAndPasswordAreSame()
        {
            WebDriverWait webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement searchResult = webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(ControlId.Button_LoginSubmit.ToString())));

            Assert.AreEqual(memberId, driver.FindElement(By.Id(ControlId.Textbox_UserName.ToString())).GetAttribute("value").ToString());
            Assert.AreEqual(password, driver.FindElement(By.Id(ControlId.Textbox_Password.ToString())).GetAttribute("value").ToString());
     
        }

        [When(@"I click on cancel button")]
        public void WhenIClickOnCancelButton()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            driver.FindElement(By.LinkText(ControlId.Link_cancel.ToString())).Click();
        }

        [Then(@"I see home page")]
        public void ThenISeeHomePage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.That(driver.FindElement(By.LinkText(ControlId.Link_GoToMyAsg.ToString())).Displayed);
        }
    }
}
