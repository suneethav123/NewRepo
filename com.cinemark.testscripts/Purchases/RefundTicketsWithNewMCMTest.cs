using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using AventStack.ExtentReports;
using System.Threading;

//This // test adds a new Movie club member ,buys 2 tickets & refunds them back


namespace Cinemark.com.cinemark.testscripts.Purchases
{[TestFixture]
    class RefundTicketsWithNewMCMTest :BaseTest
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
        private GuestServicesRefundPage GSR;
        private PurchaseConfirmationPage PC;
        private string emailId;
        private string AmountCharged;
        private string RefundedAmount;


        [Test ,Order(1)]
        [Obsolete]
        public void RefundTickets()
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
                GS = new GuestServicesPage(driver);
                GSR = new GuestServicesRefundPage(driver);
                PC = new PurchaseConfirmationPage(driver);

                emailId = Utils.GenerateUser();

                //Adding a new movie club member

                HP.GoToMovieRewards();
                MR.LearnMoreLink();
                MC.UpdateBillingZip(TestData.UpdateBillingZIP);
                NM.CreateAccount();
                NM.AccountInformation(emailId, emailId, "Cinemark1");
                NM.PersonalInformation("Auto", "User", "9721111234", "75093");
                NM.RecurringPaymentInfo(TestData.MCCreditCard, TestData.CardSecurityCode1, TestData.MCZIP);
                NM.TermsAndConditions();
                NM.CompletePurchase();

                //Purchasing 2 Movie tickets

                NM.ChooseMovie();
                FM.MovieSelection();
                TS.MovieTimeSelection();
                ST.AddOneTicket();
                ST.AddAnotherTicket();
                ST.AddTicketsToCart();
                NM.RecurringPaymentInfo(TestData.TicketPurchaseCreditCard, TestData.CardSecurityCode2, TestData.CreditCardZIP);                             
                NM.CompletePurchase();

                //Thread.Sleep(6000);
                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("(//h5[contains(@class,'right')])[2]")));


                AmountCharged = PC.GetAmountCharged().Text;

                HP.SignOut();
                //Refund the Movie tickets

                HP.GoToGuestServices();

                GS.GoToRefundLink();
                GSR.RefundInfo(emailId, TestData.Last4CreditCardDigits);

                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='btn cnkBtnStd btn-wide cnkBtnPrim']")));
                GSR.FirstRefundBtn();

                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#ProcessRefundForm > fieldset > div > input")));
                GSR.SecondRefundBtn();

                //Thread.Sleep(7000);
                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("(//h5[@class='col-xs-5 col-lg-4 text-right'])[1]")));
                RefundedAmount = GSR.GetRefundAmount().Text;
                System.Diagnostics.Debug.WriteLine(RefundedAmount);



                string ExpectedMsg = "Your purchase has been refunded.";
                string ActualMsg = GSR.GetRefundSuccessMsg().Text;

                Assert.AreEqual(ExpectedMsg, ActualMsg);
                //est.Log(Status.Pass, "Successfully refunded the tickets - Passed");

            }
            catch(Exception e)
            {
                //est.Log(Status.Fail, "Successfully refunded the tickets - Failed");
              
                Assert.Fail();
                }
            });


        }


        [Test,Order(2)]
        public void RefundedAmountValidation()
        {
            UITest(() =>
            {
                try
            {
                string ExpectedRefundedAmt = AmountCharged;
                string ActualRefundedAmt = GSR.GetRefundAmount().Text;

                Assert.AreEqual(ExpectedRefundedAmt, ActualRefundedAmt);
                 test.Log(Status.Pass, "Refunded amount correctly - Passed");
            }
            catch(Exception e)
            {
                 test.Log(Status.Fail, "Refunded amount correctly - Failed");
                
                Assert.Fail();
                }
            });
        }
    }
}
