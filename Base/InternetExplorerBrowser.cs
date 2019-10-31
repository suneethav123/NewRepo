using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;


namespace Cinemark.Base
{
    class InternetExplorerBrowser
    {
        private log4net.ILog log = log4net.LogManager.GetLogger("InternetExplorerBrowser");
        private DesiredCapabilities capabilities = new DesiredCapabilities();
        public InternetExplorerOptions options = new InternetExplorerOptions();

        IWebDriver driver;
        InternetExplorerDriverService driverService;

        /// Set up Internet Explorer driver
        public IWebDriver InitIEDriver()
        {
            driverService = InternetExplorerDriverService.CreateDefaultService(IEDriverPath, "IEDriverServer.exe");
            driver = new InternetExplorerDriver(driverService, Options, TimeSpan.FromMinutes(1));
            return driver;
        }

        //public IWebDriver Driver
        //{
        //    get
        //    {
        //        log.Info("Launching IE with default settings");
        //        return new InternetExplorerDriver(IEDriverPath, Options);
        //    }
        //}

        /**
        * Sets the required properties for IEdriver to initialize 
        * @return IECapabilities with required properties set
        */
        private InternetExplorerOptions Options
        {
            get
            {
                options.EnablePersistentHover = false;
                options.EnableNativeEvents = false;
                options.EnsureCleanSession = true;
                options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                return options;
            }
        }

        private void SetCapabilities()
        {
            capabilities.SetCapability("ignoreProtectedModeSettings", true);
            capabilities.SetCapability("enablePersistentHover", false);
            capabilities.SetCapability("native_events", false);
        }

        private string IEDriverPath
        {
            get
            {
                return new Cinemark.Utilities.autoutilities().GetProjectLocation() + @"\Debug";
               
            }
        }
    }
}
