using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Cinemark.Reporting;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Cinemark.Utilities
{
    public class autoutilities
    {

        public static ILog log = LogManager.GetLogger("autoutilities");

        public string GetProjectLocation()
        {
            string sDirectory = Environment.CurrentDirectory;
            string sDir = Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.FullName;
            //Console.WriteLine("Full project path :=>>>>>>>" + sDir);
            //log.Info("path is:=>" + sDir);
            return sDir;
        }
         
      

         public string GetTestDataLocation()
         { 
             return GetProjectLocation() + @"\TestData\"; 
         } 
 
 
         public string GetTestResultsLocation()
         { 
             return GetUserDesktopPath() + @"\TestResults\"; 
         } 
         public static string GetConfigTextFilePath()
         { 
             return GetBasePath() + @"\Config.txt"; 
         } 
         public static string GetBasePath()
         { 
             string BaseDirToProjects = Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName; 
            
             log.Info("=================>>> base path is:=>" + BaseDirToProjects); 
             return BaseDirToProjects; 
         } 
         public string GetTestOutputLocation()
         { 
             return GetUserDesktopPath() + @"\TestOutput\"; 
         } 
 
         public string GetUserDesktopPath()
         { 
             return System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Desktop"; 
         } 
 
 
         public string GetUserProfilePath()
         { 
             return System.Environment.GetEnvironmentVariable("USERPROFILE"); 
         } 
 
 
         public string GetCurrentDirectoryPath()
         { 
             return Environment.CurrentDirectory; 
         } 
 
 
         public string GetSolutionLocation()
         { 
             string sDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName; 
             return sDirectory; 
         }

    
        public string GetKeyValue(string sectionname, string keyname)
        {
            var section = (ConfigurationManager.GetSection(sectionname) as System.Collections.Specialized.NameValueCollection);
            return section[keyname];
        }
        public bool KillBrowserInstances()
        {
            string sType = GetKeyValue("BROWSER", "Browser").ToLower();

            foreach (Process p in Process.GetProcesses())
            {
                if (sType == "ie")
                {
                    if (p.ProcessName == "iexplore")
                    {
                        p.Kill();
                    }
                }
                if (sType == "ff")
                {
                    if (p.ProcessName == "firefox")
                    {
                        p.Kill();
                    }
                }
                if (sType == "chrome")
                {
                    if (p.ProcessName == "chrome")
                    {
                        p.Kill();
                    }
                }
            }
            return true;

        }


        public void killProcesses(string processName)
         { 
             foreach (var process in Process.GetProcessesByName(processName)) 
             { 
                 process.Kill(); 
             } 
         }
 
    }
}
