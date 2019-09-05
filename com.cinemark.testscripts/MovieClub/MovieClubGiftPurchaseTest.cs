using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;

/*  In this test Movie Club Gift Membership is purchased */

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class MovieClubGiftPurchaseTest :BaseTest
    {
        private HomePage HP;
        private GiftsPage GP;
        private MovieClubGiftMembershipPage MCG;
        private ShoppingCartGuestCheckout SCG;
        private NewMovieClubSignIn NM;
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private ShoppingCart SC;

        private string email;
        private string code;

        /*  Below test is to get a Movie Club Gift Membership */

        [Test, Order(1)]
        [Obsolete]
        public void PurchaseMCGift()
        {
            test = rep.CreateTest("PurchaseMCGift");
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
                NM.RecurringPaymentInfo(TestData.TicketPurchaseCreditCard, TestData.CardSecurityCode2, TestData.CreditCardZIP);
                NM.TermsAndConditions();
                NM.CompletePurchase();

                string ExpectedSuccessMsg = "Thank you for your purchase.";
                string ActualSuccessMsg = NM.GetTicketPurchaseSuccessMsg().Text;

                code = NM.GetRecipientGiftCode().Text;

                Assert.AreEqual(ExpectedSuccessMsg, ActualSuccessMsg);

                test.Log(Status.Pass, " Purchased Movie Club Gift Membership successfully - Passed");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Purchase Movie Club Gift Membership successfully- Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }
        }

               
       

    }
}
