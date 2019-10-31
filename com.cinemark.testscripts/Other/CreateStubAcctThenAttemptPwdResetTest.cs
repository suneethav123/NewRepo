using AventStack.ExtentReports;
using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;

// This // test covers Stub account creation & request to password reset 
// User should not receive an email when a password reset request is sent

namespace Cinemark.com.cinemark.testscripts.Other
{[TestFixture]
    class CreateStubAcctThenAttemptPwdResetTest :BaseTest
    {
        private HomePage HP;
        private FeaturedMovies FM;
        private TimeSlots TS;
        private SelectTickets ST;
        private ShoppingCart SC;
        private ShoppingCartGuestCheckout SCG;
        private NewMovieClubSignIn NM;
        private SignInMCM SI;
        private ResetPasswordPage RP;
        private string email;

        [Test,Order(1)]
        [Obsolete]
        public void CreateStubAcctThenAttemptPwdReset()
        {
            UITest(() =>
            {
                try
            {
                HP = new HomePage(driver);
                FM = new FeaturedMovies(driver);
                TS = new TimeSlots(driver);
                ST = new SelectTickets(driver);
                SC = new ShoppingCart(driver);
                SCG = new ShoppingCartGuestCheckout(driver);
                NM = new NewMovieClubSignIn(driver);
                SI = new SignInMCM(driver);
                RP = new ResetPasswordPage(driver);

                email = Utils.GenerateUser();

                HP.GoToMovies();
                FM.MovieSelection();
                TS.LocationDropDown1();
                TS.MovieTimeSelection();
                ST.AddOneTicket();
                ST.AddAnotherTicket();
                ST.AddTicketsToCart();               
                SCG.GuestCheckOut(email);
                NM.RecurringPaymentInfo(TestData.TicketPurchaseCreditCard, TestData.CardSecurityCode2, TestData.CreditCardZIP);
                NM.CompletePurchase();

                HP.GoToSignIn();
                SI.ResetPasswordLnk();                
                RP.ResetPassword(Utils.GetEmailId());


                string ExpectedMsg = "Check Your Email to Continue";
                string ActualMsg = RP.GetResetMsg().Text;

                Assert.AreEqual(ExpectedMsg, ActualMsg);
                 test.Log(Status.Pass, "Reset Password link is not sent to the Stub account customer - Passed");
            }
            catch(Exception e)
            {
                 test.Log(Status.Fail, "Reset Password link is not sent to the Stub account customer - Failed");
               
                Assert.Fail();
                }
            });


        }
    }
}
