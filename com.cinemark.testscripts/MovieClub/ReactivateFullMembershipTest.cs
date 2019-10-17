using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;

/* This test reactivates a full movie club membership.
 * Initially the membership is cancelled ,user does not log out  but  Reactivates membership*/

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class ReactivateFullMembershipTest :BaseTest
    {

        private HomePage HP;
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private NewMovieClubSignIn NM;
        private MovieRewardsPage MRP;
        private string emailId;

        [Test, Order(1)]
        [Obsolete]
        public void ReactivateFullMembership()
        {
            test = rep.CreateTest("ReactivateFullMembership");
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
                NM.AccountInformation(emailId, emailId, "Cinemark1");
                NM.PersonalInformation("Auto", "User", "9721112222", "75093");
                NM.RecurringPaymentInfo(TestData.MCCreditCard, TestData.CardSecurityCode1, TestData.MCZIP);
                NM.TermsAndConditions();
                NM.CompletePurchase();

                HP.GoToMovieRewards();
                MRP.CancelMembership();
                MRP.CancelFullMembership();
                MRP.ReactivateMbrship();
                MRP.WaitToGetSuccessMessage();


                Boolean SuccessMessage = MRP.GetMemberStatusHeadLine().Text.Contains("We");
                Assert.True(SuccessMessage);

                test.Log(Status.Pass, "Movie Club - Reactivate into Movie Club (full) Passed");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Movie Club - Reactivate into Movie Club (full) Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }

        }

        
    }
}
