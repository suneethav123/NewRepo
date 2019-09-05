using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using AventStack.ExtentReports;

/*  Using the Movie Club Membership gift card to redeem movie credits*/

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class BuyTicketsUsingGiftedCredits :BaseTest
    {
        private HomePage HP;
        private GiftsPage GP;
        private MovieClubGiftMembershipPage MCG;
        private ShoppingCartGuestCheckout SCG;
        private NewMovieClubSignIn NM;
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private MovieRewardsPage MP;
        private FeaturedMovies FM;
        private TimeSlots TS;
        private SelectTickets ST;
        private ShoppingCart SC;

        private string email;
        private string code;


        /*  Below test is to purchase a Movie Club Membership gift card */

        [Test, Order(1)]
        [Obsolete]
        public void GiftCardPurchaseMCM()
        {
            test = rep.CreateTest("GiftCardPurchaseMCM");
            try
            {
                HP = new HomePage(driver);
                GP = new GiftsPage(driver);
                MCG = new MovieClubGiftMembershipPage(driver);
                SCG = new ShoppingCartGuestCheckout(driver);
                NM = new NewMovieClubSignIn(driver);

                email = Utils.GenerateUser();

                HP.GoToGifts();
                GP.MovieClubGiftMembership();
                MCG.BuyGiftMembership("John Doe", email, "Enjoy!!!");
                SCG.GuestCheckOut(email);
                NM.RecurringPaymentInfo("4111111111111111", "111", "75093");
                NM.TermsAndConditions();
                NM.CompletePurchase();

                string ExpectedSuccessMsg = "Thank you for your purchase.";
                string ActualSuccessMsg = NM.GetTicketPurchaseSuccessMsg().Text;

                code = NM.GetRecipientGiftCode().Text;

                Assert.AreEqual(ExpectedSuccessMsg, ActualSuccessMsg);
                test.Log(Status.Pass, "Successful Movie Club Gift Membership card Purchase - Passed");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Successful Movie Club Gift Membership card Purchase - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();

            }
        }


        /*  Below test is to add a new Movie Club member without using Movie Club Membership gift card */

        [Test, Order(2)]
        [Obsolete]
        public void AddingNMCMemberThruMovieRewards()
        {
            test = rep.CreateTest("AddingNMCMemberThruMovieRewards");
            try
            {

                HP = new HomePage(driver);
                MR = new MovieRewardsInfoPage(driver);
                MC = new MovieClub(driver);
                NM = new NewMovieClubSignIn(driver);

                email = Utils.GenerateUser();

                HP.GoToMovieRewards();
                MR.LearnMoreLink();
                MC.UpdateBillingZip(TestData.UpdateBillingZIP);
                NM.CreateAccount();
                NM.AccountInformation(email, email, "Cinemark1", "Cinemark1");
                NM.PersonalInformation("Auto", "User", "9721112222", "75093");
                NM.RecurringPaymentInfo(TestData.MCCreditCard, TestData.CardSecurityCode1, TestData.MCZIP);
                NM.TermsAndConditions();
                NM.CompletePurchase();


                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("(//h2[@class= 'top'])[1]")));

                string ExpectedMsg = "Thank you for your purchase.";
                string ActualMsg = NM.GetSuccessMessage().Text;

                Assert.AreEqual(ExpectedMsg, ActualMsg);

                test.Log(Status.Pass, "New Movie Club member added without using Movie Club Membership gift card - Passed");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "New Movie Club member added without using Movie Club Membership gift card - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }
        }

        
        /* Buying 2 tickets using the credits*/

        [Test, Order(3)]
        [Obsolete]
        public void BuyTicketsUsingCredits()
        {
            test = rep.CreateTest("BuyTicketsUsingCredits");
            try
            {
                MP = new MovieRewardsPage(driver);
                FM = new FeaturedMovies(driver);
                TS = new TimeSlots(driver);
                ST = new SelectTickets(driver);
                SC = new ShoppingCart(driver);

                HP.GoToMovieRewards();
                MP.RedeemMovieClubGiftCode(code);

                

                Utils.WaitForElement(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("(//div[contains(@class,'noscroll')])[1]")));
                HP.GoToMovies();
                FM.MovieSelection();
                TS.MovieTimeSelection();
                ST.AddOneTicket();
                ST.AddAnotherTicket();
                ST.AddTicketsToCart();
                NM.RecurringPaymentInfo(TestData.TicketPurchaseCreditCard, TestData.CardSecurityCode2, TestData.CreditCardZIP);
                NM.CompletePurchase();

                string ExpectedSuccessMsg = "Thank you for your purchase.";
                string ActualSuccessMsg = NM.GetTicketPurchaseSuccessMsg().Text;

                Assert.AreEqual(ExpectedSuccessMsg, ActualSuccessMsg);
                test.Log(Status.Pass, "Buy ticket using credits recieved from  Movie Club Membership gift card - Passed");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Buy ticket using credits recieved from  Movie Club Membership gift card - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }
        }

    }
}
