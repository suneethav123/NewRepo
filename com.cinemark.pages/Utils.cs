using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;


namespace Cinemark.com.cinemark.pages
{
    class Utils
    {
        
        


         public static void WaitForLoad(IWebDriver driver, int timeoutSec = 15)
          {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
                wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
          }

       
        public static WebDriverWait WaitForElement(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            return wait;

        }

        public static string GenerateUser()
        {
            Random r = new Random();

            int n = r.Next();

            string emailId = "AutoTest" + n + "@example.com";

            return emailId;
        }

        public static int PointsEarned(string points)
        {
            int numberOfPoints = (int)Math.Round(Convert.ToDecimal(points));
            return numberOfPoints;
        }

        public static void WriteOnExcel(string emailID)
        {
            string myPath = @"C:\Reports\EmailId.xlsx";
            FileInfo fi = new FileInfo(myPath);
            if (!fi.Exists)
            {
                Console.Out.WriteLine("file doesn't exists!");
            }
            else
            {
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                var workbook = excelApp.Workbooks.Open(myPath);
                Worksheet worksheet = workbook.ActiveSheet as Worksheet;


                Microsoft.Office.Interop.Excel.Range range = worksheet.Cells[1, 1] as Range;
                range.Value2 = emailID;

                //excelApp.Visible = true;
                workbook.Save();
                workbook.Close();
            }
        }

        public static string GetEmailId()
        {
            string output = null;

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Reports\EmailId.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    //new line
                    if (j == 1)
                        Console.Write("\r\n");

                    //write the value to the console
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                         output = xlRange.Cells[i, j].Value2.ToString();
                        //Console.Write(output + "\t");
                    }

                }
            }

            

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            return output;


        }


    }
}
