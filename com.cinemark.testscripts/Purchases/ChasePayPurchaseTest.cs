using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

using System.Threading;

using AventStack.ExtentReports;

// Purchase tickets using Chase Pay

namespace Cinemark.com.cinemark.testscripts.Purchases
{[TestFixture]
    class ChasePayPurchaseTest : BaseTest
    {

        private HomePage HP;
        private SignInMCM SI;
        private NewMovieClubSignIn NM;
        private FeaturedMovies FM;
        private TimeSlots TS;
        private SelectTickets ST;
        private ShoppingCartGuestCheckout SCG;
        private ShoppingCart SC;
        private ShoppingCartChasePayPage SCC;


        [Test, Order(1)]
        [Obsolete]

        public void ChasePayPurchase()
        {
            test = rep.CreateTest("ChasePayPurchase");

            try
            {

                SI = new SignInMCM(driver);
                HP = new HomePage(driver);
                NM = new NewMovieClubSignIn(driver);
                FM = new FeaturedMovies(driver);
                TS = new TimeSlots(driver);
                ST = new SelectTickets(driver);
                SCG = new ShoppingCartGuestCheckout(driver);
                SC = new ShoppingCart(driver);
                SCC = new ShoppingCartChasePayPage(driver);

                HP.GoToSignIn();
                SI.SignInMovieClubmember(Utils.GetEmailId(), "cinemark1");
                Utils.WaitForElement(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(By.LinkText("Sign In")));

                //Thread.Sleep(3000);


                /* if (SI.GetAgreeBtn().Displayed)
                 {
                     SI.AgreeButton();
                     SI.AgreeButton();
                 } */

                HP.GoToMovies();
                FM.MovieSelection();
                TS.MovieTimeSelection();
                ST.AddOneTicket();
                ST.AddAnotherTicket();
                ST.AddTicketsToCart();
                SCC.ChaseLink();
                SCC.SwitchFrame();
                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='selectedOption']")));
                SCC.ChasePay();

                SCC.SignInButton();
                SCC.NextButton();
                Utils.WaitForElement(driver).Until(ExpectedConditions.ElementIsVisible(By.Id("btnCompletePurchase")));
                SC.CompletePurchase();
                



                Thread.Sleep(3000);

              

                if (SC.GetCompletePurchase().Displayed)
                {
                    SC.CompletePurchase();
                }

                string ExpectedMsg = "Thank you for your purchase.";
                string ActualMsg = NM.GetTicketPurchaseSuccessMsg().Text;

                Assert.AreEqual(ExpectedMsg, ActualMsg);

                test.Log(Status.Pass, "Chase Pay purchase successfull - Passed");


            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "Chase Pay purchase successfull - Failed");
                test.Log(Status.Fail, e.ToString());
                Assert.Fail();
            }




        }
    }
}
