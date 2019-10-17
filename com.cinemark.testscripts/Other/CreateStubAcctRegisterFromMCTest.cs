using AventStack.ExtentReports;
using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;



//Create stub account, then register from Movie Club page

namespace Cinemark.com.cinemark.testscripts.Other
{[TestFixture]
    class CreateStubAcctRegisterFromMCTest : BaseTest
    {
        private HomePage HP;
        private FeaturedMovies FM;
        private TimeSlots TS;
        private SelectTickets ST;
        private ShoppingCart SC;
        private ShoppingCartGuestCheckout SCG;
        private NewMovieClubSignIn NM;
        private string email;

        private MovieRewardsInfoPage MR;
        private MovieClub MC;


        [Test, Order(1)]
        [Obsolete]
        public void StubAcct()
        {
            test = rep.CreateTest("StubAcct");
            try
            {
                HP = new HomePage(driver);
                FM = new FeaturedMovies(driver);
                TS = new TimeSlots(driver);
                ST = new SelectTickets(driver);
                SC = new ShoppingCart(driver);
                SCG = new ShoppingCartGuestCheckout(driver);
                NM = new NewMovieClubSignIn(driver);
                MR = new MovieRewardsInfoPage(driver);
                MC = new MovieClub(driver);

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

                // Registered Stub Account thru Movie Club

                HP.GoToMovieRewards();
                MR.LearnMoreLink();
                MC.UpdateBillingZip(TestData.UpdateBillingZIP);
                NM.CreateAccount();
                NM.AccountInformation(email, email, "Cinemark1");
                NM.PersonalInformation("Auto", "User", "9721112222", "75093");
                NM.RecurringPaymentInfo(TestData.MCCreditCard, TestData.CardSecurityCode1, TestData.MCZIP);
                NM.TermsAndConditions();
                NM.CompletePurchase();

                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("(//h2[@class= 'top'])[1]")));

                string ExpectedMsg = "Thank you for your purchase.";
                string ActualMsg = NM.GetSuccessMessage().Text;

                Assert.AreEqual(ExpectedMsg, ActualMsg);
                test.Log(Status.Pass, "Stub Acct is converted to Movie Club member thru Movie Rewards - Passed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Stub Acct is converted to Movie Club member thru Movie Rewards - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }

        }
    }
}
