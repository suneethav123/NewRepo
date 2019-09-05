using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;


/*  This test cancels full movie club membership*/

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class CancelFullMovieClubMembershipTest :BaseTest
    {
        
        private HomePage HP;
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private NewMovieClubSignIn NM;
        private MovieRewardsPage MRP;
        private string emailId;

        [Test, Order(1)]
        [Obsolete]
        public void CancelFullMembership()
        {
            test = rep.CreateTest("CancelFullMembership");
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
                MRP.CancelFullMembership();
                MRP.WaitToGetSuccessMessage();

                string ExpectedMemberStatusMsg = "We're sorry to see you go.";
                string ActualMemberStatusMsg = MRP.GetMemberStatusHeadLine().Text;

                Assert.AreEqual(ExpectedMemberStatusMsg, ActualMemberStatusMsg);

                test.Log(Status.Pass, "Cancelled Movie Club Full membership - Passed");

            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Cancelled Movie Club Full membership - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();

            }

        }
    }
}
