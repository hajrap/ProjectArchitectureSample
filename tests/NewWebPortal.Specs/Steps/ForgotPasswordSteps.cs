using NewWebPortal.Specs.Steps.Infrastructure;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace NewWebPortal.Specs
{
    [Binding]
    public class ForgotPassSteps
    {
        private readonly ISeleniumDriver seleniumdriver;
        private readonly IWebDriver driver;
        string memberId = "";
        //Constant for Xpath
        private const string request_password_link = ".//*[@id='frmAsgPortalLogin']/div[1]/div[3]/div[1]/a[1]";
        private const string div_success_text = ".//*[@id='divSuccess']/div[1]/p[1]";
        private const string div_success_close = ".//*[@id='divSuccess']/div[3]/p[1]/a[1]";
        private const string username_webid = "UsernameWebID";
        private const string btn_request_password = "btnRequestPassword";
        //Constant for message
        private const string success_text = "We have just sent you an email";

        public ForgotPassSteps(ISeleniumDriver seleniumdriver)
        {
            this.seleniumdriver = seleniumdriver;
            this.driver = seleniumdriver.WebDriver;
        }
        public ForgotPassSteps()
        {
            driver = new ChromeDriver();
            driver.Url = Convert.ToString(ConfigurationManager.AppSettings["ApplicationUrl"]);
        }

        [When(@"I click on Forgot Password link")]
        public void WhenIClickOnForgotPasswordLink()
        {
            driver.FindElement(By.XPath(request_password_link)).Click();
        }

        [When(@"In the pop-up I have entered member number (.*)")]
        public void WhenInThePop_UpIHaveEnteredMemberNumber(string memberId)
        {
            this.memberId = memberId;
            WebDriverWait webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement searchResult = webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(username_webid)));
            driver.FindElement(By.Id(username_webid)).SendKeys(memberId);
        }

        [When(@"I click on Request Password")]
        public void WhenIClickOnRequestPassword()
        {
            driver.FindElement(By.Id(btn_request_password)).Click();
        }

        [Then(@"I see success message for Forgot Password")]
        public void ThenISeeSuccessMessageForForgotPassword()
        {
            WebDriverWait webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            IWebElement searchResult = webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(div_success_text)));

            var result = driver.FindElement(By.XPath(div_success_text)).Text.ToString().Contains(success_text);
            Assert.That(result);
            driver.FindElement(By.XPath(div_success_close)).Click();
       
        }
    }
}

