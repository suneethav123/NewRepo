using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Cinemark.Base;
using Cinemark.Reporting;
using Cinemark.Utilities;
using log4net;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Drawing.Imaging;


// This is Base// test class

namespace Cinemark.com.cinemark.testscripts
{

   
    public class BaseTest
    {

        public static IWebDriver driver;
        public static ExtentReports rep;
        public static ExtentTest test;
        baseclass baseclass = new baseclass();
        Reporter reporter = new Reporter();
        MessageService service = new MessageService();
       
        public static ILog log = log4net.LogManager.GetLogger("BaseTest");

        // UITest wraps all Tests to catch not just assertion failures but all exceptions and perform mentioned actions
        public void UITest(Action action)
        {
            try
            {
                action();
                
            }
            catch (Exception e)
            {
                         
                reporter.getScreenshot(driver);
                test.Log(Status.Fail, e.ToString());
                throw;
            }
            
        }
      

        [OneTimeSetUp]

       public void StartTest()
        {
            log.Info("Test Started..");
            rep = ExtentManager.GetInstance();
            driver = baseclass.SelectBrowser(driver);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            baseclass.NavigateToUrl(driver);
           rep = ExtentManager.GetInstance();
         
        }
        [SetUp]
        public void BeforeTest()
        {
            try {
              
                test = rep.CreateTest(TestContext.CurrentContext.Test.MethodName);
               
            }
            catch (Exception e)
            {
                throw (e);

            }
        }

        [TearDown]
        public void AfterTest()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = "" +TestContext.CurrentContext.Result.StackTrace + "";
                var errorMessage = TestContext.CurrentContext.Result.Message.ToString();
                Status logstatus;
                string TestName = TestContext.CurrentContext.Test.MethodName;
                string screenshotpath = new Reporting.Reporter().CreateScreenShotsFolder() + "\\" + TestName + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        reporter.getScreenshot(driver);    //--enable this peice of code if you are debugging/running only 1 particulatr test.
                        test.Log(logstatus, "Test ended with status *** " +logstatus + " ***  " +errorMessage);
                        test.Log(logstatus, "Snapshot below: " + test.AddScreenCaptureFromPath(screenshotpath));
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        test.Log(logstatus, "Test ended with status *** " +logstatus + " ***  ");
                        break;
                    case TestStatus.Passed:
                        logstatus = Status.Pass;
                        test.Log(logstatus, "Test ended with status *** " +logstatus + " ***  ");
                        break;
                }
           }
           catch (Exception e)
           {
             
            }
        }

        [OneTimeTearDown]
        public void AfterClass()
        {
            try
            {
                rep.Flush();
                service.CreateEmailItem();
            }
            catch (Exception e)
            {
                throw (e);
            }
            driver.Close();
            
            }
       


    }
}





     ////  Indira's Code ////
      /*  [OneTimeSetUp] 
        public void OpenBrowser()
        {
            rep = ExtentManager.GetInstance();
           /* driver = new ChromeDriver();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //driver.Url = "https://qasitea.usa.cinemark.com";
            driver.Url = "https://qasiteb.usa.cinemark.com/shoppingcart/#";
            
            //driver.Url = "https://usvir04224.usa.cinemark.com:8443/";
        }

      
    }

     [OneTimeTearDown]
    public void CloseBrowser()
               {
                   rep.Flush();
                   driver.Close();
               } 
}*/


