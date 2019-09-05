using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cinemark.com.cinemark.pages
{
    class ShoppingCartVisaCheckoutPage
    {
        private IWebDriver driver;
        private Actions action;
        IJavaScriptExecutor js;


        //**********************************
        // Visa Checkout
        //**********************************

        [FindsBy(How = How.XPath, Using = "//img[@class='v-button']")]
        private IWebElement VisaCheckoutLnk;

        [FindsBy(How = How.Id, Using = "tabs__tab-id__0")]
        private IWebElement NewVisaCheckOutCustomer;

        [FindsBy(How = How.Id, Using = "tabs__tab-id__1")]
        private IWebElement ReturningVisaCheckOutCust;

        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement FirstName;

        [FindsBy(How = How.Id, Using = "lastName")]
        private IWebElement LastName;

        [FindsBy(How = How.Id, Using = "cardNumber-CC")]
        private IWebElement CCardNum;

        [FindsBy(How = How.Id, Using = "exp-date")]
        private IWebElement Expires;

        [FindsBy(How = How.Id, Using = "cvv")]
        private IWebElement CVV;

        [FindsBy(How = How.Name, Using = "btnContinue")]
        private IWebElement ContinueBtn;


        //**************************
        //Billing for Visa Checkout
        //**************************

        [FindsBy(How = How.Id, Using = "countryCombobox")]
        private IWebElement Country;

        [FindsBy(How = How.Id, Using = "line1")]
        private IWebElement AddrLine1;

        [FindsBy(How = How.Id, Using = "city")]
        private IWebElement City;

        [FindsBy(How = How.Id, Using = "stateProvinceCode")]
        private IWebElement State;

        [FindsBy(How = How.Id, Using = "postalCode")]
        private IWebElement ZipCode;

        [FindsBy(How = How.Id, Using = "phone-number-field")]
        private IWebElement Phone;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement Email;

        [FindsBy(How = How.Id, Using = "vcop-src-frame")]
        private IWebElement Frame1;

        [Obsolete]
        public ShoppingCartVisaCheckoutPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;

            
            js = (IJavaScriptExecutor)driver;

            action = new Actions(driver);

        }

        public void VisaCheckout()
        {
            VisaCheckoutLnk.Click();
        }

        public void ReturningVisaCheckoutCust()
        {
            ReturningVisaCheckOutCust.Click();
        }

        public void ReturningEmailId(string email)
        {
            
            Email.SendKeys(email);
            Email.SendKeys(Keys.Enter);
        }

        public void NewVisaCheckout()
        {
            NewVisaCheckOutCustomer.Click();
        }

        public void SwitchToFrame()
        {
            driver.SwitchTo().Frame(Frame1);
        }
        

        public void VisaCheckoutInfo1(string First,string Last,string Card ,string ExpDate,string cvv)
        {
            driver.SwitchTo().Frame("vcop-src-frame");
            FirstName.Clear();
            FirstName.SendKeys(First);
            LastName.Clear();
            LastName.SendKeys(Last);
            CCardNum.Clear();
            CCardNum.SendKeys(Card);
            Expires.SendKeys(ExpDate);
            CVV.SendKeys(cvv);
            ContinueBtn.Click();

        }

        public void BillingForVisaCheckout(string Addr1,string city,string state,string zip,string phone,string email)
        {
            AddrLine1.Clear();
            AddrLine1.SendKeys(Addr1);
            City.Clear();
            City.SendKeys(city);
            State.Clear();
            State.SendKeys(state);
            ZipCode.Clear();
            ZipCode.SendKeys(zip);
            Phone.Clear();
            Phone.SendKeys(phone);
            Email.Clear();
            Email.SendKeys(email);
            ContinueBtn.Click();

        }

        [Obsolete]
        public void ButtonContinue()
        {
            Thread.Sleep(3000);
            //action.Click(ContinueBtn).Perform();
            //ContinueBtn.Click();

            js.ExecuteScript("arguments[0].click()", ContinueBtn);
        }

    }
}
