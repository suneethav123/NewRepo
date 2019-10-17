using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using System.Threading;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

/*  This test is to redeem Movie Club Membership gift as a signed in Movie Club Member ,so the gift code adds a credit to the account when redeemed*/

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]

       
    class RedeemMCGiftAsSignedInMCMemberTest :BaseTest
    {
        private HomePage HP;
        private GiftsPage GP;
        private MovieClubGiftMembershipPage MCG;
        private ShoppingCartGuestCheckout SCG;
        private NewMovieClubSignIn NM;
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private MovieRewardsPage MP;

        private string email;
        private string code;


        /*  Below test is to purchase a Movie Club Membership gift card */

        [Test, Order(1)]
        [Obsolete]
        public void MovieMembershipGiftPurchase()
        {
            test = rep.CreateTest("MovieMembershipGiftPurchase");
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
                NM.RecurringPaymentInfo("4012000033330026", "111", "66666");
                NM.TermsAndConditions();
                NM.CompletePurchase();

                string ExpectedSuccessMsg = "Thank you for your purchase.";
                string ActualSuccessMsg = NM.GetTicketPurchaseSuccessMsg().Text;

                code = NM.GetRecipientGiftCode().Text;

                Assert.AreEqual(ExpectedSuccessMsg, ActualSuccessMsg);
                test.Log(Status.Pass, "Movie Club Membership gift purchased Passed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Movie Club Membership gift purchased Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }

        }


        /*  Below test is to add a new Movie Club member without using Movie Club Membership gift card */

        [Test, Order(2)]
        [Obsolete]
        public void AddNMCMemberThruMovieRewards()
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
            NM.AccountInformation(email, email, "Cinemark1");
            NM.PersonalInformation("Auto", "User", "9721112222", "75093");
            NM.RecurringPaymentInfo(TestData.MCCreditCard, TestData.CardSecurityCode1, TestData.MCZIP);
            NM.TermsAndConditions();
            NM.CompletePurchase();


            Utils.WaitForElement(driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("(//h2[@class= 'top'])[1]")));

            string ExpectedMsg = "Thank you for your purchase.";
            string ActualMsg = NM.GetSuccessMessage().Text;

            Assert.AreEqual(ExpectedMsg, ActualMsg);

        }

        /* Below test redeems the Movie Club membership gift card   */

        [Test, Order(3)]
        [Obsolete]
        public void RedeemMCGift()
        {
            test = rep.CreateTest("RedeemMCGift");
            try
            {
                MP = new MovieRewardsPage(driver);

                HP.GoToMovieRewards();
                MP.RedeemMovieClubGiftCode(code);
               

                string ExpectedCredits = "2";

                Utils.WaitForElement(driver).Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#movieRewardsSidebar > div.dashboard-top-module > div > div.dashboard-card-buttons > div:nth-child(3) > a > div > span.dashboard-cardnumber.mcCreditsAvailable"),"2"));
                string ActualCredits = MP.GetCreditsAvailableText().Text;

                Assert.AreEqual(ExpectedCredits, ActualCredits);
                test.Log(Status.Pass, "Redeem Movie Club Membership Gift for credits Passed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Redeem Movie Club Membership Gift for credits Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }


        }






    }
}
