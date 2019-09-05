using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemark.com.cinemark.pages
{
    class BulkGiftCardsPage
    {

        [FindsBy(How = How.Id, Using = "Quantity")]
        private IWebElement GiftCardQuantity;

        [FindsBy(How = How.Id, Using = "ListPrice")]
        private IWebElement CardValue;

        [FindsBy(How = How.CssSelector, Using = "#GiftcardsForm > fieldset > div.buttons.text-center > input")]
        private IWebElement AddToCart;

        [FindsBy(How = How.CssSelector, Using = "#ValidationSummary > ul > li")]
        private IWebElement ErrMessage;


        [Obsolete]
        public BulkGiftCardsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);     
        }

        public void PurchaseBulkGiftCard(string Quantity , string Value)
        {
            GiftCardQuantity.Clear();
            GiftCardQuantity.SendKeys(Quantity);
            CardValue.Clear();
            CardValue.SendKeys(Value);
            AddToCart.Click();

        }

        public IWebElement GetErrorMessage()
        {
            return ErrMessage;
        }


    }
}
