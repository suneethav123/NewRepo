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

namespace Cinemark.com.cinemark.testscripts.Purchases
{[TestFixture]
    class VisaCheckoutPurchaseTest :BaseTest
    {
        private HomePage HP;
        private SignInMCM SI;
        private NewMovieClubSignIn NM;
        private FeaturedMovies FM;
        private TimeSlots TS;
        private SelectTickets ST;
        private ShoppingCart SC;
        private ShoppingCartVisaCheckoutPage SVC;


        [Test, Order(1)]
        [Obsolete]
        public void VisaCheckoutPurchase()
        {
            SI = new SignInMCM(driver);
            HP = new HomePage(driver);
            NM = new NewMovieClubSignIn(driver);
            FM = new FeaturedMovies(driver);
            TS = new TimeSlots(driver);
            ST = new SelectTickets(driver);
            SC = new ShoppingCart(driver);
            SVC = new ShoppingCartVisaCheckoutPage(driver);

            HP.GoToSignIn();
            SI.SignInMovieClubmember("yjanagama+45@gmail.com", "Cinemark1");
            Utils.WaitForElement(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(By.LinkText("Sign In")));
            HP.GoToMovies();
            FM.MovieSelection();
            TS.MovieTimeSelection();
            ST.AddOneTicket();
            ST.AddAnotherTicket();
            ST.AddTicketsToCart();
            SVC.VisaCheckout();
            SVC.SwitchToFrame();
            //SVC.NewVisaCheckout();
            SVC.ReturningVisaCheckoutCust();

            Thread.Sleep(5000);
            SVC.ReturningEmailId("yjanagama+45@gmail.com");

            Thread.Sleep(5000);
           // SVC.ButtonContinue();

            
        }

    }
}
