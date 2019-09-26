using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewWebPortal.Specs.Steps.Infrastructure
{
    public class SeleniumDriver : ISeleniumDriver
    {
        public SeleniumDriver() {
            WebDriver=new  ChromeDriver();
        }
        public IWebDriver WebDriver { get; private set; }
    }
}