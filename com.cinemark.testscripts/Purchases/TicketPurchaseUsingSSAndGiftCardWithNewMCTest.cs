using Cinemark.com.cinemark.pages;
using Cinemark.DataBase;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using AventStack.ExtentReports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This test adds a new Movie Club , Registers a gift card, reloads gift card , purchases movie tickets using supersaver & gift card

namespace Cinemark.com.cinemark.testscripts.Purchases
{[TestFixture]
    class TicketPurchaseUsingSSAndGiftCardWithNewMCTest : BaseTest
    {
        private HomePage HP;
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private NewMovieClubSignIn NM;
        private FeaturedMovies FM;
        private TimeSlots TS;
        private SelectTickets ST;
        private ShoppingCart SC;
        private GuestServicesPage GS;
        private GuestServicesRegisterGiftCardPage GSR;
        private PurchaseConfirmationPage PC;
        private GiftCardCode GCC;
        private GiftCardPage GC;
        private ReloadGiftCardPage RL;
        private CouponCode CC;
        private ShoppingCartSupersavers SS;
        private ShoppingCartGiftCard SCG;
        private string emailId;

        [Obsolete]
        [Test, Order(1)]
        public void TicketPurchaseUsingSSAndGiftCard()
        {
            test = rep.CreateTest("TicketPurchaseUsingSSAndGiftCard");
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
                GS = new GuestServicesPage(driver);
                GSR = new GuestServicesRegisterGiftCardPage(driver);
                PC = new PurchaseConfirmationPage(driver);
                GC = new GiftCardPage(driver);
                RL = new ReloadGiftCardPage(driver);
                SS = new ShoppingCartSupersavers(driver);
                SCG = new ShoppingCartGiftCard(driver);
                GCC = ReadDBForGiftCard.FetchInfo();
                CC = ReadDB.FetchInfo();

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
                GSR.RegisterGiftCard("GiftCardOne", GCC.gc_id);

                // Reloading Gift card
                GC.ReloadButton();
                RL.ReloadGC("50");
                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementExists(By.XPath("//input[@class = 'btn cnkBtnPrim btn-flex']")));
                RL.AddToCart();
                NM.RecurringPaymentInfo(TestData.TicketPurchaseCreditCard, TestData.CardSecurityCode2, TestData.CreditCardZIP);
                NM.CompletePurchase();

                // Purchasing movie tickets using Supersavercode & Gift card
                Utils.WaitForElement(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("btnCompletePurchase")));
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
                test.Log(Status.Pass, "Ticket purchase using Supersaver and Gift card successful - Passed");

            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Ticket purchase using Supersaver and Gift card successful - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }

        }
    }
}
