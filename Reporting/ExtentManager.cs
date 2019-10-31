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
        //public static string TestName = TestContext.CurrentContext.Test.MethodName;
      //  public static string TestCaseName = TestContext.CurrentContext.Test.MethodName;
        public static int totalcounter = 0, failed_Counter = 0;

        

        //Global Variable for Extend report
        private static ExtentReports extent;
      //  private static ExtentTest test;
       // private static ExtentHtmlReporter htmlReporter;
       // Reporter reporter = new Reporter();
        public static ILog log = log4net.LogManager.GetLogger("ExtentManager");

        public static ExtentReports GetInstance()
        {
           
           log.Info("Initializing Extent..");

            if (extent == null)
            {
                //Initialize Extent report before test starts

                string reportPath = (new Reporter().CreateReportsDirectory() + "\\CinemarkQADashboard_" + System.DateTime.Today.ToString("dd - MM - yyyy") + ".html");
               // string reportPath = Path.Combine(folderpath, "\\Cinemark_Automation_Dashboard" + ".html");
              
                var htmlReporter = new ExtentHtmlReporter(reportPath);
                log.Info(reportPath);

                //Attach report to reporter
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("OS", "Windows");
                extent.AddSystemInfo("Environment", "Site B QA");
               // extent.AddSystemInfo("User Name", "Suneetha Anne");

                string configPath = new autoutilities().GetProjectLocation() + "\\extent-config.xml";
               
               htmlReporter.LoadConfig(configPath);
                log.Info(configPath);
                
            }

            return extent;
          
        }


        /*public  void TerminateExtent()
        {
            string log_path = new Reporter().CreateReportsDirectory() + "\\logFile.log";
            System.Console.WriteLine("Refer Log File:=>" + log_path);
            reporter.report_tests_count(totalcounter, failed_Counter, log_path);            
            reporter.CloseFileStream();

        }*/

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

