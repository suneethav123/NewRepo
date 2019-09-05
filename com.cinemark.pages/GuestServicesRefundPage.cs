using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// This is a Refund Tickets page

namespace Cinemark.com.cinemark.pages

{
    internal class GuestServicesRefundPage
    {
        

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement EmailAddr;

        [FindsBy(How = How.Id, Using = "Last4CardNumber")]
        private IWebElement Last4NumbersOfCard;

        [FindsBy(How = How.Id, Using = "guestRefundButton")]
        private IWebElement SearchRefundableTicketsBtn;

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'btn cnkBtnStd btn-wide cnkBtnPrim')]")]
        private IWebElement RequestRefundBtn;

        [FindsBy(How = How.CssSelector, Using = "#ProcessRefundForm > fieldset > div > input")]
        private IWebElement RequestRefundSecondBtn;

        [FindsBy(How = How.XPath, Using = "(//h2[contains(@class,'top')])[1]")]
        private IWebElement RefundSuccessMsg;

        [FindsBy(How = How.XPath, Using = "(//h5[contains(@class,'right')])[3]")]
        private IWebElement RefundAmount;

        [FindsBy(How = How.CssSelector, Using = "#superSaverRefundModal > div > div > div.modal-content-header > h3")]
        private IWebElement UnableToRefundMsg;

       


        [Obsolete]
        public GuestServicesRefundPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }


        

        public void RefundInfo(string email, string Last4)
        {
            
            EmailAddr.SendKeys(email);
            Last4NumbersOfCard.SendKeys(Last4);
            SearchRefundableTicketsBtn.Click();
        }

        public void FirstRefundBtn()
        {
            RequestRefundBtn.Click();
        }

        public void SecondRefundBtn()
        {
            RequestRefundSecondBtn.Click();
        }

        


        public IWebElement GetRefundSuccessMsg()
        {
            return RefundSuccessMsg;
        }


        public IWebElement GetRefundAmount()
        {
            return RefundAmount;
        }

        public IWebElement GetUnableToRefundMsg()
        {
            return UnableToRefundMsg;
        }

        


    }

    


}

