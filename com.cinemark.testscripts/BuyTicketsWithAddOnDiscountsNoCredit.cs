using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using System.Threading;
using AventStack.ExtentReports;

/*This test adds a new Movie Club Member and purchases 2 movie tickets ,one with credit and one an add on*/

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class BuyTicketsWithAddOnDiscountsNoCredit: BaseTest
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




        /*This test adds a new Movie Club Member and adds 2 movie tickets */

        [Test ,Order(1)]
        [Obsolete]
        public void AddMCMAddTickets()
        {
            test = rep.CreateTest("AddMCMAddTickets");
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


                string points = TestData.MovieClubAddOnPlusUpgradeCharges;
                int numberOfPoints = Utils.PointsEarned(points);
                string ExpMsg = "You earned " + numberOfPoints + " points.";
                string ActMsg = NM.GetPointsEarned().Text;

                Assert.AreEqual(ExpMsg, ActMsg);
                test.Log(Status.Pass, "2 tickets 1 using movie credit & other Add On purchased - Passed ");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "2 tickets 1 using movie credit & other Add On purchased - Failed ");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }



        }

       

       

        /* This test is to Complete purchase  for 2 Add On tickets */
        [Test ,Order(2)]
        [Obsolete]
        public void CompletePurchaseAddOnTickets()
        {
            test = rep.CreateTest("CompletePurchaseAddOnTickets");
            try
            {
                TS = new TimeSlots(driver);


                HP.GoToMovies();
                FM.MovieSelection();
                TS.MovieTimeSelection();
                ST.AddOneTicket();
                ST.AddOneTicket();
                ST.AddAnotherTicket();
                ST.AddTicketsToCart();


                NM.RecurringPaymentInfo(TestData.TicketPurchaseCreditCard, TestData.CardSecurityCode2, TestData.CreditCardZIP);
                NM.CompletePurchase();
            

                string ExpectedSuccessMsg = "Thank you for your purchase.";
                string ActualSuccessMsg = NM.GetTicketPurchaseSuccessMsg().Text;

                Assert.AreEqual(ExpectedSuccessMsg, ActualSuccessMsg);
                test.Log(Status.Pass, "2 Add On tickets purchased - Passed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "2 Add On tickets purchased - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }

        }

    }
    }

