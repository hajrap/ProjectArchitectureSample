using NewWebPortal.Specs.Steps.Infrastructure;
using NewWebPortal.Specs.Steps.Infrastructure.Enum;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace NewWebPortal.Specs.Steps
{
    [Binding]
    public class ForgotUsernameSteps
    {
        private readonly ISeleniumDriver seleniumdriver;
        private readonly IWebDriver driver;
        //Constant for Xpath
        private const string request_username_link= ".//*[@id='frmAsgPortalLogin']/div[1]/div[3]/div[1]/a[2]";
        private const string div_success_text = ".//*[@id='divSuccess']/div[1]/p[1]";
        private const string div_success_close = ".//*[@id='divSuccess']/div[3]/p[1]/a[1]";
        private const string forgot_username_msg="forgotUsername-msg";
        //Constant for message
        private const string success = "SUCCESS";
        private const string success_text = "We have just sent you an email";
        private const string email_not_found = "Email not found";

        public ForgotUsernameSteps(ISeleniumDriver seleniumdriver)
        {
            this.seleniumdriver = seleniumdriver;
            this.driver = seleniumdriver.WebDriver;
        }
        [Given(@"Open Login page")]
        public void GivenOpenLoginPage()
        {
        }

        [When(@"I click on Forgot your username link")]
        public void WhenIClickOnForgotYourUsernameLink()
        {
            driver.FindElement(By.XPath(request_username_link)).Click();
        }

        [When(@"In the pop-up I have entered email (.*)")]
        public void WhenInThePop_UpIHaveEnteredEmailId(string scenarion, Table tbl)
        {
            WebDriverWait webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement searchResult = webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("EmailAddress")));
            if (scenarion.Equals(success,StringComparison.OrdinalIgnoreCase))
            {
                driver.FindElement(By.Id(ControlId.Textbox_EmailAddress.ToString())).SendKeys(tbl.Rows[0][0].ToString());
            }
            else
            {
                driver.FindElement(By.Id(ControlId.Textbox_EmailAddress.ToString())).SendKeys(tbl.Rows[1][0].ToString());
            }
        }

        [When(@"I click on Request Username")]
        public void WhenIClickOnRequestUsername()
        {
            driver.FindElement(By.Id(ControlId.Button_RequestUsername.ToString())).Click();
        }

        [Then(@"I see success message")]
        public void ThenISeeSuccessMessage()
        {
            WebDriverWait webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement searchResult = webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                                    .ElementIsVisible(By.XPath("//*[contains(text(), '"+ success_text + "')]")));

            var result = driver.FindElement(By.XPath(div_success_text)).Text.ToString().Contains(success_text);
            Assert.That(result);
            driver.FindElement(By.XPath(div_success_close)).Click();
            driver.Quit();
        }

        [Then(@"I see wrong email-Id message")]
        public void ThenISeeWrongEmail_IdMessage()
        {
            WebDriverWait webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement searchResult = webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                                    .ElementIsVisible(By.Id(forgot_username_msg)));

            var result = driver.FindElement(By.Id(forgot_username_msg)).Text.ToString().Contains(email_not_found);
            Assert.That(result);
          
        }
    }
}
