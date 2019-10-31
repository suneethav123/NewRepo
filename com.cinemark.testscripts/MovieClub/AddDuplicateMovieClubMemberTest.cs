using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;

//This // test checks if an existing  Movie Club Member email can be registered again

namespace Cinemark.com.cinemark.testscripts
{
    class AddDuplicateMovieClubMemberTest: BaseTest
    {


       
        private HomePage HP;
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private NewMovieClubSignIn NM;


        /* This // test is checking that existing user is not added again  */

        [Test]
        [Obsolete]
        public void DuplicateNewClubMemberAdd()
        {

            UITest(() =>
            {
                try
            {
                HP = new HomePage(driver);
                MR = new MovieRewardsInfoPage(driver);
                MC = new MovieClub(driver);
                NM = new NewMovieClubSignIn(driver);

                HP.GoToMovieRewards();
                MR.LearnMoreLink();
                MC.UpdateBillingZip(TestData.UpdateBillingZIP);
                NM.CreateAccount();
                NM.AccountInformation("AutoTest1947348863@example.com", "AutoTest1947348863@example.com", "Cinemark1");
                NM.PersonalInformation("Test", "Auto", "9721111234", "75093");
                NM.RecurringPaymentInfo(TestData.MCCreditCard, TestData.CardSecurityCode1, TestData.MCZIP);
                NM.TermsAndConditions();
                NM.CompletePurchase();



                string ExpMsg = "There was a problem creating your account. Check that your email address was entered correctly. If you think you may already have an account, you can try signing in or resetting your password.";
                string ActMsg = NM.GetMessageForDuplicateUser().Text;

                Assert.AreEqual(ExpMsg, ActMsg);
                test.Log(Status.Pass, "Existing Movie Club Member restricted not to be added - Passed");
            }
            catch(Exception e)
            {
               test.Log(Status.Fail, "Existing Movie Club Member restricted not to be added - Failed");
               Assert.Fail();
            }
            });
        }



       
    }
}
