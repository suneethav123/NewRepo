using Cinemark.com.cinemark.pages;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;


// This test is to submit Birthday Party Form

//namespace Cinemark.com.cinemark.testscripts.Other
//{[TestFixture]
//    class SubmitBirthdayPartyFormTest : BaseTest
//    {
//        private FooterLinksPage FP;
//        private PrivateEventsPage PE;
//        private PrivateEventFormPage PS;


//        [Test, Order(1)]
//        [Obsolete]
//        public void BirthdayPartyFormSubmission()
//        {
//            test = rep.CreateTest("BirthdayPartyFormSubmission");
//            try
//            {
//                FP = new FooterLinksPage(driver);
//                PE = new PrivateEventsPage(driver);
//                PS = new PrivateEventFormPage(driver);

//                FP.GoToPrivateEvents();
//                PE.BirthdayParties();
//                PS.BirthdayPartiesForm();

//                Boolean SubmitMsg = PS.GetSubmitMsg().Displayed;

//                Assert.IsTrue(SubmitMsg);
//                test.Log(Status.Pass, "Birthday Party form successfully submited - Passed");
                
//            }
//            catch(Exception e)
//            {
//                test.Log(Status.Fail, "Birthday Party form successfully submited - Failed");
//                test.Log(Status.Fail, e.ToString());
//                Assert.Fail();

//            }
//        }
//    }
//}
