using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using AventStack.ExtentReports;

//This test creates a new Movie Club Member and then adds 2 tickets to check if Movie credit ,Movie AddOn and Online Fees are displayed correctly

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class BuyATicketUsingNewMCMCreditsTest : BaseTest
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


        /*  This test adds a New MCM & checks if Movie Credit price is applied */

        [Test, Order(1)]
        [Obsolete]
        public void BuyATicketUsingNewMCMCredits()
        {
            test = rep.CreateTest("BuyATicketUsingNewMCMCredits");
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
                MC.UpdateBillingZip("75093");
                NM.CreateAccount();
                NM.AccountInformation(emailId, emailId, "Cinemark1");
                NM.PersonalInformation("Auto", "User", "9721111234", "75093");
                NM.RecurringPaymentInfo(TestData.MCCreditCard,TestData.CardSecurityCode1,TestData.MCZIP);
                NM.TermsAndConditions();
                NM.CompletePurchase();


                NM.ChooseMovie();
                FM.MovieSelection();
                //TS.LocationDropDown1();
                               
                TS.MovieTimeSelection();
                TS.RefreshWindow();

                ST.AddOneTicket();
                ST.AddAnotherTicket();
                ST.AddTicketsToCart();



                string ExpectedMovieCreditTicketPrice = "$" + TestData.MovieCreditTciketPrice;

                Utils.WaitForElement(driver).Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath("(//div[@class='col-xs-4'])[1]"), "$0.00"));
                string ActualMovieCreditTicketPrice = SC.GetMovieCreditTicket().Text;

                Assert.AreEqual(ExpectedMovieCreditTicketPrice, ActualMovieCreditTicketPrice);
                test.Log(Status.Pass, "Buying a ticket using Movie credit - Passed");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Buying a ticket using Movie credit - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();

            }

        }


        /* This test is for Movie Club Add On ticket */

        [Test, Order(2)]
        [Obsolete]
        public void MovieClubAddOnTicket()
        {
            test = rep.CreateTest("MovieClubAddOnTicket");
            try
            {

                string ExpectedMovieClubAddOnTicketPrice = "$" + TestData.MovieClubAddOnTicketPrice;

                Utils.WaitForElement(driver).Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath("(//div[@class='col-xs-4'])[2]"), "$8.99"));
                string ActualMovieClubAddOnTicketPrice = SC.GetMovieClubAddOn().Text;

                Assert.AreEqual(ExpectedMovieClubAddOnTicketPrice, ActualMovieClubAddOnTicketPrice);
                test.Log(Status.Pass, "Add On Ticket Price is correct - Passed");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Add On Ticket Price is correct - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }
        }


        /* This test is for MCM Online fees */

        [Test, Order(3)]
        public void OnLineFeesForMovieClubMember()
        {
            test = rep.CreateTest("OnLineFeesForMovieClubMember");
            try
            {
                string ExpectedOnlineFees = "$" + TestData.MovieClubOnlineFees;
                string ActualOnlineFees = SC.GetMovieClubMemberOnlineFees().Text;

                Assert.AreEqual(ExpectedOnlineFees, ActualOnlineFees);
                test.Log(Status.Pass, "Online fees for Movie Club member is $0.00 - Passed");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Online fees for Movie Club member is $0.00 - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }
        }





    }
}
