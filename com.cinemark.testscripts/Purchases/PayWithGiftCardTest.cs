using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;
using Cinemark.DataBase;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;


//  This test purchases tickets using a gift card & refunds the tickets amount back to the Giftcard

namespace Cinemark.com.cinemark.testscripts.Purchases
{[TestFixture]
    class PayWithGiftCardTest : BaseTest
    {
        private HomePage HP;
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private NewMovieClubSignIn NM;
        private GuestServicesPage GS;
        private GuestServicesRegisterGiftCardPage GSRG;
        private GiftCardPage GC;
        private ReloadGiftCardPage RL;
       
        private FeaturedMovies FM;
        private TimeSlots TS;
        private SelectTickets ST;
        private ShoppingCart SC;
             
        private ShoppingCartGiftCard SCG;
        private GiftCardCode GCC;
        private GuestServicesRefundPage GSR;
               
        private string emailId;


        // Purchase tickets using Gift Card

        [Test, Order(1)]
        [Obsolete]
        public void TicketPurchaseWithGiftCard()
        {
            test = rep.CreateTest("TicketPurchaseWithGiftCard");
            try
            {
                HP = new HomePage(driver);
                MR = new MovieRewardsInfoPage(driver);
                MC = new MovieClub(driver);
                NM = new NewMovieClubSignIn(driver);
                GS = new GuestServicesPage(driver);
                GSRG = new GuestServicesRegisterGiftCardPage(driver);
                GC = new GiftCardPage(driver);
                RL = new ReloadGiftCardPage(driver);
                
                FM = new FeaturedMovies(driver);
                TS = new TimeSlots(driver);
                ST = new SelectTickets(driver);
                SC = new ShoppingCart(driver);
                SCG = new ShoppingCartGiftCard(driver);
                GCC = ReadDBForGiftCard.FetchInfo();
                               
                emailId = Utils.GenerateUser();




                

                //Adding a new movie club member

                HP.GoToMovieRewards();
                MR.LearnMoreLink();
                MC.UpdateBillingZip(TestData.UpdateBillingZIP);
                NM.CreateAccount();
                NM.AccountInformation(emailId, emailId, "Cinemark1", "Cinemark1");
                NM.PersonalInformation("Auto", "User", "9721111234", "75093");
                NM.RecurringPaymentInfo(TestData.MCCreditCard, TestData.CardSecurityCode1, TestData.MCZIP);
                NM.TermsAndConditions();
                NM.CompletePurchase();

                // Registering Gift card

                HP.GoToGuestServices();
                GS.GoToRegisterGiftCardLink();
                GSRG.RegisterGiftCard("GiftCardOne", GCC.gc_id);

                // Reloading Gift card
                GC.ReloadButton();
                RL.ReloadGC("50");
                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementExists(By.XPath("//input[@class = 'btn cnkBtnPrim btn-flex']")));
                RL.AddToCart();
                NM.RecurringPaymentInfo(TestData.TicketPurchaseCreditCard, TestData.CardSecurityCode2, TestData.CreditCardZIP);
                NM.CompletePurchase();


                // Purchasing tickets using Giftcard
                HP.GoToMovies();
                FM.MovieSelection();
                TS.MovieTimeSelection();
                ST.AddOneTicket();
                ST.AddAnotherTicket();
                ST.AddTicketsToCart();
                SCG.GiftCardArrowDownClick();
                SCG.SelectGiftCard();

                ST.CompletePurchase();

                string ExpectedMsg = "Thank you for your purchase.";
                string ActualMsg = NM.GetTicketPurchaseSuccessMsg().Text;

                Assert.AreEqual(ExpectedMsg, ActualMsg);
                test.Log(Status.Pass, "Successfully purchased tickets using Gift Card - Passed");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Successfully purchased tickets using Gift Card - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }


        }


        //  Refund tickets amount back to Gift Card
        

        [Test, Order(2)]
        [Obsolete]
        public void RefundToGiftCard()
        {

            test = rep.CreateTest("RefundToGiftCard");
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
                test.Log(Status.Pass, "Successfully refunded the tickets amount back to Gift Card - Passed");
            }                      
            catch (Exception e)
            {
                test.Log(Status.Fail, "Successfully refunded the tickets amount back to Gift Card- Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }

        }
    }
    
}
