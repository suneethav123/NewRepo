﻿using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;
using Cinemark.Reporting;

/* This // test is to register a new account thru Movie Rewards link -> Join Now
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
        [Retry(2)]
        [Obsolete]
        public void RegisterNewAccount()
        {
                      
            UITest(() =>
            {
                try
                {
                    test.Info("Test Case Details --> 1. Go to Homepage  --> 2. go to Movie Rewards --> 3. select a movie reward and  click Join now link --> 4. Register new account by providing details and submit --> 5. 'Email Verification Link Sent' must be displayed");
                    HP = new HomePage(driver);
                    MR = new MovieRewardsInfoPage(driver);
                    RN = new RegisterANewAcctPage(driver);

                    emailId = Utils.GenerateUser();

                    HP.GoToMovieRewards();
                    MR.JoinNowLink();
                    RN.RegisterNewAcct(emailId, emailId, "Cinemark1", "Auto", "Test", "9721231234", "75093");

                    string ExpectedMessage = "Email Verification Link Sent";
                    string ActualMessage = RN.GetMessageEmailVerificationText().Text;

                    Assert.AreEqual(ExpectedMessage, ActualMessage);
                    test.Log(Status.Pass, "Registering new account - Passed");

                }
                catch (Exception e)
                {

                    Assert.Fail();
                    test.Log(Status.Fail, "Registering new account - failed");


                }
            });
        }


    }


}
