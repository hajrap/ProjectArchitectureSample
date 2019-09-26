using OpenQA.Selenium;

namespace NewWebPortal.Specs.Steps.Infrastructure
{
    public interface ISeleniumDriver
    {
        IWebDriver WebDriver { get; }
    }
}