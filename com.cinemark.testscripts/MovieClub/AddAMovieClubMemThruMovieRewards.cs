using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using log4net;
using Cinemark.Reporting;
using AventStack.ExtentReports;



/*This // test is to add new movie club member thru Movie Rewards link  */

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class AddAMovieClubMemThruMovieRewards : BaseTest
    {

        
        private HomePage HP;
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private NewMovieClubSignIn NM;
        private string emailId;


        /* Adding a new Movie Club Member thru Movie Rewards link */

        [Test, Order(1)]
        [Obsolete]
        public void AddNMCMemberThruMovieRewards()

        {

            UITest(() =>
            {

                try
                {

                    HP = new HomePage(driver);
                    MR = new MovieRewardsInfoPage(driver);
                    MC = new MovieClub(driver);
                    NM = new NewMovieClubSignIn(driver);

                    emailId = Utils.GenerateUser();
                    Utils.WriteOnExcel(emailId);

                    HP.GoToMovieRewards();
                    MR.LearnMoreLink();
                    MC.UpdateBillingZip(TestData.UpdateBillingZIP);
                    NM.CreateAccount();
                    NM.AccountInformation(emailId, emailId, "Cinemark1");
                    NM.PersonalInformation("Auto", "User", "9721112222", "75093");
                    NM.RecurringPaymentInfo(TestData.MCCreditCard, TestData.CardSecurityCode1, TestData.MCZIP);
                    NM.TermsAndConditions();
                    NM.CompletePurchase();

                    Utils.WaitForElement(driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("(//h2[@class= 'top'])[1]")));

                    string Expected = "Thank you for your purchase.";
                    string Actual = NM.GetSuccessMessage().Text;

                    Assert.AreEqual(Expected, Actual);
                    test.Log(Status.Pass, "New Movie Club member is successfully added thru Movie Rewards - Passed");

                }
                catch (Exception e)
                {
                    
                    Assert.Fail();
                    test.Log(Status.Fail, "New Movie Club member -- adding thru Movie Rewards - Failed");



                }


            });
        }

        /* This // test is checking if 9 points are earned when a new movie club member is added  */

        [Test,Order(2)]
        public void MoviePointsTest()
        {
                       
            UITest(() =>
            {

                try
                {

                    string points = TestData.FullMembership;
                    int numberOfPoints = Utils.PointsEarned(points);
                    string Expected = "You earned " + numberOfPoints + " points.";
                    string Actual = NM.GetPointsEarned().Text;

                    Assert.AreEqual(Expected, Actual);
                   test.Log(Status.Pass, "Successfully earned 9 points for a new Club member - Passed");
                }
                catch (Exception e)
                {
                    
                    Assert.Fail();
                    test.Log(Status.Fail, "Earning 9 points for a new Club member - Failed");

                }
            });
           

        }




    }
}
