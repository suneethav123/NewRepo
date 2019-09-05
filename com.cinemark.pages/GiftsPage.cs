using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

/*  This page is for the Gifts */

namespace Cinemark.com.cinemark.pages
{
    class GiftsPage
    {

        [FindsBy(How = How.PartialLinkText, Using = "Movie Club Gift")]
        private IWebElement MovieClubGiftLink;

        [FindsBy(How = How.LinkText, Using = "Bulk Orders")]
        private IWebElement BulkOrdersLink;

        [FindsBy(How = How.Id, Using = "tbGiftCardNumber")]
        private IWebElement CheckGCBalance;

        [FindsBy(How = How.Id, Using = "webBCSubmitId")]
        private IWebElement CheckBalanceBtn;

        [FindsBy(How = How.Id, Using = "txtBalanceAmount")]
        private IWebElement BalanceAmount;

        [Obsolete]
        public GiftsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void MovieClubGiftMembership()
        {
            MovieClubGiftLink.Click();
        }

        public void BulkOrders()
        {
            BulkOrdersLink.Click();
        }

        public void GCBalanceCheck(string card)
        {
            CheckGCBalance.SendKeys(card);
            CheckBalanceBtn.Click();

        }

        public IWebElement GetBalanceAmount()
        {
            return BalanceAmount;
        }
    }
}
