using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This page is for SuperSavers purchase

namespace Cinemark.com.cinemark.pages
{
    class SupersaversPage
    {
        [FindsBy(How = How.LinkText, Using = "Supersavers")]
        private IWebElement SupersaversLnk;

        [FindsBy(How = How.Id, Using = "SelectedStateCode")]
        private IWebElement ShippingState;

        [FindsBy(How = How.Id, Using = "quantity6554")]
        private IWebElement PlatinumSupersaver;

        [FindsBy(How = How.Id, Using = "quantity6553")]
        private IWebElement ConcessionSupersaver;

        [FindsBy(How = How.CssSelector, Using = "#errorSummary > li")]
        private IWebElement MinimunCountErrMsg;

        [FindsBy(How = How.XPath, Using = "//input[@class='btn cnkBtnPrim btn-flex']")]
        private IWebElement AddToCartBtn;

        [Obsolete]
        public SupersaversPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void SupersaversLink()
        {
            SupersaversLnk.Click();
        }

        public void SupersaversPurchase(string PlatinumSS)
        {
            SelectElement select = new SelectElement(ShippingState);
            select.SelectByText("Texas");

            PlatinumSupersaver.SendKeys(PlatinumSS);

            AddToCartBtn.Click();

        }

        public IWebElement GetErrorMessage()
        {
           return  MinimunCountErrMsg;
        }


    }
}
