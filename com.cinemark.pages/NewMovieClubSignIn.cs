using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

//This is the page where initial Movie Club member can be added ,its actualy Shopping Cart page for New Movie Club Members
//Navigation Movie Club -> add zip 

namespace Cinemark.com.cinemark.pages
{
    class NewMovieClubSignIn
    {
        WebDriverWait wait;
 

        [FindsBy(How = How.Id, Using = "GuestCheckout")]
        private IWebElement CreateAnAcctBtn;

        [FindsBy(How = How.Id, Using = "EmailAddress")]
        private IWebElement EmailAddr;

        [FindsBy(How = How.Id, Using = "ConfirmEmailAddress")]
        private IWebElement ConfirmEmailAddr;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement UserPassword;

       /* [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        private IWebElement ConfirmPassword; */

        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement FirstName;

        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement LastName;

        [FindsBy(How = How.Id, Using = "Phone")]
        private IWebElement PhoneNumber;

        [FindsBy(How = How.Id, Using = "ZipCode")]
        private IWebElement ZipCode;

        [FindsBy(How = How.Id, Using = "CardNumber")]
        private IWebElement CardNumber;

        [FindsBy(How = How.Id, Using = "ExpirationMonth")]
        private IWebElement ExpMonth;

        [FindsBy(How = How.Id, Using = "ExpirationYear")]
        private IWebElement ExpYear;

        [FindsBy(How = How.Id, Using = "CardSecurityCode")]
        private IWebElement CardSecurityCode;

        [FindsBy(How = How.Id, Using = "BillingPostalCode")]
        private IWebElement BillingZipCode;

        [FindsBy(How = How.Id, Using = "TermsAndConditions")]
        private IWebElement TermsAndConditionCheckBox;

        [FindsBy(How = How.Id, Using = "btnCompletePurchase")]
        private IWebElement CompletePurchaseBtn;

        [FindsBy(How = How.XPath, Using = "(//h2[@class= 'top'])[1]")]
        private IWebElement SuccessMessage;

  
        [FindsBy(How = How.CssSelector, Using = "#ValidationSummary > ul > li:nth-child(1)")]
        private IWebElement MessageForDuplicateUser; 

        [FindsBy(How = How.LinkText, Using = "Choose Your Movie")]
        private IWebElement ChooseMovieBtn;

        [FindsBy(How = How.XPath, Using = "(//h2[@class= 'top'])[1]")]
        private IWebElement TicketPurchaseSuccessMsg;

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(7) > div.col-sm-4.sidebar > div:nth-child(1) > div.col-xs-8 > h3")]
        private IWebElement TicketConfirmationNumberText;

        [FindsBy(How = How.XPath ,Using = "//div[@class= 'loyaltyAccumulationHeadline']")]
        private IWebElement PointsEarnedText;

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(7) > div.col-sm-4.sidebar > div.contentModule.clearfix.checkoutviewcontainer > div:nth-child(3) > div > div.col-xs-8")]
        private IWebElement AddOnTicketsText;

        [FindsBy(How = How.CssSelector, Using = "#DiscountCodePanel > div > div.checkout__panelHeading > h4 > a")]
        private IWebElement PromoCodeDrpdown;

        [FindsBy(How = How.Id, Using = "DiscountCode")]
        private IWebElement PromoGiftCodeTxtBox;

        [FindsBy(How = How.Id, Using = "btnApplyCode")]
        private IWebElement ApplyCodeBtn;

        [FindsBy(How = How.XPath, Using = "//div[@class='fmd']")]
        private IWebElement RecipientGiftCode;



        [Obsolete]
        public NewMovieClubSignIn(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }


        

        public IWebElement GetSuccessMessage()
        {
            return SuccessMessage;
        }

        


        public IWebElement GetMessageForDuplicateUser()
        {
            return MessageForDuplicateUser;
        }

        public IWebElement GetTicketPurchaseSuccessMsg()
        {
            return TicketPurchaseSuccessMsg;
        }

        public IWebElement GetTicketConfirmationNumber()
        {
            return TicketConfirmationNumberText;
        }

        public void ChooseMovie()
        {
            ChooseMovieBtn.Click();
        }


        public IWebElement GetPointsEarned()
        {
            return PointsEarnedText;
        }

        public IWebElement GetAddOnTicketsText()
        {
            return AddOnTicketsText;
        }

        public IWebElement GetRecipientGiftCode()
        {
            return RecipientGiftCode;
        }

        

        

        /* Create Account */
        public void CreateAccount()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(CreateAnAcctBtn));
            CreateAnAcctBtn.Click();
        }

      

        /*  Account Information  */
        public void AccountInformation(string Email,string ConfirmEmail, string Pass)
        {
            EmailAddr.SendKeys(Email);
            ConfirmEmailAddr.SendKeys(ConfirmEmail);
            UserPassword.SendKeys(Pass);
            //ConfirmPassword.SendKeys(ConfirmPass);

        }


        /*  Personal Information */
        public void PersonalInformation(string Fname, string Lname, string Phone, string Zip)
        {
            FirstName.SendKeys(Fname);
            LastName.SendKeys(Lname);
            PhoneNumber.SendKeys(Phone);
            ZipCode.SendKeys(Zip);
        }


        /*  Recurring Payment  */
        public void RecurringPaymentInfo(string CardNum, string SecurityCode, string BillingZip)
        {
            CardNumber.SendKeys(CardNum);

            SelectElement selectMonth = new SelectElement(ExpMonth);
            selectMonth.SelectByValue("12");

            SelectElement selectYear = new SelectElement(ExpYear);
            selectYear.SelectByText("2021");

            BillingZipCode.SendKeys(BillingZip);
            CardSecurityCode.SendKeys(SecurityCode);

        }



        /*  Promo Code Info */
        public void PromoCodeInfo(string code)
        {
            PromoCodeDrpdown.Click();
            PromoGiftCodeTxtBox.SendKeys(code);
            ApplyCodeBtn.Click();

        }



        /*  Terms and Conditions */
        public void TermsAndConditions()
        {
            TermsAndConditionCheckBox.Click();
        }



        /*  Complete Purchase  */
        [Obsolete]
        public void CompletePurchase()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnCompletePurchase")));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnCompletePurchase")));
            CompletePurchaseBtn.Click();
        }







    }
}
