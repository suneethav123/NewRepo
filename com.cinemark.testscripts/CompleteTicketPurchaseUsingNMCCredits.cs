using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;

/*  This test is to add a new MCM and make a complete purchase for tickets using Movie Credits*/

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class CompleteTicketPurchaseUsingNMCCredits :BaseTest

    {

        private HomePage HP;
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private NewMovieClubSignIn NM;
        private FeaturedMovies FM;
        private TimeSlots TS;
        private SelectTickets ST;
        private ShoppingCart SC;
        private string emailId;

        [Test, Order(1)]
        [Obsolete]
        public void CompleteMoviePurchaseUsingCredits()
        {
            test = rep.CreateTest("CompleteMoviePurchaseUsingCredits");
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

                emailId = Utils.GenerateUser();

                HP.GoToMovieRewards();
                MR.LearnMoreLink();
                MC.UpdateBillingZip(TestData.UpdateBillingZIP);
                NM.CreateAccount();
                NM.AccountInformation(emailId, emailId, "Cinemark1", "Cinemark1");
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
                NM.RecurringPaymentInfo(TestData.TicketPurchaseCreditCard, TestData.CardSecurityCode2, TestData.CreditCardZIP);
                NM.CompletePurchase();
            


                string ExpMsg = "You earned 16 points.";
                string ActMsg = NM.GetPointsEarned().Text;

                Assert.AreEqual(ExpMsg, ActMsg);
                test.Log(Status.Pass, " Purchase tickets using Movie Credits - Passed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, " Purchase tickets using Movie Credits - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }



        }
}
}
