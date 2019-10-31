using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;

/*  This // test uses the Movie Club Gift membeship code to add a new Movie club member */

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class RedeemMCGiftAsUserWithNoAccountTest :BaseTest

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

        /*  Below // test is to get a Movie Club Gift Membership */

        [Test, Order(1)]
        [Obsolete]
        public void PurchaseMovieClubGift()
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
                NM.RecurringPaymentInfo(TestData.MCCreditCard, TestData.CardSecurityCode1, TestData.MCZIP);
                NM.TermsAndConditions();
                NM.CompletePurchase();

                string ExpectedSuccessMsg = "Thank you for your purchase.";
                string ActualSuccessMsg = NM.GetTicketPurchaseSuccessMsg().Text;

                code = NM.GetRecipientGiftCode().Text;

                Assert.AreEqual(ExpectedSuccessMsg, ActualSuccessMsg);
                

        }


        /*  Below // test is using the Recipient Gift Code from the above // test & adding a new Movie Club Member*/

        [Test, Order(2)]
        [Obsolete]
        public void RegisterMCMUsingGiftCard()
        {
           
            UITest(() =>{try  
            {
                MR = new MovieRewardsInfoPage(driver);
                MC = new MovieClub(driver);

                email = Utils.GenerateUser();

                HP.GoToMovieRewards();
                MR.LearnMoreLink();
                MC.UpdateBillingZip(TestData.UpdateBillingZIP);
                NM.CreateAccount();
                NM.AccountInformation(email, email, "Cinemark1");
                NM.PersonalInformation("Auto", "User", "9721112222", "75093");
                NM.RecurringPaymentInfo(TestData.MCCreditCard, TestData.CardSecurityCode1, TestData.MCZIP);
                NM.PromoCodeInfo(code);
                NM.TermsAndConditions();
                NM.CompletePurchase();

                string ExpectedMsg = "Thank you for your purchase.";
                string ActualMsg = NM.GetTicketPurchaseSuccessMsg().Text;

                Assert.AreEqual(ExpectedMsg, ActualMsg);
                 test.Log(Status.Pass, "Movie Club Membership Gift Code successfully used to register a new Movie Club member Passed");
            }
            catch (Exception e)
            {
                 test.Log(Status.Fail, "Movie Club Membership Gift Code successfully used to register a new Movie Club member Failed");
             
                Assert.Fail();
            }
            });

        }


        /*  Below // test is checking the Total is $0.00*/

        [Test, Order(3)]
        [Obsolete]
        public void TotalAmount()
        {
        
            UITest(() =>{try  
            {
                SC = new ShoppingCart(driver);

                string ExpectedTotalSummary = "Total   $0.00";
                string ActualTotalSummary = SC.GetTotalPurchaseAmount().Text;

                Assert.AreEqual(ExpectedTotalSummary, ActualTotalSummary);
                 test.Log(Status.Pass, "Checking Final amount is $0.00 when Movie Club Membership Gift Code is successfully used to register a new Movie Club member Passed");
            }
            catch (Exception e)
            {
                 test.Log(Status.Fail, "Checking Final amount is $0.00 when Movie Club Membership Gift Code is successfully used to register a new Movie Club member Failed");
               
                Assert.Fail();
            }
            });
            }

    }
}
