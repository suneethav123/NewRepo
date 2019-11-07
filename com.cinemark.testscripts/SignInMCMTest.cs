using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;

// This // test is to check if a Member is able to sign in

namespace Cinemark.com.cinemark.testscripts
{
    class SignInMCMTest :BaseTest
    {

        private HomePage HP;
        private ConnectionHomePage CH;
        private SignInMCM SI;
        private MovieRewardsFeaturedRewards CO;


        [Test]
        [Retry(2)]
        [Obsolete]
        public void SignInMovieClubMemberTest()
        {
            UITest(() =>
            {

                try
            {
                HP = new HomePage(driver);
                SI = new SignInMCM(driver);
                CH = new ConnectionHomePage(driver);
                CO = new MovieRewardsFeaturedRewards(driver);

                

                HP.GoToMovieRewards();
                CH.SignInThruConnections();
                SI.SignInMovieClubmember(Utils.GetEmailId(), "Cinemark1");

                string ExpectedText = "Your Account";
                string ActualText = CO.GetYourAccountLink().Text;

                Assert.AreEqual(ExpectedText, ActualText);
                 test.Log(Status.Pass, "Existing Member is able to sign in successfully Passed");
            }
            catch (Exception e)
            {
                 test.Log(Status.Fail, "Existing Member is able to sign in successfully Failed");
                
                Assert.Fail();
                }
            });

        }

    }
}
