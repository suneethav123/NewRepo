using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using AventStack.ExtentReports;
using System.Threading;


//   This // test is for Bulk Gift Card Purchase 
//   Validate Error messages when Bulk Gift card count is less than 10
//   Cannot Purchase Tickets & Bulk Gift Cards in the same transaction

namespace Cinemark.com.cinemark.testscripts.Purchases
{
    [TestFixture]
    class BulkGiftCardPurchaseTest : BaseTest
    {
        private HomePage HP;
        private FeaturedMovies FM;
        private TimeSlots TS;
        private SelectTickets ST;
        private GiftsPage GP;
        private BulkGiftCardsPage BGC;
        private ShoppingCartGuestCheckout SGC;
        private NewMovieClubSignIn NM;
        private ShoppingCart SC;

        
        // This // test is for Bulk Gift cards < 10 count
        // User should not be allowed to purchase Bulk Gift cards less than 10

        [Test, Order(1)]
        [Obsolete]
        public void BulkGiftCardPurchaseLessThan10()
        {
          
            UITest(() =>{try
            {
                HP = new HomePage(driver);
                GP = new GiftsPage(driver);
                BGC = new BulkGiftCardsPage(driver);

                HP.GoToGifts();
                GP.BulkOrders();
                BGC.PurchaseBulkGiftCard("5", "10");

                string ExpectedErrMsg = "A minimum of 10 Gift Cards is required.";
                string ActualErrMsg = BGC.GetErrorMessage().Text;

                Assert.AreEqual(ExpectedErrMsg, ActualErrMsg);
                 test.Log(Status.Pass, "Cannot buy less than 10 Bulk Gift Cards - Passed");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Cannot buy less than 10 Bulk Gift Cards - Passed");
               
                Assert.Fail();
                }
            });

        }


        // This // test is to add 10 Bulk Gift Cards successfully

        [Test, Order(2)]
        [Obsolete]
        public void BulkGiftCardPurchase()
        {
          
            UITest(() =>{try
            {
                SGC = new ShoppingCartGuestCheckout(driver);
                SC = new ShoppingCart(driver);
                NM = new NewMovieClubSignIn(driver);

                string emailId = Utils.GenerateUser();

                HP.GoToGifts();
                GP.BulkOrders();
                BGC.PurchaseBulkGiftCard("10", "10");
                SGC.GuestCheckOut(emailId);
                NM.RecurringPaymentInfo(TestData.TicketPurchaseCreditCard, TestData.CardSecurityCode2, TestData.CreditCardZIP);
                SC.ShippingInfo("1000 Long Dr", "Dallas", "75022", "John", "Doe", "9721112222");
                NM.CompletePurchase();


                string ExpectedErrMsg = "Thank you for your purchase.";
                string ActualErrMsg = NM.GetTicketPurchaseSuccessMsg().Text;

                Assert.AreEqual(ExpectedErrMsg, ActualErrMsg);
               test.Log(Status.Pass, "Successfully purchased Bulk Gift Cards - Passed");

            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Successfully purchased Bulk Gift Cards - Failed");
               
                Assert.Fail();
                }
            });

        }


        //  This // test is to check user is not able to purchase Tickets & Bulk Gift cards in the same transaction

        [Test, Order(3)]
        [Obsolete]
        public void PurchaseTicketsAndBulkGiftCards()
        {
      
            UITest(() =>{try
            {

                FM = new FeaturedMovies(driver);
                TS = new TimeSlots(driver);
                ST = new SelectTickets(driver);
                HP = new HomePage(driver);
                GP = new GiftsPage(driver);


                HP.GoToMovies();
                FM.MovieSelection();
                TS.LocationDropDown1();
                TS.MovieTimeSelection();
                ST.AddOneTicket();
                ST.AddTicketsToCart();

                Thread.Sleep(3000);
               // Utils.WaitForElement(driver).Until(ExpectedConditions.ElementToBeSelected(By.LinkText("Gifts")));
                HP.GoToGifts();
                GP.BulkOrders();

                Boolean ErrorMessage = BGC.GetErrorMessage().Text.Contains("Cannot add to cart:");
                Assert.True(ErrorMessage);

                test.Log(Status.Pass, "Error displayed when tickets & Bulk Gift cards purchased in the same transaction - Passed");
            }
            catch(Exception e)
            {
                 test.Log(Status.Fail, "Error displayed when tickets & Bulk Gift cards purchased in the same transaction - Failed");
                 test.Log(Status.Fail, e.ToString());
                Assert.Fail();
                }
            });




        }
    }
}