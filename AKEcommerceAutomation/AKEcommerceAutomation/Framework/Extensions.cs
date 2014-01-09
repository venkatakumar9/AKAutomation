using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AKEcommerceAutomation.Framework
{
    public static class Extensions
    {
        public static bool IsElementPresent(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static void ClearAndSendKeys(this IWebElement webElement, string text)
        {
            webElement.Clear();
            webElement.SendKeys(text);
        }

        public static bool VisibleElementExists(this IWebDriver driver, By by, Int32 implicitWait)
        {
            int visibleElements = -1;
            try
            {
                driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 0));
                ReadOnlyCollection<IWebElement> elements = driver.FindElements(by);
                visibleElements = elements.Count;
                driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, implicitWait));
                return visibleElements != 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Element not found -->" + @by + " _ " + e.Message);
                return visibleElements == 0;
            }
        }

        public static void SelectDropDownByText(this IWebDriver browser, By locator, string text)
        {
            WaitFor.ElementPresent(browser, locator);
            var selectElement = new SelectElement(browser.FindElement(locator));
            selectElement.SelectByText(text);
        }
    }
}