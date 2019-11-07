using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Cinemark.Utilities;
using log4net;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Cinemark.Reporting
{
    class ExtentManager
    {
        public static int pass_counter = 0;
        public static int totalcounter = 0, failed_Counter = 0;
        private static ExtentReports extent;    
        public static ILog log = log4net.LogManager.GetLogger("ExtentManager");

        public static ExtentReports GetInstance()
        {
           
           log.Info("Initializing Extent..");

            if (extent == null)
            {
                //Initialize Extent report before test starts

                string reportPath = (new Reporter().CreateReportsDirectory() + "\\CinemarkQADashboard_" + System.DateTime.Today.ToString("dd - MM - yyyy") + ".html");
                           
                var htmlReporter = new ExtentHtmlReporter(reportPath);
                log.Info(reportPath);
                string imagePath = new autoutilities().GetProjectLocation() + "\\Resources\\cinemarkLogo.PNG";
                //Attach report to reporter
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("Report Title", "Cinemark Automation Test Report");
                extent.AddSystemInfo("Repository Name", "Internet-Tests");
                extent.AddSystemInfo("OS", System.Environment.OSVersion.VersionString);
                extent.AddSystemInfo("Test Environment", new autoutilities().GetKeyValue("URL", "CinemarkURL"));              
                extent.AddSystemInfo("User Name", System.Environment.UserName);
                
                string configPath = new autoutilities().GetProjectLocation() + "\\extent-config.xml";             
                htmlReporter.LoadConfig(configPath);               
                log.Info(configPath);
                
            }

            return extent;
          
        }


      

        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            //On Test Fail .. 
            if (status == TestStatus.Failed)
            {
                failed_Counter = failed_Counter + 1;

            }
            else
            {
                //Pass cases .. 
                pass_counter = pass_counter + 1;

            }
            extent.Flush();
           //driver.Close();
        }

        /* public static ExtentHtmlReporter HtmlReporter;
         private static ExtentReports extent;

         public static ExtentReports GetInstance()
         {

             if (extent == null)
             {
                 string reportPath = @"C:\Reports\TestAutomationReport.html";
                 HtmlReporter = new ExtentHtmlReporter(reportPath);
                 extent = new ExtentReports();
                 extent.AttachReporter(HtmlReporter);
                 extent.AddSystemInfo("OS", "Windows");
                 extent.AddSystemInfo("Test Environment", "QASite b");
                 string thisIsMyDir = System.AppContext.BaseDirectory;
                 string extentConfigPath = @"c:\extent-config.xml";
                 HtmlReporter.LoadConfig(extentConfigPath);


             }

             return extent;


         }*/

    }
    }

