using AventStack.ExtentReports;
using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


//This test uses exisiting  Movie club member ,buys 2 tickets & refunds them back


namespace Cinemark.com.cinemark.testscripts.Purchases
{
    [TestFixture]
    class RefundTicketsWithExisitingMCMTest :BaseTest
    {
        private HomePage HP;
        private SignInMCM SI;
        private FeaturedMovies FM;
        private TimeSlots TS;
        private SelectTickets ST;
        private NewMovieClubSignIn NM;
        private ShoppingCart SC;
        private GuestServicesPage GS;
        private GuestServicesRefundPage GSR;
        private PurchaseConfirmationPage PC;
        private string RefundedAmount;
        private string AmountCharged;

        [Obsolete]
        [Test, Order(1)]
        public void RefundTicketsForExistingMCM()
        {
            test = rep.CreateTest("RefundTickets");
            try
            {

                HP = new HomePage(driver);
                SI = new SignInMCM(driver);
                FM = new FeaturedMovies(driver);
                TS = new TimeSlots(driver);
                ST = new SelectTickets(driver);
                NM = new NewMovieClubSignIn(driver);
                SC = new ShoppingCart(driver);
                GS = new GuestServicesPage(driver);
                GSR = new GuestServicesRefundPage(driver);
                PC = new PurchaseConfirmationPage(driver);

                HP.GoToSignIn();
                SI.SignInMovieClubmember("yjanagama+45@gmail.com", "cinemark1");

                Utils.WaitForElement(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(By.LinkText("Sign In")));
                
                HP.GoToMovies();
                FM.MovieSelection();
                TS.MovieTimeSelection();
                ST.AddOneTicket();
                ST.AddAnotherTicket();
                ST.AddTicketsToCart();
                NM.RecurringPaymentInfo(TestData.TicketPurchaseCreditCard, TestData.CardSecurityCode2, TestData.CreditCardZIP);
                NM.CompletePurchase();

                AmountCharged = PC.GetAmountCharged().Text;

                HP.SignOut();
                HP.GoToSignIn();
                SI.SignInMovieClubmember("yjanagama+45@gmail.com", "cinemark1");
                Utils.WaitForElement(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(By.LinkText("Sign In")));
                HP.GoToGuestServices();
                GS.GoToRefundLink();
                //GSR.RefundInfo("yjanagama+45@gmail.com", TestData.Last4CreditCardDigits);

                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='btn cnkBtnStd btn-wide cnkBtnPrim']")));
                GSR.FirstRefundBtn();

                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#ProcessRefundForm > fieldset > div > input")));
                GSR.SecondRefundBtn();

                
                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("(//h5[@class='col-xs-5 col-lg-4 text-right'])[1]")));
                RefundedAmount = GSR.GetRefundAmount().Text;




                string ExpectedMsg = "Your purchase has been refunded.";
                string ActualMsg = GSR.GetRefundSuccessMsg().Text;

                Assert.AreEqual(ExpectedMsg, ActualMsg);
                test.Log(Status.Pass, "Successfully refunded the tickets - Passed");
            }



            catch (Exception e)
            {
                test.Log(Status.Fail, "Successfully refunded the tickets - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }
        }


        // Below test checks the refunded amount is correct

        [Test, Order(2)]
        public void RefundedAmountValidationForExistingMCM()
        {
            test = rep.CreateTest("RefundedAmountValidationForExistingMCM");
            try
            {
                string ExpectedRefundedAmt = AmountCharged;
                string ActualRefundedAmt = GSR.GetRefundAmount().Text;

                Assert.AreEqual(ExpectedRefundedAmt, ActualRefundedAmt);
                test.Log(Status.Pass, "Refunded amount correctly - Passed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Refunded amount correctly - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }
        }






    }
}
