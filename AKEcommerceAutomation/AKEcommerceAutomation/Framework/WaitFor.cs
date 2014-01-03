using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gherkin.lexer.i18n;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AKEcommerceAutomation.Framework
{
    public static class WaitFor
    {
        public static void ElementPresent(IWebDriver browser, By locator)
        {
            Wait(browser, locator, TimeSpan.FromSeconds(100));
        }

        public static void ElementPresent(IWebDriver browser, By locator, TimeSpan timeSpan)
        {
            Wait(browser, locator, timeSpan);
        }

        private static void Wait(IWebDriver browser, By locator, TimeSpan timespan)
        {
            IWait<IWebDriver> wait = new WebDriverWait(browser, timespan);
            wait.Until(d => d.FindElement(locator));
        }

        public static void WaitForPageToLoad(this IWebDriver driver)
        {
            TimeSpan timeout = new TimeSpan(0, 0, 100);
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            IJavaScriptExecutor javaScript = driver as IJavaScriptExecutor;
            if (javaScript == null)
                throw new ArgumentException("driver", "driver must support javascript execution");

            wait.Until((d) =>
            {
                try
                {
                    string readyState =
                        javaScript.ExecuteScript("if (document.readyState) return document.readystate;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    //Window is no lonfer available
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    //Browser is no longer available
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

    }
}
