using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Register the Stub Account thru Checkout

namespace Cinemark.com.cinemark.testscripts.Other
{[TestFixture]
    class CreateStubAcctRegisterThruCheckoutTest :BaseTest
    {

        private HomePage HP;
        private FeaturedMovies FM;
        private TimeSlots TS;
        private SelectTickets ST;
        private ShoppingCart SC;
        private ShoppingCartGuestCheckout SCG;
        private NewMovieClubSignIn NM;
        private string email;

        [Test,Order(1)]
        [Obsolete]
        public void StubAcctRegisterThruCheckout()
        {
            HP = new HomePage(driver);
            FM = new FeaturedMovies(driver);
            TS = new TimeSlots(driver);
            ST = new SelectTickets(driver);
            SC = new ShoppingCart(driver);
            SCG = new ShoppingCartGuestCheckout(driver);
            NM = new NewMovieClubSignIn(driver);

            email = Utils.GenerateUser();

            // Stub Account created

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

            // Stub Account registered thru Checkout 
            HP.GoToMovies();
           
            FM.MovieSelection();

           // Utils.WaitForElement(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(By.LinkText("featured")));


            TS.MovieTimeSelection();
            Utils.WaitForElement(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("showtimeHeaderLabel")));
           
           // Thread.Sleep(5000);
            ST.AddOneTicket();
            ST.AddAnotherTicket();
            ST.AddTicketsToCart();

        }
    }
}
