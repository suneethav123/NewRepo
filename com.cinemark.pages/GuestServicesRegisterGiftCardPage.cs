using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  This page is Register a Gift card page

namespace Cinemark.com.cinemark.pages
{
    class GuestServicesRegisterGiftCardPage
    {
        [FindsBy(How = How.Id, Using = "tbRegisterGiftCardName")]
        private IWebElement NameYourCard;

        [FindsBy(How = How.Id, Using = "tbRegisterGiftCardNumber")]
        private IWebElement GiftCardNumber;

        [FindsBy(How = How.Id, Using = "btnRegister")]
        private IWebElement SaveBtn;

        [Obsolete]
        public GuestServicesRegisterGiftCardPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void RegisterGiftCard(string GCName,string CardNum)
        {
            NameYourCard.SendKeys(GCName);
            GiftCardNumber.SendKeys(CardNum);
            SaveBtn.Click();
        }
    }
}
