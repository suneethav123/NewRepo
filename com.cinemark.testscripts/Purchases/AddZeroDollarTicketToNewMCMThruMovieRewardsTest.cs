using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;


/* This // test is to add a new movie club member and then add a zero dollar ticket thru Theatres */

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class AddZeroDollarTicketToNewMCMThruMovieRewardsTest:BaseTest
    {
        private HomePage HP;
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private NewMovieClubSignIn NM;
        private ChooseTheatre CT;
        private TheatreFeaturedMovies TF;
        private TimeSlots TS;
        private SelectTickets ST;
        private ShoppingCart SC;
        private string emailId;


        /* Below // test adds a new MCM and adds purchases a $0.00 ticket */

        [Test , Order(1)]
        [Obsolete]
        public void AddZeroDollarTicketThruMovieRewards()
        {
            UITest(() =>
            {
                try
            {
                HP = new HomePage(driver);
                MR = new MovieRewardsInfoPage(driver);
                MC = new MovieClub(driver);
                NM = new NewMovieClubSignIn(driver);
                CT = new ChooseTheatre(driver);
                TF = new TheatreFeaturedMovies(driver);
                TS = new TimeSlots(driver);
                ST = new SelectTickets(driver);
                SC = new ShoppingCart(driver);

                emailId = Utils.GenerateUser();

                HP.GoToMovieRewards();
                MR.LearnMoreLink();
                MC.UpdateBillingZip("75093");
                NM.CreateAccount();
                NM.AccountInformation(emailId, emailId, "Cinemark1");
                NM.PersonalInformation("Auto", "User", "9721112222", "75093");
                NM.RecurringPaymentInfo("4111111111111111", "111", "75093");
                NM.TermsAndConditions();
                NM.CompletePurchase();
                HP.GoToTheatres();
                TS.LocationDropDown1();
                CT.TheatreSelection();
                TF.MoviePick();
                TS.VirtualRealityMovieTimeSelection();
                ST.AddOneTicket();
                ST.AddTicketsToCart();
                ST.CompletePurchase();

                string ExpectedTotalSummary = "Total   $0.00";
                string ActualTotalSummary = SC.GetTotalPurchaseAmount().Text;

                Assert.AreEqual(ExpectedTotalSummary, ActualTotalSummary);
              test.Log(Status.Pass, "Successfully added $0.00 ticket  for a Movie Club Member - Passed");
            }
            catch(Exception e)
            {
             test.Log(Status.Fail, "Successfully added $0.00 ticket  for a Movie Club Member - Failed");
              
                Assert.Fail();
            }
            });
        }


        /* Below // test checks the user does not get any points when purchased a $0.00 ticket  */

        [Test, Order(2)]
        public void PointsEarnedTest()
        {
            UITest(() =>
            {
                try
            {
                string ExpectedPointsMsg = "No points earned.";
                string ActualPointsMsg = NM.GetPointsEarned().Text;

                Assert.AreEqual(ExpectedPointsMsg, ActualPointsMsg);
                test.Log(Status.Pass, "No points received for $0.00 ticket purchase - Passed");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, "No points received for $0.00 ticket purchase - Failed");
                               Assert.Fail();
            }
            });

        }
    }
}
