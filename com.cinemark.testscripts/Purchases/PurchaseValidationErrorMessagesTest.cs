using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;


//  This is a test for missing required fields during ticket purchase


namespace Cinemark.com.cinemark.testscripts.Purchases
{[TestFixture]
    class PurchaseValidationErrorMessagesTest : BaseTest
    {
        private HomePage HP;
        private SignInMCM SI;
        private NewMovieClubSignIn NM;
        private FeaturedMovies FM;
        private TimeSlots TS;
        private SelectTickets ST;
        private ShoppingCart SC;


        //  Missing Credit Card, ZIP, Security code

        [Test,Order(1)]
        [Obsolete]
        public void ErrMsgsForMissingFieldsValuesCardNum()
        {
            test = rep.CreateTest("ErrMsgsForMissingFieldsValuesCardNum");

            try
            {

                SI = new SignInMCM(driver);
                HP = new HomePage(driver);
                NM = new NewMovieClubSignIn(driver);
                FM = new FeaturedMovies(driver);
                TS = new TimeSlots(driver);
                ST = new SelectTickets(driver);
                SC = new ShoppingCart(driver);

                HP.GoToSignIn();
                SI.SignInMovieClubmember(Utils.GetEmailId(), "Cinemark1");
                Utils.WaitForElement(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(By.LinkText("Sign In")));
                HP.GoToMovies();
                FM.MovieSelection();
                TS.MovieTimeSelection();
                ST.AddOneTicket();
                ST.AddAnotherTicket();
                ST.AddTicketsToCart();
                // SC.CCSecurityCode(TestData.CardSecurityCode2);
                SC.CompletePurchase();

                string ExpErrMsgForCCMissing = "The Card Number field is required.";
                string ActErrMsgForCCMissing = SC.GetCreditCardMissingErrMsg().Text;

                string ExpErrMsgForZipMissing = "The Billing ZIP Code field is required.";
                string ActErrMsgForZipMissing = SC.GetZipMissingErrMsg().Text;

                string ExpErrMsgForCodeMissing = "The Card Security Code field is required.";
                string ActErrMsgForCodeMissing = SC.GetSecurityCodeMissingErrMsg().Text;


                Assert.Multiple(() =>
                {
                    Assert.AreEqual(ExpErrMsgForCCMissing, ActErrMsgForCCMissing, "First Assert");
                    Assert.AreEqual(ExpErrMsgForZipMissing, ActErrMsgForZipMissing, "Second Assert");
                    Assert.AreEqual(ExpErrMsgForCodeMissing, ActErrMsgForCodeMissing, "Third Assert");
                });

                test.Log(Status.Pass, "Error messages displayed for missing Credit Card,ZIP & Security Code - Passed");
            }
            catch(Exception e)
            {
                test.Log(Status.Pass, "Error messages displayed for missing Credit Card,ZIP & Security Code - Passed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }
        }



        // Missing Card Number only

        [Test, Order(2)]
        public void ErrorMsgForMissingCCardInfo()
        {
            test = rep.CreateTest("MissingCreditCardInfo");

            try
            {
                SC.CCSecurityCode(TestData.CardSecurityCode2);
                SC.BillingZipCode(TestData.CreditCardZIP);
                SC.CompletePurchase();

                string ExpectedErrMsg = "The Card Number field is required.";
                string ActualErrMsg = SC.GetErrorMessage().Text;

                Assert.AreEqual(ExpectedErrMsg, ActualErrMsg);

                test.Log(Status.Pass, "Error Message displayed for missing Credit Card - Passed");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Error Message displayed for missing Credit Card - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }
        }


        // Missing Billing ZIP 

        [Test, Order(3)]
        public void ErrorMsgForMissingZIPInfo()
        {
            test = rep.CreateTest("ErrorMsgForMissingZIPInfo");
            try
            {
                SC.CreditCardNum(TestData.TicketPurchaseCreditCard);
                SC.ClearBillingZip();
                SC.CCSecurityCode(TestData.CardSecurityCode2);
                SC.CompletePurchase();

                string ExpectedErrMsg = "The Billing ZIP Code field is required.";
                string ActualErrMsg = SC.GetErrorMessage().Text;

                Assert.AreEqual(ExpectedErrMsg, ActualErrMsg);

                test.Log(Status.Pass, "Error Message displayed for missing Billing Zipcode - Passed");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Error Message displayed for missing Billing Zipcode - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }
        }


        // Missing Credit Card & ZIP

        [Test, Order(4)]
        public void ErrorMsgForMissingCCAndZIPInfo()
        {
            test = rep.CreateTest("ErrorMsgForMissingCCAndZIPInfo");
            try
            {
                SC.ClearCreditcardNum();
                SC.ClearBillingZip();
                SC.CCSecurityCode(TestData.CardSecurityCode2);
                SC.CompletePurchase();
                               
                Boolean ErrMessageMissingCCZip = SC.GetValidationErrMsgs().Text.Contains("The Billing ZIP Code field is required.");

                Assert.True(ErrMessageMissingCCZip);
                test.Log(Status.Pass, "Error Message displayed for missing Credit Card Info and Billing Zipcode - Passed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Error Message displayed for missing Credit Card Info and Billing Zipcode - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }

        }




    }
}
