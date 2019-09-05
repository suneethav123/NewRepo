using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace Cinemark.Reporting
{
    class ExtentManager
    {
        public static ExtentHtmlReporter HtmlReporter;
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

        }
    }
}
