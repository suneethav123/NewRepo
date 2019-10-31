using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using AventStack.ExtentReports;
using System.Threading;


//  This // test is reloading Gift Card 
//  This // test validates less than $5 & more than $500 amounts are not allowed to be reloaded.

namespace Cinemark.com.cinemark.testscripts.Purchases
{
    [TestFixture]
    class GiftCardReloadTest :BaseTest
    {
        private HomePage HP;
        private SignInMCM SI;
        private GiftCardPage GC;
        private ReloadGiftCardPage RL;
        private NewMovieClubSignIn NM;
        private GiftsPage GP;

       


        // trying to Reload < than $5 

        [Test, Order(1)]
        [Obsolete]
        public void GiftCardReloadLessThan5()
        {
          
            UITest(() =>{try
            {
                HP = new HomePage(driver);
                SI = new SignInMCM(driver);
                GC = new GiftCardPage(driver);                               
                RL = new ReloadGiftCardPage(driver);


                HP.GoToSignIn();
                SI.SignInMovieClubmember("AutoTest4444@example.com", "cinemark1");
                HP.YourAccount();
                HP.GoToYourAcctGiftCards();
                GC.ReloadButton();
                RL.ReloadGC("2");


                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementExists(By.XPath("//input[@class = 'btn cnkBtnPrim btn-flex']")));
                RL.AddToCart();

                Boolean ErrorMessage = RL.GetErrorMsg().Text.Contains("Please enter an amount between $5 and $500.");

                Assert.True(ErrorMessage);

                 test.Log(Status.Pass, "Error Message displayed when less than $5 reloaded to Gift card - Passed");
            }
            catch(Exception e)
            {
                 test.Log(Status.Fail, "Error Message displayed when less than $5 reloaded to Gift card - Failed");
              
                Assert.Fail();
                }
            });

        }


        //trying to Reload > than $5 

        [Test, Order(2)]
        [Obsolete]
        public void GiftCardReloadMoreThan500()
        {
         

            UITest(() =>{try
            {

                RL.ReloadGC("501");

                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementExists(By.XPath("//input[@class = 'btn cnkBtnPrim btn-flex']")));
                RL.AddToCart();

                Boolean ErrorMessage = RL.GetErrorMsg().Text.Contains("Please enter an amount between $5 and $500.");

                Assert.True(ErrorMessage);
                 test.Log(Status.Pass, "Error Message displayed when more than $500.00 reloaded to Gift card - Passed");
            }
            catch (Exception e)
            {
                 test.Log(Status.Fail, "Error Message displayed when more than $500.00 reloaded to Gift card - Failed");
         
                Assert.Fail();
                }
            });

        }


        // trying to Reload  $5 

        [Test, Order(3)]
        [Obsolete]
        public void GiftCardReload()
        {
          

            UITest(() =>{try
            {
                NM = new NewMovieClubSignIn(driver);

                RL.ReloadGC("100");
                
                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementExists(By.XPath("//input[@class = 'btn cnkBtnPrim btn-flex']")));
                RL.AddToCart();

                NM.RecurringPaymentInfo(TestData.TicketPurchaseCreditCard, TestData.CardSecurityCode2, TestData.CreditCardZIP);
                NM.CompletePurchase();

                string ExpectedMsg = "Thank you for your purchase.";
                string ActualMsg = NM.GetTicketPurchaseSuccessMsg().Text;

                Assert.AreEqual(ExpectedMsg, ActualMsg);
                 test.Log(Status.Pass, "Successfully reloaded $5.00 to Gift card - Passed");
            }
            catch (Exception e)
            {
                 test.Log(Status.Fail, "Successfully reloaded $5.00 to Gift card - Failed");
            
                Assert.Fail();
                }
            });

        }


       



    }
}
