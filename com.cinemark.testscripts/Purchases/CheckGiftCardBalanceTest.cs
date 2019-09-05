using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using AventStack.ExtentReports;
using System.Threading;


// Reloaded Gift card with $5
// Trying to see the uploaded Gift Card amount is seen correctly in Gift card balance

namespace Cinemark.com.cinemark.testscripts.Purchases
{ [TestFixture]
    class CheckGiftCardBalanceTest : BaseTest
    {

        private HomePage HP;
        private SignInMCM SI;
        private GiftCardPage GC;
        private ReloadGiftCardPage RL;
        private NewMovieClubSignIn NM;
        private GiftsPage GP;

        string GCOriginalBal = null;
        string AddedAmount = null;
        double GCOriginalBalDoubleValue = 0;
        double AddedAmountDoubleValue = 0;
        


        [Test , Order(1)]
        [Obsolete]
        public void GiftCardBalanceCheck()
        {
            test = rep.CreateTest("GiftCardBalanceCheck");
            try
            {
                HP = new HomePage(driver);
                SI = new SignInMCM(driver);
                GC = new GiftCardPage(driver);
                RL = new ReloadGiftCardPage(driver);
                NM = new NewMovieClubSignIn(driver);
                GP = new GiftsPage(driver);

                HP.GoToSignIn();
                SI.SignInMovieClubmember("AutoTest2222@example.com", "cinemark1");
                //SI.AgreeButton();
                HP.YourAccount();
                HP.GoToYourAcctGiftCards();

                // Initial amount on the gift card
                GCOriginalBal = GC.GetGCOriginalBalance().Text;


                GC.ReloadButton();
                RL.ReloadGC("5");
                RL.AddToCart();
                NM.RecurringPaymentInfo(TestData.TicketPurchaseCreditCard, TestData.CardSecurityCode2, TestData.CreditCardZIP);
                NM.CompletePurchase();
                Thread.Sleep(6000);
                Utils.WaitForElement(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("btnCompletePurchase")));

                // Amount added to the Gift card
                AddedAmount = RL.GetReloadedAmount().Text;



                HP.SignOut();
                SI.SignInMovieClubmember("AutoTest2222@example.com", "cinemark1");
                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementIsVisible(By.LinkText("Your Account")));
                HP.GoToGifts();
                GP.GCBalanceCheck("274111791538");

                // Trying to remove $ sign from the text which has original balance on the GC
                GCOriginalBal = GCOriginalBal.Replace("$", string.Empty);

                //Trying to convert string to Double
                GCOriginalBalDoubleValue = Convert.ToDouble(GCOriginalBal);


                // Trying to remove $ sign from the text which has new amount added on the GC
                AddedAmount = AddedAmount.Replace("$", string.Empty);


                //Trying to convert string to Double
                AddedAmountDoubleValue = Convert.ToDouble(AddedAmount);

                //Trying to add both original GC amount + new added amount
                double ExpectedAmountIntValue = GCOriginalBalDoubleValue + AddedAmountDoubleValue;

                //Converting from Double to string
                string ExpectedAmount = ExpectedAmountIntValue.ToString();

                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementIsVisible(By.Id("txtBalanceAmount")));

                string ActualAmount = GP.GetBalanceAmount().Text;
                ActualAmount = ActualAmount.Replace("$", string.Empty);

                Assert.AreEqual(ExpectedAmount, ActualAmount);
                test.Log(Status.Pass, "Gift card balance is displayed correctly - Passed");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Gift card balance is displayed correctly - failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }

        }
    }
}
