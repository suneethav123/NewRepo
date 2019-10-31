using AventStack.ExtentReports;
using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This // test is to purchase a Reserved Seat for a movie

namespace Cinemark.com.cinemark.testscripts.Purchases
{[TestFixture]
    class ReservedSeatTicketPurchaseTest :BaseTest
    {

        private HomePage HP;
        private FeaturedMovies FM;
        private TimeSlots TS;
        private SelectTickets ST;
        private ReserveYourSeatPage RS;
        private ShoppingCartGuestCheckout SCG;
        private SignInMCM SI;
        private NewMovieClubSignIn NM;
        private GuestServicesPage GS;
        private GuestServicesRefundPage GSR;
        private string email;


        [Test, Order(1)]
        [Obsolete]
        public void ReservedSeatMovieTickets()
        {
            UITest(() =>
            {
                try
            {

                HP = new HomePage(driver);
                FM = new FeaturedMovies(driver);
                TS = new TimeSlots(driver);
                ST = new SelectTickets(driver);
                RS = new ReserveYourSeatPage(driver);
                SCG = new ShoppingCartGuestCheckout(driver);
                SI = new SignInMCM(driver);
                NM = new NewMovieClubSignIn(driver);


                email = Utils.GenerateUser();
                
                HP.GoToSignIn();
                SI.SignInMovieClubmember("AutoTest500@example.com", "Cinemark1");
                Utils.WaitForElement(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(By.LinkText("Sign In")));
                HP.GoToMovies();
                FM.ReservedSeatingMovie();
                TS.ReservedSeatingMovieTimeSelection();
                ST.AddOneTicket();
                ST.AddTicketsToCart();
                RS.SeatSelection();
                RS.ReserveSelectedSeats();
                NM.CompletePurchase();
               

                string ExpectedSuccessMsg = "Thank you for your purchase.";
                string ActualSuccessMsg = NM.GetTicketPurchaseSuccessMsg().Text;

                Assert.AreEqual(ExpectedSuccessMsg, ActualSuccessMsg);
                 test.Log(Status.Pass, "Successfully Seat Reserved   - Passed");
            }
            catch (Exception e)
            {
                 test.Log(Status.Fail, "Successfully Seat Reserved - failed");
               
                Assert.Fail();
                }
            });



        }


        [Test,Order(2)]
        [Obsolete]
        public void RefundReservedSeatTicket()
        {
            UITest(() =>
            {
                try
            {
                GS = new GuestServicesPage(driver);
                GSR = new GuestServicesRefundPage(driver);


                
                HP.GoToGuestServices();
                GS.GoToRefundLink();
                GSR.FirstRefundBtn();
                GSR.SecondRefundBtn();

                string ExpectedMsg = "Your purchase has been refunded.";
                string ActualMsg = GSR.GetRefundSuccessMsg().Text;

                Assert.AreEqual(ExpectedMsg, ActualMsg);
                test.Log(Status.Pass, "Refund Reserved Seat tickets successfully - Passed");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Refund Reserved Seat tickets successfully - Failed");
               
                Assert.Fail();
                }
            });



        }

    }
}
