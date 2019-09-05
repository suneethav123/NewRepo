using AventStack.ExtentReports;
using Cinemark.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;

// This is Basetest class

namespace Cinemark.com.cinemark.testscripts
{[TestFixture]
    class BaseTest
    {
        public IWebDriver driver;
        public ExtentReports rep;
        public ExtentTest test;


        [OneTimeSetUp] 
        public void OpenBrowser()
        {
            rep = ExtentManager.GetInstance();
            driver = new ChromeDriver();
            
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //driver.Url = "https://qasitea.usa.cinemark.com";
            driver.Url = "https://qasiteb.usa.cinemark.com/shoppingcart/#";
            
            //driver.Url = "https://usvir04224.usa.cinemark.com:8443/";
        }

      /* [OneTimeTearDown]
         public void CloseBrowser()
           {
               rep.Flush();
               driver.Close();
           } */
    }
}
