using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

//This page is displayed once a NMC member is created & tickets are added to the cart

namespace Cinemark.com.cinemark.pages
{
    class ShoppingCart
    {
        WebDriverWait wait;

        [FindsBy(How = How.Id, Using = "SummaryTotal")]
        private IWebElement TotalSummary;

        [FindsBy(How = How.CssSelector, Using = "#ConfirmationTotalPurchaseAmount > h2")]
        private IWebElement TotalPurchaseAmount;

        [FindsBy(How = How.XPath, Using = "(//div[@class='col-xs-4'])[1]")]
        private IWebElement MovieCreditTicket;

        [FindsBy(How = How.XPath, Using = "(//div[@class='col-xs-4'])[2]")]
        private IWebElement MovieClubAddOn;

        [FindsBy(How = How.Id, Using = "SummarySFTotal")]
        private IWebElement MovieClubMemberOnlineFees;

        [FindsBy(How = How.Id, Using = "SummarySubTotal")]
        private IWebElement PricewithNoCredits;

       

        [FindsBy(How = How.LinkText, Using = "Sign In")]
        private IWebElement SignIn;

        [FindsBy(How = How.Id, Using = "btnCompletePurchase")]
        private IWebElement CompletePurchaseBtn;


        // This is for error messages for multiple fields missing on CreditCard Purchases but all the error messages togehter
        [FindsBy(How = How.Id, Using = "ValidationSummary")]
        private IWebElement ValidationErrMsgs;


        //This is for error message for any single field value missing on CreditCard purchases
        [FindsBy(How = How.CssSelector, Using = "#ValidationSummary > ul > li")]
        private IWebElement ErrorMessage;

        // This is for error messages for multiple fields missing on CreditCard Purchases but the error messages is specific for the missing field in the group of error messages.
        // Missing CreditCard#
        [FindsBy(How = How.CssSelector, Using = "#ValidationSummary > ul > li:nth-child(1)")]
        private IWebElement CreditCardMissingErrMsg;

        //This is for error messages for multiple fields missing on CreditCard Purchases but the error messages is specific for the missing field in the group of error messages.
        // Missing Billing ZIP
        [FindsBy(How = How.CssSelector, Using = "#ValidationSummary > ul > li:nth-child(2)")]
        private IWebElement ZipMissingErrMsg;

        //This is for error messages for multiple fields missing on CreditCard Purchases but the error messages is specific for the missing field in the group of error messages.
        // Missing Credit Card security Code
        [FindsBy(How = How.CssSelector, Using = "#ValidationSummary > ul > li:nth-child(3)")]
        private IWebElement SecurityCodeMissingErrMsg;




        internal void GuestCheckOut(string emailId)
        {
            throw new NotImplementedException();
        }

        //*****************
        //Shipping Address
        //*****************

        [FindsBy(How = How.Id, Using = "ShippingAddress1")]
        private IWebElement ShippingAddr1;

        [FindsBy(How = How.Id, Using = "ShippingCity")]
        private IWebElement ShippingCity;

        [FindsBy(How = How.Id, Using = "ShippingState")]
        private IWebElement ShippingState;

        [FindsBy(How = How.Id, Using = "ShippingPostalCode")]
        private IWebElement ShippingPostalCode;

        [FindsBy(How = How.Id, Using = "ShippingFirstName")]
        private IWebElement ShippingFirstName;

        [FindsBy(How = How.Id, Using = "ShippingLastName")]
        private IWebElement ShippingLastName;

        [FindsBy(How = How.Id, Using = "ShippingPhone")]
        private IWebElement ShippingPhone;

        [FindsBy(How = How.Id, Using = "ShippingMethod")]
        private IWebElement ShippingMethod;

        //*******************
        // Shopping Cart Icon
        //*******************

        [FindsBy(How = How.Id, Using = "cart")]
        private IWebElement CartIcon;


        //***********************************
        // Recurring Credit Card Information
        //***********************************

        [FindsBy(How = How.Id, Using = "CardNumber")]
        private IWebElement CardNumber;

        [FindsBy(How = How.Id, Using = "BillingPostalCode")]
        private IWebElement BillingZip;

        [FindsBy(How = How.Id, Using = "CardSecurityCode")]
        private IWebElement CardSecurityCode;


        


        [Obsolete]
        public ShoppingCart(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        // ******************
        // Getter Methods
        // ******************

        public IWebElement GetTotalSummary()
        {
            return TotalSummary;
        }

        public IWebElement GetTotalPurchaseAmount()
        {
            return TotalPurchaseAmount;
        }

        [Obsolete]
        public IWebElement GetMovieCreditTicket()
        {
            
            return MovieCreditTicket;
        }

        public IWebElement GetMovieClubAddOn()
        {
            
            return MovieClubAddOn;
        }

        public IWebElement GetMovieClubMemberOnlineFees()
        {
            return MovieClubMemberOnlineFees;
        }

        public IWebElement GetPriceWithNoCredits()
        {
            return PricewithNoCredits;
        }


        public IWebElement GetValidationErrMsgs()
        {
            return ValidationErrMsgs;
        }


        public IWebElement GetErrorMessage()
        {
            return ErrorMessage;
        }

        public IWebElement GetCreditCardMissingErrMsg()
        {
            return CreditCardMissingErrMsg;
        }

        public IWebElement GetZipMissingErrMsg()
        {
            return ZipMissingErrMsg;
        }

        public IWebElement GetSecurityCodeMissingErrMsg()
        {
            return SecurityCodeMissingErrMsg;
        }

        public IWebElement GetCardNumber()
        {
            return CardNumber;
        }

        public IWebElement GetCompletePurchase()
        {
            return CompletePurchaseBtn;
        }

        //*************************************

       

        public void CompletePurchase()
        {
            CompletePurchaseBtn.Click();
        }

        

         public void CreditCardNum(string Card)
        {

            CardNumber.SendKeys(Card);
        }

        public void ClearCreditcardNum()
        {
            CardNumber.Clear();
        }

        public void ClearBillingZip()
        {
            BillingZip.Clear();
        }

        public void BillingZipCode(string ZIP)
        {
            BillingZip.SendKeys(ZIP);
        }

        public void CCSecurityCode(string Code)
        {
            CardSecurityCode.SendKeys(Code);
        }

        // *****************************************
        // This method contains Shipping Information
        // *****************************************

        public void ShippingInfo(string Addr1,string City,string ZIP,string FName,string LName,string Phone)
        {
            ShippingAddr1.SendKeys(Addr1);
            ShippingCity.SendKeys(City);

            SelectElement selectState = new SelectElement(ShippingState);
            selectState.SelectByValue("TX");

            
            ShippingPostalCode.SendKeys(ZIP);
            ShippingFirstName.SendKeys(FName);
            ShippingLastName.SendKeys(LName);
            ShippingPhone.SendKeys(Phone);

            SelectElement selectShipMethod = new SelectElement(ShippingMethod);
            selectShipMethod.SelectByIndex(1);
            

        }

        


    }


}
