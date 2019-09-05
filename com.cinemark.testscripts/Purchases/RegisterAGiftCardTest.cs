using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//  This test registers a gift card to a MCM account

namespace Cinemark.com.cinemark.testscripts.Purchases
{[TestFixture]
    class RegisterAGiftCardTest :BaseTest
    {
        private HomePage HP;
        private SignInMCM SI;
        private GuestServicesPage GS;
        private GuestServicesRegisterGiftCardPage GSR;
        private GiftCardPage GC;


        [Test ,Order(1)]
        [Obsolete]
        public void RegisterAGiftCard()
        {
            HP = new HomePage(driver);
            SI = new SignInMCM(driver);
            GS = new GuestServicesPage(driver);
            GSR = new GuestServicesRegisterGiftCardPage(driver);
            GC = new GiftCardPage(driver);


            HP.GoToGuestServices();
            GS.GoToRegisterGiftCardLink();
            SI.SignInMovieClubmember("AutoTest4444@example.com", "cinemark1");
            GSR.RegisterGiftCard("GiftCardOne", "269511175250");

            bool UnRegisterButton = GC.GetUnRegisterBtn().Displayed;

            Assert.IsTrue(UnRegisterButton);





        }
    }
}
