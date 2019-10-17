using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using AventStack.ExtentReports;


/*  This test is to buy a movie ticket by Unchecking Apply Credit check box*/

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class BuyATicketUncheckingMovieCreditsBoxTest :BaseTest
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

        

        /*  This test adds a new Movie Club Member & Check Online fees are $0.00 for MCM   */

        [Test, Order(1)]
        [Obsolete]
        public void PurchaseATicketUsingNewMCMCredits()
        {
            test = rep.CreateTest("PurchaseATicketUsingNewMCMCredits");
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
                ST.ApplyCreditCheckBox();

                Thread.Sleep(1000);

                NM.RecurringPaymentInfo(TestData.TicketPurchaseCreditCard, TestData.CardSecurityCode2, TestData.CreditCardZIP);

                
                NM.CompletePurchase();


                string ExpectedSuccessMsg = "Thank you for your purchase.";
                string ActualSuccessMsg = NM.GetTicketPurchaseSuccessMsg().Text;

                Assert.AreEqual(ExpectedSuccessMsg, ActualSuccessMsg);
                test.Log(Status.Pass, "Successful Ticket purchase - Passed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Successful Ticket purchase - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }
        }



        

        /* This test is making sure Confirmation Number is displayed */

        [Test ,Order(2)]
        public void TicketConfirmationNumber()
        {
            test = rep.CreateTest("TicketConfirmationNumber");
            try
            {
                string ExpectedConfirmationMsg = "Confirmation Number";
                string ActualConfirmationMsg = NM.GetTicketConfirmationNumber().Text;

                Assert.AreEqual(ExpectedConfirmationMsg, ActualConfirmationMsg);
                test.Log(Status.Pass, "Ticket Confirmation Number displayed - Passed");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Ticket Confirmation Number displayed - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }
        }


        /*  This test is to check full price is added when Apply Credits is unchecked */

        [Test, Order(3)]
        [Obsolete]
        public void TicketPricesWithNoCredit()
        {
            test = rep.CreateTest("TicketPricesWithNoCredit");
            try
            {

                string ExpectedMovieTicketsPrice = "$" + TestData.MovieTicketFullPrice;

                Utils.WaitForElement(driver).Until(ExpectedConditions.TextToBePresentInElementLocated(By.Id("SummarySubTotal"), "$28.00"));
                string ActualMovieTicketsPrice = SC.GetPriceWithNoCredits().Text;

                Assert.AreEqual(ExpectedMovieTicketsPrice, ActualMovieTicketsPrice);
                test.Log(Status.Pass, "Full price is added when Apply Credits is unchecked - Passed");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Full price is added when Apply Credits is unchecked - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }
        }



    }
}

