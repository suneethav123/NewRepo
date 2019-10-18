using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;

/* This test is to register a new account thru Movie Rewards link -> Join Now
 * 
 */

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class AddNewMovieFanThruMovieRewardsTest:BaseTest
    {
        private HomePage HP;
        private MovieRewardsInfoPage MR;
        private RegisterANewAcctPage RN;
        private string emailId;

        /* This test is to register a new account thru Movie Rewards link -> Join Now */

        [Test]
        [Obsolete]
        public void RegisterNewAccount()
        {
            test = rep.CreateTest("RegisterNewAccount");
            try
            {

                HP = new HomePage(driver);
                MR = new MovieRewardsInfoPage(driver);
                RN = new RegisterANewAcctPage(driver);

                emailId = Utils.GenerateUser();

                HP.GoToMovieRewards();
                MR.JoinNowLink();
                RN.RegisterNewAcct(emailId, "Cinemark1", "Cinemark1", "Auto", "Test", "9721231234", "75093");

                string ExpectedMessage = "Email Verification Link Sent";
                string ActualMessage = RN.GetMessageEmailVerificationText().Text;

                Assert.AreEqual(ExpectedMessage, ActualMessage);
                test.Log(Status.Pass, "Registered a new Movie Fan account thru Movie Rewards link - Passed");
            }
            catch(Exception e)
            {
                CloseBrowser();
                test.Log(Status.Fail, "Registered a new Movie Fan account thru Movie Rewards link - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
                           

            }
        }


    }
}
