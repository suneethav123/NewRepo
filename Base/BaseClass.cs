using Cinemark.Utilities;
using log4net;
using MbUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Cinemark.Base
{
    class baseclass 
    {
        public static IWebDriver Driver;
        public static ILog baseLog;
        public BalloonPopUp balloon;
        public static ChromeBrowser chromebrowser;
        public static autoutilities _autoutilities;
        /// <Overall summary>
        ///1. Getter method for Webdriver in which instance the // testcase need to run whether on linear mode/null or remote mode(Grid and Saucelabs) - GetDriver()
        ///2. This method selects the required browsers from Config file, instantiates respective browser driver returns the driver. - InitialSetupWebdriver()
        ///Method for selecting Browser by providing browsere type  along the with WebDriver Driver instances - SelectBrowser(IWebDriver _driver)
        ///This method launches the URL given in the Config file - NavigateToUrl(string URL)
        /// </Overall summary>

        public baseclass()
        {
          
            baseLog = LogManager.GetLogger("BaseClass");
            baseLog.Info("Initializing ..");
            balloon = new BalloonPopUp();
            _autoutilities = new autoutilities();
        }


        /// <summary>
        ///Getter method for Webdriver in which instance the // testcase need to run whether on linear mode/null or remote mode(Grid and Saucelabs) 
        /// </summary>
        /// <params>None</params>
        /// <return>Webdriver Instance</returns>

        public  IWebDriver GetDriver()
        {
            if (_autoutilities.GetKeyValue("MODEOFEXECUTION", "ExecutionMode").ToLower() == "linear" || _autoutilities.GetKeyValue("MODEOFEXECUTION", "ExecutionMode") == "" || _autoutilities.GetKeyValue("MODEOFEXECUTION", "ExecutionMode").ToLower() == null)
            {
                Driver = InitialSetupWebdriver();
            }
            else if (_autoutilities.GetKeyValue("MODEOFEXECUTION", "ExecutionMode").ToLower() == "remote")
            {
                //Driver = new RemoteBrowser().InitialiseRemoteDriver();
            }

            WebListener webListener = new WebListener(Driver);
            Driver = webListener.Driver;

            return Driver;
        }


        /// <summary>
        ///This method selects the required browsers from Config file, instantiates respective browser driver returns the driver.
        /// </summary>
        /// <params>None</params>
        /// <return>Webdriver Instance</returns>

        public static IWebDriver InitialSetupWebdriver()
        {
            try
            {
                IWebDriver driver = SelectBrowser(Driver);
                baseLog.Info("Initiated Webdriver...");
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Manage().Window.Size = new System.Drawing.Size(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width + 10, System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height + 10);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                return driver;
            }
            catch (WebDriverException E)
            {
                Assert.Fail("Error while Initializing the Webdriver class" + E.Message);
                return null;
            }
        }

        /// <summary>
        ///Method for selecting Browser by providing browsere type  along the with WebDriver Driver instances . If the browser type is null it will take as ff other than chrome.ie,ff/firefox or null ,  it will provide an error message of invalid browser type. 
        /// </summary>
        /// <params>Driver instance</params>
        /// <return>WebDriver Instance</returns>

        public static IWebDriver SelectBrowser(IWebDriver driver)
        {
            string sType = _autoutilities.GetKeyValue("BROWSER", "Browser");
            
        chromebrowser = new ChromeBrowser();
            switch (sType)
            {
                case "ie":
                    /// Added code to overcome the problem of 'Protected Mode' in Internet Explorer (must be set to the same value either enabled or disabled for all zones)
                    //var options = new InternetExplorerOptions();
                    //options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    //_driver = new InternetExplorerDriver(_autoutilities.GetProjectLocation() + @"\Drivers");
                    driver = new InternetExplorerBrowser().InitIEDriver();
                    break;
                case "ff":
                case "firefox":
                    driver = new FirefoxBrowser().GetFirefoxDriver();
                    break;
                case "chrome":
                    driver = chromebrowser.InitChromeDriver(chromebrowser.DriverLocation, "");
                    break;
                case "":
                    driver = new FirefoxBrowser().GetFirefoxDriver();
                    break;
                default:
                    Assert.Fail("Invalid Browser name specified in Config file");
                    break;

            }
            return driver;
        }

       

        /// <summary>
        ///This method launches the URL given in the Config file
        /// </summary>
        /// <params>Url</params>
        /// <return>Void</returns>

        public void NavigateToUrl(IWebDriver driver)
        {
            string url = _autoutilities.GetKeyValue("URL", "CinemarkURL");
            driver.Navigate().GoToUrl(url);
        }



        /// <summary>
        /// Metohod for Quiting all Driver Instances  
        /// </summary>
        /// <params>Driver instance</params>
        /// <return>None</returns>

        public void closeInstances(IWebDriver Driver)
        {
            balloon.disposeIcon();
            Driver.Quit();
        }
    }
}
