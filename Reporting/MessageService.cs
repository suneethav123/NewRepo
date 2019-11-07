using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;

using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Cinemark.Utilities;
using MailKit.Net.Smtp;
using MimeKit;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using System.Security.Cryptography.X509Certificates;

using System.Threading;
using Google.Apis.Auth.OAuth2;
using MailKit.Security;
using Application = Microsoft.Office.Interop.Outlook.Application;

namespace Cinemark.Reporting
{
    public class MessageService
    {
  

        public static string ZipReportFolder()
        {
            string projectpath = Directory.GetParent(new autoutilities().GetProjectLocation()).ToString();
            string startPath = Path.Combine(projectpath, "Automation_Report"); ;//folder to add
            string zipPath = projectpath + "//Automation_Report.zip";//URL for your ZIP file    
            string date = DateTime.Now.ToString("MM-dd-yy");           

           // string new_file_path = projectpath + "Old Reports//Automation_Report_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";
            
            if (File.Exists(zipPath))
            {
               string new_file_path = zipPath.Replace(".zip", " created on " + File.GetLastWriteTime(zipPath).ToString("dd-MM-yyyy hh-mm-ss tt") + ".zip");
                File.Move(zipPath, new_file_path);
                File.Delete(zipPath);
            }
            if (!File.Exists(zipPath))
            {
                ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Fastest, true);

            }
           
            return zipPath;

        }
        
        Application oApp = new Application();
    
        public void CreateEmailItem()
        {
            Microsoft.Office.Interop.Outlook.MailItem eMail = (Microsoft.Office.Interop.Outlook.MailItem)
          oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            eMail.Subject = "Automation QA Report";            
            eMail.To = "sanne@cinemark.com";
            eMail.Body = @"Hi,
      Please find the attached Test report for your review.

             -- Cinemark QA
              ";
             string zipfilepath = ZipReportFolder();
            eMail.Attachments.Add(zipfilepath, OlAttachmentType.olByValue, Type.Missing, Type.Missing);
            eMail.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceLow;
            ((Microsoft.Office.Interop.Outlook._MailItem)eMail).Send();
        }
    }
}



