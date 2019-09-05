using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

/*  This is a Shopping Cart for Guest CheckOut  */

namespace Cinemark.com.cinemark.pages
{
    class ShoppingCartGuestCheckout
    {
        [FindsBy(How = How.Id, Using = "GuestCheckout")]
        private IWebElement GuestCheckOutBtn;

        [FindsBy(How = How.Id, Using = "EmailAddress")]
        private IWebElement EmailAddr;

        [Obsolete]
        public ShoppingCartGuestCheckout(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        

        public void GuestCheckOut(string email)
        {
            GuestCheckOutBtn.Click();
            EmailAddr.SendKeys(email);
        }

        public void CheckOutGuest()
        {
            GuestCheckOutBtn.Click();
        }

        public void GuestCheckoutEmail(string email)
        {
            EmailAddr.SendKeys(email);
        }
    }
}
