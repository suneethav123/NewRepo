using Cinemark.Utilities;
using log4net;
using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using System.IO;


namespace Cinemark.Base
{
    class ChromeBrowser
    {
        private IWebDriver driver;
        private static ILog Log = LogManager.GetLogger("ChromeBrowser");
        private ChromeOptions options = new ChromeOptions();
        autoutilities _autoUtils = new autoutilities();
        /// <summary>
        /// Set up the chrome web driver
        /// </summary>
        public IWebDriver Driver
        {
            get
            {
                if (IsUserDataDirPresent())
                {
                    driver = InitChromeDriver(UserDataLocation, ProfileName);
                }
                else
                {
                    driver = InitChromeDriver();
                }
                return driver;
            }
        }


        public IWebDriver InitChromeDriver()
        {
            Log.Info("Launching google chrome with new profile..");
            Log.Info("chrome driver initialized..");
            options.AddArguments("--disable-extensions");
            return new ChromeDriver(DriverLocation, Options);
        }


        public IWebDriver InitChromeDriver(String UserDataPath, String ProfileName)
        {
            Log.Info("Launching google chrome with specified profile - " + ProfileName);
            if (IsProfileDirPresent())
            {
                Log.Info("Running with specified chrome profile");
                options.AddArguments("user-data-dir=" + UserDataPath);
                options.AddArguments("--profile-directory=" + ProfileName);
                options.AddArguments("--disable-extensions");
                Log.Info("Init chrome driver with custom profile is completed..");
            }
            else
            {
                Log.Info("Specified chrome profile does not exists in 'User Data' folder");
                Log.Info("Hence Chrome Browser is launched with a new profile..");
            }

            return new ChromeDriver(DriverLocation, Options);
        }

        private ChromeOptions Options
        {
            get
            {
                options.AddArgument("--disable-background-mode");
                options.AddArgument("--start-maximized");
                //set user agent to ipad
                //options.AddArgument("--user-agent=\"Mozilla/5.0 (iPad; CPU OS 7_0_2 like Mac OS X) AppleWebKit/537.51.1 (KHTML, like Gecko) Version/7.0 Mobile/11A501 Safari/9537.53\"");
                return options;
            }
        }

        /// <summary>
        /// Method to retrieve Chrome Driver Path
        /// </summary>
        /// <returns>Chrome Driver Path</returns>
        public string DriverLocation
        {
            get
            {
                return _autoUtils.GetProjectLocation() + @"\Debug";

            }
        }


        /// <summary>
        ///  Method to retrieve the Chrome 'User Data' path given in Properties file
        /// </summary>
        /// <returns>Chrome user data path</returns>

        public string UserDataLocation
        {
            get
            {
                return ConfigurationManager.AppSettings["ChromeUserDirectoryPath"];
            }
        }

        /// <summary>
        /// Method to retrieve the Chrome 'Profile Folder' path given in Properties file
        /// </summary>
        /// <returns>Chrome 'Profile Folder' path</returns>
        public string ProfileName
        {
            get
            {
                return ConfigurationManager.AppSettings["ChromeProfileFoldername"];
            }
        }

        /// <summary>
        /// Verifies if Chrome User Data Folder is available
        /// </summary>
        /// <returns>true/false</returns>
        public bool IsUserDataDirPresent()
        {
            string sUserData = UserDataLocation;
            try
            {
                if (sUserData.Length != 0)
                {
                    return File.Exists(sUserData);
                }
                else
                {
                    return false;
                }
            }
            catch (NullReferenceException)
            {
                Log.Error("folder does not exists" + sUserData);
                //Assert.fail("folder does not exists"+sUserData);
                return false;
            }
        }

        /// <summary>
        /// Verifies if Chrome Profile Folder is available
        /// </summary>
        /// <returns>true/false</returns>
        public bool IsProfileDirPresent()
        {
            string profilePath = UserDataLocation + "/" + ProfileName;
            try
            {
                if (profilePath.Length != 0)
                {
                    return File.Exists(profilePath);
                }
                else
                {
                    return false;
                }
            }
            catch (NullReferenceException)
            {
                Log.Error("Profile does not exists" + ProfileName);
                Assert.Fail("Profile does not exists" + ProfileName);
                return false;
            }
        }
    }
}
