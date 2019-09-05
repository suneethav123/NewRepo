using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

//  This page contains Shopping Cart Gift drop down

namespace Cinemark.com.cinemark.pages
{
    class ShoppingCartGiftCard
    {

        [FindsBy(How = How.CssSelector, Using = "#paymentTypeAccordion > div:nth-child(1) > div.checkout__panelHeading > h4 > a > span")]
        private IWebElement GiftCardArrowDown;

        [FindsBy(How = How.Id, Using = "GiftCardList")]
        private IWebElement GiftcardListDropDwn;



        [Obsolete]
        public ShoppingCartGiftCard(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }


        public void GiftCardArrowDownClick()
        {
            GiftCardArrowDown.Click();
        }

        public void SelectGiftCard()
        {
            SelectElement select = new SelectElement(GiftcardListDropDwn);
            select.SelectByIndex(1);
        }
    }

    
}
