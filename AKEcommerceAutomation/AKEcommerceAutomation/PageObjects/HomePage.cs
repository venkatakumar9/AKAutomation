using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AKEcommerceAutomation.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Support.UI;

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
