using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using System.Threading;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;


/* This test cancels Lite movie Club membership */

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class CancelLiteMovieClubMembershipTest :BaseTest
    {
       

        private HomePage HP;
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private NewMovieClubSignIn NM;
        private MovieRewardsPage MRP;
        private string emailId;

        [Test, Order(1)]
        [Obsolete]
        public void CancelLiteMembership()
        {
           test = rep.CreateTest("CancelLiteMovieClubMembershipTest");
            try
            {
                HP = new HomePage(driver);
                MR = new MovieRewardsInfoPage(driver);
                MC = new MovieClub(driver);
                NM = new NewMovieClubSignIn(driver);
                MRP = new MovieRewardsPage(driver);

                emailId = Utils.GenerateUser();

                HP.GoToMovieRewards();
                MR.LearnMoreLink();
                MC.UpdateBillingZip(TestData.UpdateBillingZIP);
                NM.CreateAccount();
                NM.AccountInformation(emailId, emailId, "Cinemark1", "Cinemark1");
                NM.PersonalInformation("Auto", "User", "9721112222", "75093");
                NM.RecurringPaymentInfo(TestData.MCCreditCard, TestData.CardSecurityCode1, TestData.MCZIP);
                NM.TermsAndConditions();
                NM.CompletePurchase();



                HP.GoToMovieRewards();
                MRP.CancelMembership();
                MRP.ChangeToLiteMembership();

                Utils.WaitForElement(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("(//div[contains(@class,'noscroll')])[2]")));
                //Thread.Sleep(5000);
                HP.GoToMovieRewards();
                MRP.CancelMembership();
                MRP.WaitToGetSuccessMessage();

                string ExpectedMemberStatusMsg = "We're sorry to see you go.";
                string ActualMemberStatusMsg = MRP.GetMemberStatusHeadLine().Text;

                Assert.AreEqual(ExpectedMemberStatusMsg, ActualMemberStatusMsg);

                test.Log(Status.Pass, "Cancelled Movie Club Lite membership - Passed");

            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Cancelled Movie Club Lite membership - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();

            }

        }
    }
}
