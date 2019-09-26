
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
    public class LoginFailureScenarioSteps
    {
        private readonly ISeleniumDriver seleniumdriver;
        private readonly IWebDriver driver;
        string MemberId = "";
        string Password = "";
        //Constants
        private const string loginvalidationmsg= "login-validation-msg";
        private const string incorrect_password_message= "Your have entered incorrect password three times";

        public LoginFailureScenarioSteps(ISeleniumDriver seleniumdriver)
        {
            this.seleniumdriver = seleniumdriver;
            this.driver = seleniumdriver.WebDriver;
        }
        [Given(@"Navigate to Login page")]
        public void GivenNavigateToLoginPage()
        {

        }
        [When(@"I enter UserID and Password")]
        public void WhenIEnterUserIDAndPassword(Table data)
        {
            MemberId = data.Rows[0]["MemberId"].ToString();
            Password = data.Rows[0]["Password"].ToString();

            driver.FindElement(By.Id("UserName")).SendKeys(MemberId);
            driver.FindElement(By.Id("Password")).SendKeys(Password);
        }

        [When(@"click on Submit")]
        public void WhenClickOnSubmit()
        {
            driver.FindElement(By.Id(ControlId.Button_LoginSubmit.ToString())).Click();
        }

        [Then(@"I see error message")]
        public void ThenISeeErrorMessage()
        {
            WebDriverWait webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement searchResult = webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(loginvalidationmsg)));

            bool result = driver.FindElement(By.Id(loginvalidationmsg)).Displayed;
            Assert.That(result);
        }

        [Then(@"Check the error message")]
        public void ThenCheckTheErrorMessage(Table data)
        {
            MemberId = data.Rows[0]["MemberId"].ToString();
            Password = data.Rows[0]["Password"].ToString();

            WebDriverWait webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement searchResult = webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(loginvalidationmsg)));

            string txt = driver.FindElement(By.Id(loginvalidationmsg)).Text.ToString();

            if (!chkErrorMsgText(txt))
            {
                for (int i = 0; i < 2; i++)
                {
                    driver.FindElement(By.Id(ControlId.Textbox_UserName.ToString())).Clear();
                    driver.FindElement(By.Id(ControlId.Textbox_Password.ToString())).Clear();

                    driver.FindElement(By.Id(ControlId.Textbox_UserName.ToString())).SendKeys(MemberId);
                    driver.FindElement(By.Id(ControlId.Textbox_Password.ToString())).SendKeys(Password);
                    driver.FindElement(By.Id(ControlId.Button_LoginSubmit.ToString())).Click();

                    Thread.Sleep(5000);
                    txt = driver.FindElement(By.Id(loginvalidationmsg)).Text.ToString();

                    if (chkErrorMsgText(txt))
                        break;
                }
            }
            StringAssert.Contains(incorrect_password_message, txt);
            driver.Quit();
        }

        public bool chkErrorMsgText(string txt)
        {
            return txt.Contains(incorrect_password_message);
        }
    }
}
