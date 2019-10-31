using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Cinemark.DataBase;

// This // test purchases a ticket using SuperSaver Code

namespace Cinemark.com.cinemark.testscripts.Purchases
{[TestFixture]
    class TicketPurchaseUsingSupersaverTest :BaseTest
    {

        private HomePage HP;
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private NewMovieClubSignIn NM;
        private FeaturedMovies FM;
        private TimeSlots TS;
        private SelectTickets ST;
        private ShoppingCart SC;
        private ShoppingCartSupersavers SS;
        private GuestServicesPage GS;
        private GuestServicesRefundPage GSR;
        private string emailId;
        private CouponCode CC;


        [Test, Order(1)]
        [Obsolete]
        public void TicketPurchaseUsingSuperSavers()
        {
            UITest(() =>
            {
                try
            {

                HP = new HomePage(driver);
                MR = new MovieRewardsInfoPage(driver);
                MC = new MovieClub(driver);
                NM = new NewMovieClubSignIn(driver);
                FM = new FeaturedMovies(driver);
                TS = new TimeSlots(driver);
                ST = new SelectTickets(driver);
                SC = new ShoppingCart(driver);
                SS = new ShoppingCartSupersavers(driver);
                CC = ReadDB.FetchInfo();

                emailId = Utils.GenerateUser();

                HP.GoToMovieRewards();
                MR.LearnMoreLink();
                MC.UpdateBillingZip("75093");
                NM.CreateAccount();
                NM.AccountInformation(emailId, emailId, "Cinemark1");
                NM.PersonalInformation("Auto", "User", "9721111234", "75093");
                NM.RecurringPaymentInfo(TestData.MCCreditCard, TestData.CardSecurityCode1, TestData.MCZIP);
                NM.TermsAndConditions();
                NM.CompletePurchase();


                NM.ChooseMovie();
                FM.MovieSelection();
                TS.MovieTimeSelection();
                ST.AddOneTicket();
                ST.AddAnotherTicket();
                ST.AddTicketsToCart();
                SS.SupersaversCode(CC.SerialNum,CC.SeqNo);
                //SS.SupersaversCode("88385-0629-1626P", "1538");
                NM.RecurringPaymentInfo(TestData.TicketPurchaseCreditCard, TestData.CardSecurityCode2, TestData.CreditCardZIP);
                SC.CompletePurchase();



                string ExpectedSuccessMsg = "Thank you for your purchase.";
                string ActualSuccessMsg = NM.GetTicketPurchaseSuccessMsg().Text;

                Assert.AreEqual(ExpectedSuccessMsg, ActualSuccessMsg);
                 test.Log(Status.Pass, "Successfully Ticket purchased using Supersaver - Passed");
            }
            catch(Exception e)
            {
                 test.Log(Status.Fail, "Successfully Ticket purchased using Supersaver - Failed");
             
                Assert.Fail();
                }
            });




        }

        


        
    }
}
