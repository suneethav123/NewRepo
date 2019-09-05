using Cinemark.com.cinemark.pages;
using Cinemark.DataBase;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Added a new Movie Club Member & registered gift card 
// Reloaded Gift card with $5
// Trying to see the uploaded Gift Card amount is seen correctly in Gift card balance

namespace Cinemark.com.cinemark.testscripts.Purchases
{
    [TestFixture]
    class CheckGiftCardBalanceWithNewMCMTest :BaseTest
    {

        private HomePage HP;
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private NewMovieClubSignIn NM;
        
        private ShoppingCart SC;
        private GuestServicesPage GS;
        private GuestServicesRegisterGiftCardPage GSR;
        private PurchaseConfirmationPage PC;
        private GiftCardCode GCC;
        private GiftCardPage GC;
        private ReloadGiftCardPage RL;
        private CouponCode CC;
        
        private ShoppingCartGiftCard SCG;
        private string emailId;
        private string giftCardId;
        private SignInMCM SI;
        private GiftsPage GP;

        string GCOriginalBal = null;
        string AddedAmount = null;
        double GCOriginalBalDoubleValue = 0;
        double AddedAmountDoubleValue = 0;

        [Test,Order(1)]
        [Obsolete]
        public void GiftCardBalanceWithNewMCM()
        {

            HP = new HomePage(driver);
            MR = new MovieRewardsInfoPage(driver);
            MC = new MovieClub(driver);
            NM = new NewMovieClubSignIn(driver);
            
            SC = new ShoppingCart(driver);
            GS = new GuestServicesPage(driver);
            GSR = new GuestServicesRegisterGiftCardPage(driver);
            PC = new PurchaseConfirmationPage(driver);
            GC = new GiftCardPage(driver);
            RL = new ReloadGiftCardPage(driver);
            
            SCG = new ShoppingCartGiftCard(driver);
            GCC = ReadDBForGiftCard.FetchInfo();
            CC = ReadDB.FetchInfo();
            SI = new SignInMCM(driver);
            GP = new GiftsPage(driver);

            emailId = Utils.GenerateUser();
            giftCardId = GCC.gc_id;

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
            GSR.RegisterGiftCard("GiftCardOne", giftCardId);

            

            // Initial amount on the gift card
            GCOriginalBal = GC.GetGCOriginalBalance().Text;


            GC.ReloadButton();
            RL.ReloadGC("5");
            RL.AddToCart();
            NM.RecurringPaymentInfo(TestData.TicketPurchaseCreditCard, TestData.CardSecurityCode2, TestData.CreditCardZIP);
            NM.CompletePurchase();
            Thread.Sleep(9000);
            Utils.WaitForElement(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("btnCompletePurchase")));

            // Amount added to the Gift card
            AddedAmount = RL.GetReloadedAmount().Text;



            HP.SignOut();
            SI.SignInMovieClubmember(emailId, "cinemark1");
            Utils.WaitForElement(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(By.LinkText("Sign In")));
            HP.GoToGifts();
            GP.GCBalanceCheck(giftCardId);

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

            //Converting from Double to string,adding 0.00 in the brackets keeps the .00 if the expected amount has
            string ExpectedAmount = ExpectedAmountIntValue.ToString("0.00");
            

            Utils.WaitForElement(driver).Until(ExpectedConditions.ElementIsVisible(By.Id("txtBalanceAmount")));

            string ActualAmount = GP.GetBalanceAmount().Text;
            ActualAmount = ActualAmount.Replace("$", string.Empty);

            Assert.AreEqual(ExpectedAmount, ActualAmount);

        }
    }
}
