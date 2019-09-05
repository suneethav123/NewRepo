using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This ia a Gift Cards page where registered gift cards are seen


namespace Cinemark.com.cinemark.pages
{
    class GiftCardPage
    {

        [FindsBy(How = How.Id, Using = "btnUnregister")]
        private IWebElement UnRegisterBtn;

        [FindsBy(How = How.LinkText, Using = "Reload")]
        private IWebElement ReloadBtn;

        [FindsBy(How = How.XPath, Using = "//h5[@class= 'col - xs - 5 col - lg - 4 text - right']")]
        private IWebElement GCBalanceAmt;

        [FindsBy(How = How.XPath, Using = "(//h5)[3]")]
        private IWebElement GCOriginalBalance;

        [Obsolete]
        public GiftCardPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public IWebElement GetUnRegisterBtn()
        {
            return UnRegisterBtn;
        }

        public void ReloadButton()
        {
            ReloadBtn.Click();
        }

        public IWebElement GetGCBalanceAmt()
        {
            return GCBalanceAmt;
        }

        public IWebElement GetGCOriginalBalance()
        {
            return GCOriginalBalance;
        }
    }
}
