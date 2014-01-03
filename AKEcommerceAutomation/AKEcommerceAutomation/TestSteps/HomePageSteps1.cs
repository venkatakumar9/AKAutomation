using System;
using AKEcommerceAutomation.Framework;
using AKEcommerceAutomation.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AKEcommerceAutomation.TestSteps
{
    [Binding]
    public class HomePageSteps1 : SeleniumTestBase

    {
        public HomePage homePage;

        //Homepage
        [Given(@"I navigate to the homepage")]
        public void GivenINavigateToTheHomepage()
        {
            Current().Navigate().GoToUrl(Url);
            homePage = new HomePage(driver);
            ScenarioContext.Current.Set(homePage);
            //driver.Close();
        }

        [Then(@"I should be in the Homepage")]
        public void ThenIShouldBeInTheHomepage()
        {
            driver.PageSource.Contains("logo-big");
            driver.Close();
        }

        //Main-Navigation
        [Given(@"I navigate to homepage")]
        public void User_Navigates_To_Homepage()
        {
            Current().Navigate().GoToUrl(Url);
            homePage = new HomePage(driver);
            ScenarioContext.Current.Set(homePage);
        }

        [Then(@"The Main Navigation appears")]
        public void Main_Navigation()
        {
            Assert.AreEqual(5, homePage.TopNavLinks.Count);
            Assert.AreEqual("Destinations", homePage.TopNavLinks[0].LinkText);
            Assert.AreEqual("Journeys", homePage.TopNavLinks[1].LinkText);
            Assert.AreEqual("BeInspired", homePage.TopNavLinks[2].LinkText);
            Assert.AreEqual("When To Go", homePage.TopNavLinks[3].LinkText);
            Assert.AreEqual("Search", homePage.TopNavLinks[4].LinkText);
            Console.WriteLine("All the Main Navigation links are Appearing");
            driver.Close();
        }
    }
}