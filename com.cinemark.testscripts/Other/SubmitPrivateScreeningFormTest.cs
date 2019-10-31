using AventStack.ExtentReports;
using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;

// This // test submits Private Screening form

//namespace Cinemark.com.cinemark.// testscripts.Other
//{[TestFixture]
//    class SubmitPrivateScreeningFormTest:BaseTest
//    {
//        private FooterLinksPage FP;
//        private PrivateEventsPage PE;
//        private PrivateEventFormPage PS;

//        [Test, Order(1)]
//        [Obsolete]
//        public void PrivateScreeningBooking()
//        {
//            // test = rep.CreateTest("PrivateScreeningBooking");
//            try
//            {
//                FP = new FooterLinksPage(driver);
//                PE = new PrivateEventsPage(driver);
//                PS = new PrivateEventFormPage(driver);

//                FP.GoToPrivateEvents();
//                PE.PrivateScreening();
//                PS.PrivateScreeningForm();

//                Boolean SubmitMsg = PS.GetSubmitMsg().Displayed;

//                Assert.IsTrue(SubmitMsg);
//                // test.Log(Status.Pass, "Private Screening Form successfully submitted - Passed");
//            }
//            catch(Exception e)
//            {
//                // test.Log(Status.Fail, "Private Screening Form successfully submitted - Passed");
//                // test.Log(Status.Fail, e.ToString());
//                Assert.Fail();
//            }
            
//        }
//    }
//}
