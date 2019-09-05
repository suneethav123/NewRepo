using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* This test is to add a new Movie Club member  */


namespace Cinemark.com.cinemark.testscripts
{
    class AddNewClubMemberTest
    {
        IWebDriver driver;
        private HomePage HP;
        private MovieClub MC;
        private NewMovieClubSignIn NM;


        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait()
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Url = "https://qasiteb.usa.cinemark.com";

        }

        [Test]
        public void NewClubMemberAdd()
        {
             HP = new HomePage(driver);
             MC = new MovieClub(driver);
             NM = new NewMovieClubSignIn(driver);

            HP.GoToMovieClub();                    
            MC.UpdateBillingZip("75093");
            NM.AddNewMovieClubMemberInfo("yjanagama+23@gmail.com", "yjanagama+23@gmail.com","Cinemark1","Cinemark1","Indu23", "Auto", "9721111234", "75093", "4111111111111111", "111", "75093");

            /*string ExpectedSuccessMsg = "Your payment was successfully charged on 4/23/2019 at 8:52 am  ";
            string ActualExpectedMsg = NM.GetSuccessMessage().Text;*/

           

            string ExpMsg = "You earned 100 points for joining Movie Club.";
            string ActMsg = NM.GetPointsSuccessMessage().Text;

            Assert.AreEqual(ExpMsg, ActMsg);
        }



       /* [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }*/
    }
}
