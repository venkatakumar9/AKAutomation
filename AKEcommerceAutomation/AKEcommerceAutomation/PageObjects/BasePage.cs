﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;
using AKEcommerceAutomation.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace AKEcommerceAutomation.PageObjects
{
    //using OpenQA.Selenium.Support;
    //using NUnit.Framework;
    //using NUnit.VisualStudio.TestAdapter;

    public class BasePage : SeleniumTestBase
    {
        //public IWebDriver driver;
        public enum searchType
        {
            Destinations,
            Journeys,
            BeInspired
        }

        protected IWebDriver _driver;
        private IBasePageStrategy _skin;

        protected BasePage(IWebDriver driver)

        {
            _driver = driver;
        }

        public List<TopLevelNavigation> TopNavLinks { get; set; }
        public List<FooterNavigation> FooterNavLinks { get; set; }
        public List<PreFooterNavigation> Prefooternavlinks { get; set; }
        public List<subnavigationinhomepage> subnavigationlinksinhomepage { get; set; }

        public int RandomNumber()
        {
            var random = new Random();
            return random.Next(10000, 10000000);
        }

        public string GetUsernameFromConfig()
        {
            return EnvironmentConfiguration.Instance.GetEnvironmentVariable("L0GIN_USERNAME");
        }

        public string GetPasswordFromConfig()
        {
            return EnvironmentConfiguration.Instance.GetEnvironmentVariable("LOGIN_PASSWORD");
        }

        //***Commenting it untill login functionality is delivered. 
        //public static bool IsUserLoggedIn()
        //{
        //    if (driver.FindElement(By.Id("")).GetAttribute("class").Contains("loggedout"))
        //        return false;
        //    return true;
        //}

        public string GetHtmlTitle()
        {
            return _driver.Title;
        }

        public string GetUniqueValidUsername()
        {
            return RandomNumber().ToString(CultureInfo.InvariantCulture);
        }

        //***Get the valid Email: Un-comment when this functionality delivers
        //public string GetUniqueValidEmail()
        //{
        //    return RandomNumber().ToString(CultureInfo.InvariantCulture) + "@ak.com";
        //}

        //***Logo is not clickable: Make it available once it was delivered
        //public AKHomePage ClickTHELogo()
        //{
        //    _driver.FindElement(By.XPath("")).Click();
        //    _driver.WaitForPageToLoad();
        //    return new AKHomePage();
        //}

        //public int GetHeaderNavigationCount()
        //{
        //    return _driver.FindElements(By.XPath("//*[@id='page-wrapper']/div[2]/section/nav/a")).Count;
        //}

        //public int GetFooterCount()
        //{
        //    return _driver.FindElements(By.XPath("//*[@id='footer']/div[2]/div")).Count;
        //}

        //public string[] GetHeaderValues()
        //{
        //    var headerValues = new string[GetHeaderNavigationCount()];
        //    for (int i = 0; i < GetHeaderNavigationCount(); i++)
        //    {
        //        headerValues[i] =
        //            _driver.FindElement(By.XPath("//*[@id='page-wrapper']/div[2]/section/nav/a[" + (i + 1) + "]/a/span"))
        //                .Text;
        //    }
        //    return headerValues;
        //}

        //public string[] GetFooterValues()
        //{
        //    var footerValues = new string[GetFooterCount()];
        //    for (int i = 0; i < GetFooterCount(); i++)
        //    {
        //        footerValues[i] = _driver.FindElement(By.XPath("//*[@id='footer']/div[2]/div[" + (i + 1) + "]/a")).Text;
        //    }
        //    return footerValues;

        //    {

        //    }

        //}

        public string GetCopyRightText()
        {
            return _driver.FindElement(By.XPath("//*[@id='footer']/div[2]/div/div/footer/p")).Text;
        }

        //UN-Comment When JourneyPage is Written
        //public string GetJourneysPage()
        //{
        //    driver.FindElement(By.XPath("//*[@id='journeys']")).Click();
        //    driver.WaitForPageToLoad();
        //    return new JourneysPage(_driver);

        //}


        //private readonly string WebUrl;

        //public void Navigate()
        //{
        //    driver.Navigate().GoToUrl(WebUrl);
        //    driver.Manage().Window.Maximize();

        //}

        public void GoBack()
        {
            _driver.Navigate().Back();
        }

        public void RightHandNavigation()
        {
            // driver.WaitForPageToLoad();
            if (driver.FindElement(By.XPath("//*[@id='sign-in']/strong")).Displayed)
            {
                Assert.AreEqual("RightHand SideBar",
                    driver.FindElement(By.XPath("//*[@id='page-wrapper']/div[1]/ul")).Text);
                Console.WriteLine("Right Hand side bar is displayed");
                driver.WaitForPageToLoad();
                driver.FindElement(By.XPath("//*[@id='page-wrapper']/div[1]/ul/li[1]/a/span[2]")).Click();
            }

            //Console.WriteLine("enquire, RightHand SideBar is Displayed");
        }

        private List<TopLevelNavigation> BuilTopLevelNavigation()
        {
            return _skin.BuildTopLevelNavigation(_driver, TopNavLinks);
        }

        private List<FooterNavigation> BuilFooterNavigation()
        {
            return _skin.BuilFooterNavigation(_driver, FooterNavLinks);
        }

        private List<PreFooterNavigation> BuildPreFooterNavigation()
        {
            return _skin.BuildPreFooterNavigation(_driver, Prefooternavlinks);
        }

        //Broken Images
        public void BrokenImages(IWebElement ele)
        {
            string str = ele.GetAttribute("src");
            if (str.EndsWith(".jpg"))
                Console.WriteLine("Pass");
            else
                Assert.Fail();
        }

        /* This is generic function used for capturing screenshot*/

        public void SaveScreenShot(string screenshotFirstName)
        {
            string folderLocation = "C:\\Projects\\ScreenShot";
            if (!Directory.Exists(folderLocation))
            {
                Directory.CreateDirectory(folderLocation);
            }
            Screenshot screenshot = ((ITakesScreenshot) driver).GetScreenshot();
            var filename = new StringBuilder(folderLocation);
            filename.Append(screenshotFirstName);
            filename.Append(DateTime.Now.ToString("ddMMyyyy"));
            filename.Append(".Jpeg");
            screenshot.SaveAsFile(filename.ToString(), ImageFormat.Jpeg);
        }

        public void Buildsubnavigationinhomepage()
        {
            subnavigationlinksinhomepage = new List<subnavigationinhomepage>();
            for (int i = 1; i <= 4; i++)
            {
                subnavigationlinksinhomepage.Add(new subnavigationinhomepage
                {
                    LinkText = _driver.FindElement(By.XPath("")).Text
                });
            }
        }

        public class FooterNavigation
        {
            public string LinkText { get; set; }
        }

        public interface IBasePageStrategy
        {
            List<TopLevelNavigation> BuildTopLevelNavigation(IWebDriver driver, List<TopLevelNavigation> TopNavLinks);
            List<FooterNavigation> BuilFooterNavigation(IWebDriver driver, List<FooterNavigation> FooterNavLinks);

            List<PreFooterNavigation> BuildPreFooterNavigation(IWebDriver driver,
                List<PreFooterNavigation> PreFooterNavLinks);
        }

        public class PreFooterNavigation
        {
            public string LinkText { get; set; }
        }

        public class TopLevelNavigation
        {
            public string LinkText { get; set; }
        }

        public class subnavigationinhomepage
        {
            public string LinkText { get; set; }
        }
    }
}