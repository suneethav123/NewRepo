using AventStack.ExtentReports;
using Cinemark.com.cinemark.pages;
using Cinemark.DataBase;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// This  test Purchases a ticket using Supersavers and Gift card
// Going again 

namespace Cinemark.com.cinemark.testscripts.Purchases
{[TestFixture]
    class TicketPurchUsingSupersaverAndGiftCardTest : BaseTest
    {

        private HomePage HP;
        private MovieRewardsInfoPage MR;
        private SignInMCM SI;
        private FeaturedMovies FM;
        private TimeSlots TS;
        private SelectTickets ST;
        private ShoppingCart SC;
        private NewMovieClubSignIn NM;
        private GuestServicesPage GS;
        private ShoppingCartGiftCard SCG;
        private ShoppingCartSupersavers SS;
        private CouponCode CC;

        [Test, Order(1)]
        [Obsolete]
        public void TicketPurchaseUsingSupersaverAndGiftCard()
        {
            UITest(() =>
            {

                try
            {
                HP = new HomePage(driver);
                MR = new MovieRewardsInfoPage(driver);
                SI = new SignInMCM(driver);
                FM = new FeaturedMovies(driver);
                TS = new TimeSlots(driver);
                ST = new SelectTickets(driver);
                SC = new ShoppingCart(driver);
                SCG = new ShoppingCartGiftCard(driver);
                SS = new ShoppingCartSupersavers(driver);
                CC = ReadDB.FetchInfo();

                NM = new NewMovieClubSignIn(driver);



                HP.GoToSignIn();
                //MR.SignInLink();
                SI.SignInMovieClubmember("AutoTest1010@example.com", "cinemark1");
                Utils.WaitForElement(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(By.LinkText("Sign In")));

                //SI.SignInMovieClubmember("yjanagama+50@gmail.com", "cinemark1");
                
                // if (SI.GetAgreeBtn().Displayed){
                //      SI.AgreeButton();
                //      SI.AgreeButton();
                //  } 


                HP.GoToMovies();
                FM.MovieSelection();
                TS.MovieTimeSelection();
                ST.AddOneTicket();
                ST.AddAnotherTicket();
                ST.AddTicketsToCart();
                SS.SupersaversCode(CC.SerialNum, CC.SeqNo);
                SCG.GiftCardArrowDownClick();
                SCG.SelectGiftCard();

                ST.CompletePurchase();

                string ExpectedMsg = "Thank you for your purchase.";
                string ActualMsg = NM.GetTicketPurchaseSuccessMsg().Text;

                Assert.AreEqual(ExpectedMsg, ActualMsg);
                 test.Log(Status.Pass, "Successfully purchased tickets using Supersavers & Gift Card - Passed");

            }
            catch (Exception e)
            {
                 test.Log(Status.Fail, "Successfully purchased tickets using Supersavers & Gift Card - Failed");
                
                Assert.Fail();
                }
            });



        }

        


        
        
    }
}
