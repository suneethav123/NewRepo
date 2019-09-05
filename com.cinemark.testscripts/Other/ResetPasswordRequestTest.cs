using AventStack.ExtentReports;
using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;


// This test checks an email is sent to the customer with Reset password link

namespace Cinemark.com.cinemark.testscripts.Other
{[TestFixture]
    class ResetPasswordRequestTest :BaseTest
    {
        private HomePage HP;
        private SignInMCM SI;
        private ResetPasswordPage RP;


        [Test, Order(1)]
        [Obsolete]
        public void ResetPasswordRequest()
        {
            test = rep.CreateTest("ResetPasswordRequest");
            try
            {
                HP = new HomePage(driver);
                SI = new SignInMCM(driver);
                RP = new ResetPasswordPage(driver);

                HP.GoToSignIn();
                SI.ResetPasswordLnk();
                RP.ResetPassword(Utils.GetEmailId());


                string ExpectedMsg = "Check Your Email to Continue";
                string ActualMsg = RP.GetResetMsg().Text;

                Assert.AreEqual(ExpectedMsg, ActualMsg);
                test.Log(Status.Pass,"Reset Password link is sent successfully to the customer - Passed");

            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Reset Password link is sent successfully to the customer - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();

            }

        }
    }
}
