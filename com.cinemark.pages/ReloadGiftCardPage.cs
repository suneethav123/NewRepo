using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemark.com.cinemark.pages
{
    class ReloadGiftCardPage
    {

        [FindsBy(How = How.Id, Using = "ReloadAmount")]
        private IWebElement ReloadAmountTxtBox;

        [FindsBy(How = How.XPath, Using = "//input[@class = 'btn cnkBtnPrim btn-flex']")]
        private IWebElement AddToCartBtn;

        [FindsBy(How = How.CssSelector, Using = "#ValidationSummary > ul > li")]
        private IWebElement ErrorMsg;


        // This is the reloaded amount finally displayed on the Purchase Confirmation 
        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'text-right')])[2]")]
        private IWebElement ReloadedAmount;

        [Obsolete]
        public ReloadGiftCardPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void ReloadGC(string Amount)
        {
            ReloadAmountTxtBox.Clear();
            ReloadAmountTxtBox.SendKeys(Amount);
           
        }

        public void AddToCart()
        {
            AddToCartBtn.Click();
        }

        public IWebElement GetErrorMsg()
        {
            return ErrorMsg;
        }

        public IWebElement GetReloadedAmount()
        {
            return ReloadedAmount;
        }

        
    }
}
