using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using System.Threading;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

// This // test is to add a Movie Reward Coupon & make sure Credits , Rewards, points ,Tickets are displayed correctly

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class MovieTicketRewardTest :BaseTest
    {
        
        private HomePage HP;
        private MovieRewardsInfoPage MR;
        private SignInMCM SI;
        private MovieRewardsFeaturedRewards MF;

        


        [Test, Order(1)]
        [Obsolete]
        public void CreditsRecievedForMovieRewardTest()
        {
         
            UITest(() =>{try 
            {
                HP = new HomePage(driver);
                MR = new MovieRewardsInfoPage(driver);
                SI = new SignInMCM(driver);
                MF = new MovieRewardsFeaturedRewards(driver);


                HP.GoToSignIn();
                
                SI.SignInMovieClubmember(Utils.GetEmailId(), "Cinemark1");
                Utils.WaitForElement(driver).Until(ExpectedConditions.InvisibilityOfElementLocated(By.LinkText("Sign In")));
                HP.GoToMovieRewards();
                MF.FeaturedRewardLinks();

                string ExpectedMovieCredits = "2";
                string ActualMovieCredits = MF.GetCheckingCredits().Text;

                Assert.AreEqual(ExpectedMovieCredits, ActualMovieCredits);
                test.Log(Status.Pass, "Credits recieved for Movie Rewards Passed");
            }
            catch (Exception e)
            {
                 test.Log(Status.Fail, "Credits recieved for Movie Rewards Failed");
                
                Assert.Fail();
                }
            });


        }

        [Test,Order(2)]
        [Obsolete]
        public void RewardReceivedForMovieRewardTest()
        {
           
            UITest(() =>{try 
            {
                string ExpectedRewards = "1";
            string ActualRewards = MF.GetCheckingRewards().Text;

            Assert.AreEqual(ExpectedRewards, ActualRewards);
               test.Log(Status.Pass, "Rewards recieved for Movie Rewards Passed");
            }
            catch (Exception e)
            {
               test.Log(Status.Fail, "Rewards recieved for Movie Rewards Failed");
            
                Assert.Fail();
                }
            });
        }

        [Test, Order(3)]
        [Obsolete]
        public void PointsUsedForMovieRewardTest()
        {
         
            UITest(() =>{try 
            {

                string ExpectedPoints = "469";
                string ActualPoints = MF.GetCheckingPoints().Text;

            
                Assert.AreEqual(ExpectedPoints, ActualPoints);
                test.Log(Status.Pass, "Points recieved for Movie Rewards Passed");
            }
            catch (Exception e)
            {
                 test.Log(Status.Fail, "Points recieved for Movie Rewards Failed");
          
                Assert.Fail();
                }
            });
        }

        [Test, Order(4)]
        [Obsolete]
        public void TicketsDisplayedForMovieRewardsTest()
        {
         
            UITest(() =>{try 
            {
                Thread.Sleep(2000);

            string ExpectedTickets = "0";
            string ActualTickets = MF.GetCheckingTickets().Text;

            Assert.AreEqual(ExpectedTickets, ActualTickets);
             test.Log(Status.Pass, "Tickets recieved for Movie Rewards Passed");
        }
            catch (Exception e)
            {
                 test.Log(Status.Fail, "Tickets recieved for Movie Rewards Failed");
            
                Assert.Fail();
                }
            });
        } 



    }
}
