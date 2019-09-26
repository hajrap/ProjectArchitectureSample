using Autofac;
using NewWebPortal.Specs.Dependencies;
using NewWebPortal.Specs.Steps.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NewWebPortal.Specs.Hooks
{
    [Binding]
    public sealed class WebDriverHook
    {
        private ISeleniumDriver seleniumdriver;
        private  IWebDriver driver;

        public WebDriverHook(ISeleniumDriver seleniumdriver)
        {
            this.seleniumdriver = seleniumdriver;
            this.driver = seleniumdriver.WebDriver;
        }
        [BeforeTestRun]
        public static void RunBeforeAllTests()
        {

        }
        [BeforeFeature]
        public static void BeforeFeature()
        {

        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = seleniumdriver.WebDriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationManager.AppSettings["Application_ImplicitWait_Timeout"]));
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationManager.AppSettings["Application_PageLoad_Timeout"]));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Convert.ToString(ConfigurationManager.AppSettings["ApplicationUrl"]));

        }
        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
