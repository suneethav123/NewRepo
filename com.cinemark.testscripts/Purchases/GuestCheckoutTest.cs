using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;

//This // test is to buy tickets using Guest check out

namespace Cinemark.com.cinemark.testscripts.Purchases
{
    [TestFixture]
    class GuestCheckoutTest : BaseTest
    {
        private HomePage HP;
        private FeaturedMovies FM;
        private TimeSlots TS;
        private SelectTickets ST;
        private ShoppingCart SC;
        private ShoppingCartGuestCheckout SCG;
        private NewMovieClubSignIn NM;
        private string email;

        [Test, Order(1)]
        [Obsolete]
        public void GuestCheckout()
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

                string ExpectedMsg = "Thank you for your purchase.";
                string ActualMsg = NM.GetTicketPurchaseSuccessMsg().Text;

                Assert.AreEqual(ExpectedMsg, ActualMsg);
                 test.Log(Status.Pass, "Successfully tickets purchased using Guest Checkout - Passed");
            }
            catch(Exception e)
            {
                 test.Log(Status.Fail, "Successfully tickets purchased using Guest Checkout - Failed");
             
                Assert.Fail();
                }
            });


        }
    }
}
