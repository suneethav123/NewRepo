using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This test is to purchase Supersavers

namespace Cinemark.com.cinemark.testscripts.Purchases
{[TestFixture]
    class SupersaversPurchaseTest :BaseTest
    {
        private HomePage HP;
        private SupersaversPage SS;
        private ShoppingCartGuestCheckout SG;
        private ShoppingCart SC;
        private NewMovieClubSignIn NM;


        [Test, Order(1)]
        [Obsolete]
        public void MinimumSupersaversPurchase()
        {
            HP = new HomePage(driver);
            SS = new SupersaversPage(driver);
            SG = new ShoppingCartGuestCheckout(driver);
            SC = new ShoppingCart(driver);

            HP.GoToDiscounts();
            SS.SupersaversLink();
            SS.SupersaversPurchase("49");

            string ExpectedMsg = "There is a minimum of 50 supersavers, and you have added only 49 of Platinum Supersavers. Please add more Platinum Supersavers.";
            string ActualMsg = SS.GetErrorMessage().Text;

            Assert.AreEqual(ExpectedMsg, ActualMsg);


        }

        [Test,Order(2)]
        [Obsolete]
        public void PurchaseSupersavers()
        {
            NM = new NewMovieClubSignIn(driver);

            HP.GoToDiscounts();
            SS.SupersaversLink();
            SS.SupersaversPurchase("50");
            SG.GuestCheckOut("yjanagama+41@gmail.com");
            NM.RecurringPaymentInfo(TestData.TicketPurchaseCreditCard, TestData.CardSecurityCode2, TestData.CreditCardZIP);
            SC.ShippingInfo("1000 Long Dr", "Dallas", "75022", "John", "Doe", "9729998888");
            SC.CompletePurchase();

            string ExpectedMsg = "Thank you for your purchase.";
            string ActualMsg = NM.GetTicketPurchaseSuccessMsg().Text;

            Assert.AreEqual(ExpectedMsg, ActualMsg);
        }


    }
}
