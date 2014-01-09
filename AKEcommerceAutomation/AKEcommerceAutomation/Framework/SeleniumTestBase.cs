using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace AKEcommerceAutomation.Framework
{
    [Binding]
    public class SeleniumTestBase
    {
        public static IWebDriver driver;
        public static string Browser;
        public static string Testenvironment;
        public static string Url;
        public static string Url1;

        public IWebDriver Current()
        {
            //DesiredCapabilities chromeCapabilities = new DesiredCapabilities();
            Browser = ConfigurationManager.AppSettings["browser"];
            Testenvironment = ConfigurationManager.AppSettings["Environment"];
            Environment.SetEnvironmentVariable("Testenvironment", Testenvironment);

            EnvironmentConfiguration.CreateInstance(@"Framework\Environment.xml", Testenvironment);
            Url = EnvironmentConfiguration.Instance.GetEnvironmentVariable("URL");
            //Url1 = EnvironmentConfiguration.Instance.GetEnvironmentVariable("URL1");

            if (!FeatureContext.Current.ContainsKey("browser"))
            {
                switch (Browser)
                {
                    case "IE":
                        break;

                    case "FIREFOX":
                        var profileManager = new FirefoxProfileManager();
                        FirefoxProfile profile = profileManager.GetProfile("SeleniumProfile");
                        FeatureContext.Current["browser"] = new FirefoxDriver(profile);
                        ScenarioContext.Current["browser"] = FeatureContext.Current["browser"];
                        driver = (IWebDriver) ScenarioContext.Current["browser"];
                        driver.Manage().Window.Maximize();
                        driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
                        break;

                    case "CHROME":
                        var options = new ChromeOptions();
                        options.AddArgument("--start-maximized");
                        driver = new ChromeDriver(options);
                        //FeatureContext.Current["browser"] = new ChromeDriver(options);
                        //ScenarioContext.Current["browser"] = FeatureContext.Current["browser"];
                        //driver = (IWebDriver)ScenarioContext.Current["browser"];
                        break;
                }
            }
            else
            {
                ScenarioContext.Current["browser"] = FeatureContext.Current["browser"];
                driver = (IWebDriver) ScenarioContext.Current["browser"];
            }
            return driver;
        }

        //[AfterFeature]
        //public static void Close()
        //{
        //    driver.Manage().Cookies.DeleteAllCookies();
        //    driver.Quit();
        //}
    }
}