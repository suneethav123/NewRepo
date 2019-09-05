using AventStack.ExtentReports;
using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;


// This test registers a new account using registration page

namespace Cinemark.com.cinemark.testscripts.Other
{[TestFixture]
    class RegisterFromRegistrationTest :BaseTest
    {
        private HomePage HP;
        private SignInMCM SI;
        private RegisterANewAcctPage RN;
        
        private MovieRewardsFeaturedRewards CO;


        [Test, Order(1)]
        [Obsolete]
        public void RegisterAccount()
        {
            test = rep.CreateTest("RegisterAccount");
            try { 
                HP = new HomePage(driver);
                RN = new RegisterANewAcctPage(driver);
                SI = new SignInMCM(driver);
                CO = new MovieRewardsFeaturedRewards(driver);

                String email = Utils.GenerateUser();

                HP.GoToSignIn();
                SI.Register();
                RN.RegisterNewAcct(email, "Cinemark1", "Cinemark1", "Auto", "User", "9721112222", "75093");
                HP.GoToSignIn();
                SI.SignInMovieClubmember(email, "Cinemark1");

                Boolean ResendLink = SI.GetResendLink().Displayed;

                Assert.IsTrue(ResendLink);
                test.Log(Status.Pass, "Registered Account Member successfully thru Registration page - Passed");
            }
            catch(Exception e)
                {
                test.Log(Status.Fail, "Registered Account Member successfully thru Registration page - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
                }
}
    }
}
