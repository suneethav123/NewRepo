using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;
using System.Threading;


/*  This // test User's MC membership is cancelled ,logs out & then logs back in and Reactivates the membership*/

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class LogOutAndLogBackInReactivateFullMembershipTest :BaseTest
    {
        private HomePage HP;
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private NewMovieClubSignIn NM;
        private MovieRewardsPage MRP;
        private SignInMCM SI;
        private string emailId;

        [Test, Order(1)]
        [Obsolete]
        public void ReactivateFullMembershipLoggingBackIn()
        {
            UITest(() =>
            {
                try
            {
                HP = new HomePage(driver);
                MR = new MovieRewardsInfoPage(driver);
                MC = new MovieClub(driver);
                NM = new NewMovieClubSignIn(driver);
                MRP = new MovieRewardsPage(driver);
                SI = new SignInMCM(driver);

                emailId = Utils.GenerateUser();

                HP.GoToMovieRewards();
                MR.LearnMoreLink();
                MC.UpdateBillingZip(TestData.UpdateBillingZIP);
                NM.CreateAccount();
                NM.AccountInformation(emailId, emailId, "Cinemark1");
                NM.PersonalInformation("Auto", "User", "9721112222", "75093");
                NM.RecurringPaymentInfo(TestData.MCCreditCard, TestData.CardSecurityCode1, TestData.MCZIP);
                NM.TermsAndConditions();
                NM.CompletePurchase();

                HP.GoToMovieRewards();
                MRP.CancelMembership();
                MRP.CancelFullMembership();
                HP.SignOut();
                SI.SignInMovieClubmember(emailId, "Cinemark1");
                MRP.ManageYourMembership();
               
                MRP.ReactivateMbrship();
                MRP.WaitToGetSuccessMessage();


                Boolean SuccessMessage = MRP.GetMemberStatusHeadLine().Text.Contains("We");
                Assert.True(SuccessMessage);
               test.Log(Status.Pass, "Reactivating Movie Club membership by logging out and logging back in - Passed");
            }
            catch (Exception e)
            {
               test.Log(Status.Fail, "Reactivating Movie Club membership by logging out and logging back in - Failed");
               
                Assert.Fail();
                }
            });

        }
    }
}
