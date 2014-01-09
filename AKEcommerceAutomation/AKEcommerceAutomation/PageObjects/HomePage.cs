using AKEcommerceAutomation.Framework;
using OpenQA.Selenium;

namespace AKEcommerceAutomation.PageObjects
{
    public class HomePage : BasePage
    {
        //Actions builder = new Actions(driver);
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public DestinationsPage GetDestinationsPage()
        {
            _driver.FindElement(By.XPath("//*[@id='destinations-hub']")).Click();
            _driver.WaitForPageToLoad();
            return new DestinationsPage(_driver);
        }
    }
}