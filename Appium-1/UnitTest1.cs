using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using System.Configuration;

namespace Appium
{
    [TestClass]

    public class UnitTest1
    {
        //create instance for Appium webdriver
        AppiumDriver<AndroidElement> _driver;
        
        //protected string AllocateUI_URL { get; private set; } //Allocate 

        [TestMethod]
        public void TestBrowser()
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("deviceName", "donatello");
            cap.SetCapability("platformVersion", "6.0.0");
            cap.SetCapability("udid", "169.254.190.187:5555");
            cap.SetCapability("fullReset", "True");
            cap.SetCapability(MobileCapabilityType.App, "Browser");
            cap.SetCapability("platformName", "Android");
            _driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            #region Ignore me
            /*Allocate
                string defaultUrl = string.Format("http://{0}/ZarionAllocate", Environment.MachineName);
                var url = ConfigurationManager.AppSettings["AllocateURL"] ?? defaultUrl;
                AllocateUI_URL = url;
                _driver.Navigate().GoToUrl(url);
                End Allocate*/ 
            #endregion

            _driver.Navigate().GoToUrl("http://www.bing.com");
            _driver.FindElementByName("q").SendKeys("Microsoft");
            _driver.FindElementByName("q").SendKeys(Keys.Enter);
            
        }
        [TestCleanup]
        public void TearDown()
        {
            _driver.Quit();
        }
    }

}