using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInterviewTask.Pages
{
    public abstract class BasePage(IWebDriver driver, int timeoutInSeconds = 10)
    {
        protected IWebDriver Driver = driver;
        protected WebDriverWait Wait = new(driver, TimeSpan.FromSeconds(timeoutInSeconds));

        protected IWebElement WaitForElementVisible(By locator, string elementName)
        {
            try
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"Element '{elementName}' with locator {locator} was not visible within {timeoutInSeconds} seconds.");
            }
        }

        protected IWebElement WaitForChildElementVisible(IWebElement parentElement, By locator, string elementName)
        {
            try
            {
                return Wait.Until(driver =>
                {
                    var childElement = parentElement.FindElement(locator);
                    return childElement.Displayed ? childElement : null;
                });
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"Child element '{elementName}' with locator {locator} was not visible within {timeoutInSeconds} seconds.");
            }
        }

        protected IWebElement WaitForElementClickable(By locator,string elementName)
        {
            try
            {
                return Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"Element '{elementName}' with locator {locator} was not clickable within {timeoutInSeconds} seconds.");
            }
        }

        protected void Click(By locator, string elementName)
        {
            WaitForElementClickable(locator, elementName).Click();
        }

        protected void ClickIfVisible(By locator, string elementName)
        {
            try
            {
                var element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
                element.Click();
            }
            catch (WebDriverTimeoutException)
            {
            }
        }

        public void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}
