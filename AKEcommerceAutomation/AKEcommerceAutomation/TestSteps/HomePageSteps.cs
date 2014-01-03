//using System;
//using AKEcommerceAutomation.Framework;
//using AKEcommerceAutomation.PageObjects;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Core;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Interactions;
//using TechTalk.SpecFlow;

//namespace AKEcommerceAutomation.TestSteps
//{
//    [Binding]
//    public class HomePageSteps : SeleniumTestBase
//    {
//        public HomePage homePage;

//        [Given(@"I navigate to the Homepage")]
//        public void GivenINavigateToTheHomepage()
//        {
//            Current().Navigate().GoToUrl(Url);
//            homePage = new HomePage(driver);
//            ScenarioContext.Current.Set(homePage);
//        }

        
//        [Then(@"the header links in homepage has (.*) elements")]
//        public void ThenHeaderLinksInHomePage_displayed()
//        {
//            Assert.AreEqual(5, homePage.subnavigationlinksinhomepage.Count);
//            Assert.AreEqual("Destinations", homePage.subnavigationlinksinhomepage[0].LinkText);
//            Assert.AreEqual("Journeys", homePage.subnavigationlinksinhomepage[1].LinkText);
//            Assert.AreEqual("BeInspired", homePage.subnavigationlinksinhomepage[2].LinkText);
//            Assert.AreEqual("When To Go", homePage.subnavigationlinksinhomepage[3].LinkText);
//            Assert.AreEqual("Search", homePage.subnavigationlinksinhomepage[4].LinkText);
//            Console.WriteLine("All the Main Navigation links are Appearing");
//        }

//        [Then(@"Right-hand Side Bar is Displayed")]
//        public void RightHandSidebarIsDisplayed()
//        {
//            new HomePage(driver).RightHandNavigation();

//        }

//        //Hover-over on the Destinations Link
//        [When(@"I Hover Over on the Destinations link")]
//        public void Clicked_DestinationsLink()
//        {
//            new HomePage(driver);
//            //driver.FindElement(By.XPath("//*[@id='destinations-hub']")).Click();
//            Actions builder = new Actions(driver);
//            builder.Click(driver.FindElement(By.XPath("//*[@id='destinations-hub']"))).Perform();
//        }

//        //[Then(@"Destinations pop-up displayed")]
//        //public void DestinationsPopup
//        //{
//        //    driver.
//        //}
//    }

//}
