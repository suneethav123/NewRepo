using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;


// This // test checks when New Movie Club member is added Credits , Points , Rewards & Tickets are correctly displayed

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class CreditsAndPointsCheckForNMCTest :BaseTest
    {

        
        private HomePage HP;
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private NewMovieClubSignIn NM;
        private MovieRewardsFeaturedRewards CO;
        private string emailId;
                         

        /*  This // test validates credits acquired on Rewards page after a new MCM is added*/        
       
         [Test,Order(1)]
         [Obsolete]
        public void NewMCMCreditsCheck()
        {
            //// test = rep.CreateTest("NewMCMCreditsCheck");
            UITest(() =>{try
            {
                HP = new HomePage(driver);
                MR = new MovieRewardsInfoPage(driver);
                MC = new MovieClub(driver);
                NM = new NewMovieClubSignIn(driver);
                CO = new MovieRewardsFeaturedRewards(driver);

                emailId = Utils.GenerateUser();

                HP.GoToMovieRewards();
                MR.LearnMoreLink();
                MC.UpdateBillingZip(TestData.UpdateBillingZIP);
                NM.CreateAccount();
                NM.AccountInformation(emailId, emailId, "Cinemark1");
                NM.PersonalInformation("Auto", "User", "9721111234", "75093");
                NM.RecurringPaymentInfo(TestData.MCCreditCard, TestData.CardSecurityCode1, TestData.MCZIP);
                NM.TermsAndConditions();
                NM.CompletePurchase();


                HP.GoToMovieRewards();

                string ExpectedCredits = "1";
                string ActualCredits = CO.GetCheckingCredits().Text;

                Assert.AreEqual(ExpectedCredits, ActualCredits);
                 test.Log(Status.Pass, "Number of credits displayed after a new Movie club member is added successfully - Passed");
            }
            catch (Exception e)
            {
                 test.Log(Status.Fail, "Number of credits displayed after a new Movie club member is added successfully - Failed");
               
                Assert.Fail();
                }
            });


        }

        /*  This // test validates Ponits acquired on Rewards page after a new MCM is added*/

        [Test, Order(2)]
        [Obsolete]
        public void NewMCMPointsCheck()
        {
            UITest(() =>{try
            {
                string Expectedpoints = "509";
                string ActualPoints = CO.GetCheckingPoints().Text;

                Assert.AreEqual(Expectedpoints, ActualPoints);
               test.Log(Status.Pass, "Number of Points displayed after a new Movie club member is added successfully - Passed");
            }
            catch (Exception e)
            {
               test.Log(Status.Fail, "Number of Points displayed after a new Movie club member is added successfully - Failed");
               
                Assert.Fail();
                }
            });
        }


        /*  This // test validates Rewards acquired on Rewards page after a new MCM is added*/

        [Test, Order(3)]
        [Obsolete]
        public void NewMCMRewardsCheck()
        {
           
            UITest(() =>{try
            {

                string ExpectedRewards = "0";
                string ActualRewards = CO.GetCheckingRewards().Text;

                Assert.AreEqual(ExpectedRewards, ActualRewards);
              test.Log(Status.Pass, "Number of Rewards displayed after a new Movie club member is added successfully - Passed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Number of Rewards displayed after a new Movie club member is added successfully - Failed");
               
                Assert.Fail();
                }
            });
        }


        /*  This // test validates number of Tickets displayed on Rewards page after a new MCM is added*/

        [Test, Order(4)]
        [Obsolete]
        public void NewMCMTicketsCheck()
        {
           
            UITest(() =>{try
            {
                string ExpectedTickets = "0";
                string ActualTickets = CO.GetCheckingTickets().Text;

                Assert.AreEqual(ExpectedTickets, ActualTickets);
                test.Log(Status.Pass, "Number of Tickets displayed after a new Movie club member is added successfully - Passed");
            }
            catch (Exception e)
            {
              test.Log(Status.Fail, "Number of Tickets displayed after a new Movie club member is added successfully - Failed");
               
                Assert.Fail();
                }
            });
        }

        
    }
}
