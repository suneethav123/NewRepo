using AventStack.ExtentReports;
using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


//This test checks if an existing  Movie Club Member email can be registered again thru Registration page

namespace Cinemark.com.cinemark.testscripts.Other
{
    [TestFixture]
    class RegisterDuplicateAcctFromRegistrationTest : BaseTest
    {
        private HomePage HP;
        private SignInMCM SI;
        private RegisterANewAcctPage RN;

        


        [Test, Order(1)]
        [Obsolete]
        public void RegisterDuplicateAccount()
        {
            test = rep.CreateTest("RegisterDuplicateAccount");
            try
            {
                HP = new HomePage(driver);
                SI = new SignInMCM(driver);
                RN = new RegisterANewAcctPage(driver);




                HP.GoToSignIn();
                SI.Register();
                RN.RegisterDuplicateNewAcct(Utils.GetEmailId(), "Cinemark1", "Cinemark1", "Auto", "User", "9721112222", "75093");

                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#registrationForm > div.validation-summary-errors")));

                string ExpectedErrMessage = "There was a problem creating your account. Check that your email address was entered correctly. If you think you may already have an account, you can try resetting your password.";


                string ActualErrMessage = SI.GetErrMsgDuplicateAcct().Text;


                Assert.AreEqual(ExpectedErrMessage, ActualErrMessage);
                test.Log(Status.Pass, "Existing Movie Club Member restricted not to be added - Passed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Existing Movie Club Member restricted not to be added - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }
}
    }
}
