using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using AventStack.ExtentReports;

/*  This test reactivates Lite Movie Club membership */

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class ReactivateLiteMembershipTest :BaseTest
    {

        private HomePage HP;
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private NewMovieClubSignIn NM;
        private MovieRewardsPage MRP;
        private string emailId;

        [Test ,Order(1)]
        [Obsolete]
        public void ReactivateLiteMCMember()
        {
            test = rep.CreateTest("ReactivateLiteMCMember");

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
                

                HP.GoToMovieRewards();
                MRP.CancelMembership();
                MRP.WaitToGetSuccessMessage();
                MRP.ReactivateMbrship();
                MRP.WaitToGetSuccessMessage();

                Boolean SuccessMessage = MRP.GetMemberStatusHeadLine().Text.Contains("We");

                Assert.True(SuccessMessage);

                test.Log(Status.Pass, "Movie Club - Reactivate to Movie Club Lite Passed");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Movie Club - Reactivate to Movie Club Lite Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }
        }

    }
}
