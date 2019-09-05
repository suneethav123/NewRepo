using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

//This page  is Select Your Tickets page where Plus & Minus sign buttons are displayed to add tickets

namespace Cinemark.com.cinemark.pages
{
    class SelectTickets
    {
        private WebDriverWait wait;

        [FindsBy(How = How.XPath, Using = "//a[@class = 'qadd plusMinus']")]
        private IWebElement PlusAddTicketsSign;

        [FindsBy(How = How.XPath, Using = "//a[@class='qadd plusMinus clicked']")]
        private IWebElement AddExtraPlusTicketSign;

        [FindsBy(How = How.Id, Using = "btnAddToCart")]
        private IWebElement AddTicketsToCartBtn;

        [FindsBy(How = How.Id, Using = "btnAddToCart")]
        private IWebElement AddTicketsToCartBtnSiteA;

        [FindsBy(How = How.Id, Using = "btnCompletePurchase")]
        private IWebElement CompletePurchaseBtn;

        [FindsBy(How = How.Id, Using = "UseCreditsCheckbox")]
        private IWebElement CheckBoxApplyCredits;

        
        


        [Obsolete]
        public SelectTickets(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Obsolete]
        public void AddOneTicket()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@class = 'qadd plusMinus']")));
            PlusAddTicketsSign.Click();
                
        }

        public void AddAnotherTicket()
        {
            AddExtraPlusTicketSign.Click();
        }

        public void ApplyCreditCheckBox()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("UseCreditsCheckbox")));
            CheckBoxApplyCredits.Click();
        }

        public void AddTicketsToCart()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnAddToCart")));
            AddTicketsToCartBtn.Click();
        }



        

        public void CompletePurchase()
        {
            CompletePurchaseBtn.Click();
        }

        

        


    }
}
