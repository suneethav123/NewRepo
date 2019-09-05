using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Threading;

// Making sure Terms & Conditions are displayed when Movie Club user logs in after a long time

namespace Cinemark.com.cinemark.testscripts
{[TestFixture]
    class SignInMCMWithTAndCTest :BaseTest
    {
        private HomePage HP;
        private SignInMCM SI;

        [Test,Order(1)]
        [Obsolete]
        public void SignInWithTermsConditions()
        {
            test = rep.CreateTest("SignInWithTermsConditions");
            try
            {
                HP = new HomePage(driver);
                SI = new SignInMCM(driver);

                HP.GoToSignIn();
                SI.SignInMovieClubmember("yjanagama+5@gmail.com", "cinemark1");
                Utils.WaitForElement(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("signInButton")));
                Thread.Sleep(5000);
                SI.AgreeButton();
                SI.PolicyButton();

                string ExpectedText = "Your Account";
                string ActualText = HP.GetYourAccountLink().Text;

                Assert.AreEqual(ExpectedText, ActualText);
                test.Log(Status.Pass, "Existing Member is able to sign in successfully Passed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Existing Member is able to sign in successfully Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }

        }

    }
}
