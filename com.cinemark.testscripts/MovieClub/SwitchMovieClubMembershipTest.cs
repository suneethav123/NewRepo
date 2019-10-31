using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using AventStack.ExtentReports;

/* Switching Full Movie Club User to Movie Club Lite user and Vice-versa */

namespace Cinemark.com.cinemark.testscripts
{
    [TestFixture]
    class SwitchMovieClubMembershipTest :BaseTest
    {
        private HomePage HP;                     
        private MovieRewardsInfoPage MR;
        private MovieClub MC;
        private NewMovieClubSignIn NM;
        private MovieRewardsPage MRP;
        private string emailId;

        /* Switching Full Movie Club User to Movie Club Lite user  */

        [Test ,Order(1)]
        [Obsolete]
        public void MovieClubLite()
        {
           
            UITest(() =>{try    
            {
                HP = new HomePage(driver);
                MR = new MovieRewardsInfoPage(driver);
                MC = new MovieClub(driver);
                NM = new NewMovieClubSignIn(driver);
                MRP = new MovieRewardsPage(driver);

                emailId = Utils.GenerateUser();

                HP.GoToMovieRewards();
                MR.LearnMoreLink();
                MC.UpdateBillingZip(TestData.UpdateBillingZIP);
                NM.CreateAccount();
                NM.AccountInformation(emailId, emailId, "Cinemark1");
                NM.PersonalInformation("Auto", "User", "9721112222", "75093");
                NM.RecurringPaymentInfo(TestData.MCCreditCard, TestData.CardSecurityCode1, TestData.MCZIP);
                NM.TermsAndConditions();
                NM.CompletePurchase();



                HP.GoToMovieRewards();
                MRP.CancelMembership();
                MRP.ChangeToLiteMembership();

                string ExpectedMemberStatusMsg = "Welcome to Movie Club Lite!";
                string ActualMemberStatusMsg = MRP.GetMemberStatusHeadLine().Text;

                Assert.AreEqual(ExpectedMemberStatusMsg, ActualMemberStatusMsg);

                 test.Log(Status.Pass, "Movie Club - Switch to Movie Club Lite Passed");

            }
            catch(Exception e)
            {
                 test.Log(Status.Fail, "Movie Club - Switch to Movie Club Lite Failed");
             
                Assert.Fail();
                }
            });

        }



        /*  Checking Movie Club Lite Plan Value*/

        [Test, Order(2)]
        [Obsolete]
        public void MovieClubLiteMembershipPlanValue()
        {
           
            UITest(() =>{try    
            {
                HP.GoToMovieRewards();
                MRP.ManageYourMembership();

                string ExpectedPlanValue = "$" + TestData.LiteMembership;

                Utils.WaitForElement(driver).Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath("(//div[@class='planValue'])[2]"), "$4.99"));
                string ActualPlanValue = MRP.GetMembershipPlanValue().Text;

                Assert.AreEqual(ExpectedPlanValue, ActualPlanValue);

                 test.Log(Status.Pass, "Movie Club Lite Membership Plan Value is correct Passed");
            }
            catch (Exception e)
            {
                 test.Log(Status.Fail, "Movie Club Lite Membership Plan Value is correct Failed");
               
                Assert.Fail();
                }
            });
            }



        /* Switching Lite Movie Club User to Full Movie Club user  */

         [Test, Order(3)]
         [Obsolete]
         public void MovieClubFull()
         {
        
            UITest(() =>{try    
            {
                HP.GoToMovieRewards();
                MRP.ChangeToFullMembership();

                Thread.Sleep(2000);
                Boolean SuccessMessage = MRP.GetMemberStatusHeadLine().Text.Contains("Welcome back to Movie Club!");
                Assert.True(SuccessMessage);

                 test.Log(Status.Pass, "Switching Lite Movie Club User to Full Movie Club user Passed");
            }
            catch(Exception e)
            {
                 test.Log(Status.Pass, "Switching Lite Movie Club User to Full Movie Club user Failed");
          
                Assert.Fail();
                }
            });



        }


        /*  Checking Movie Club Full Plan Value*/

        [Test, Order(4)]
        [Obsolete]
        public void MovieClubFullMembershipPlanValue()
        {
          

            UITest(() =>{try    
            {
                HP.GoToMovieRewards();
                MRP.ManageYourMembership();

                string ExpectedPlanValue = "$" + TestData.FullMembership;
                Utils.WaitForElement(driver).Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath("(//div[@class='planValue'])[2]"), "$8.99"));
                string ActualPlanValue = MRP.GetMembershipPlanValue().Text;

                Assert.AreEqual(ExpectedPlanValue, ActualPlanValue);

                 test.Log(Status.Pass, "Movie Club Full Plan Value displayed is correct Passed");

            }
            catch (Exception e)
            {
                 test.Log(Status.Pass, "Movie Club Full Plan Value displayed is correct Failed");
              
                Assert.Fail();
                }
            });
        }

    }
}
