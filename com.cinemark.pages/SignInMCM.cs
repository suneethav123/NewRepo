using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

//This page if for Sign In Movie Club Member from Connections

namespace Cinemark.com.cinemark.pages
{
    class SignInMCM
    {
        private IWebDriver driver;
        private Actions action;

        [FindsBy(How = How.Id, Using = "registerLink")]
        private IWebElement RegisterNewAcctLink;

        [FindsBy(How = How.Id, Using = "resendLink")]
        private IWebElement ResendLink;

        [FindsBy(How = How.Id, Using = "resetPasswordLink")]
        private IWebElement ResetPasswordLink;

        [FindsBy(How = How.Id, Using = ("EmailAddress"))]
        private IWebElement EmailAddr;

        [FindsBy(How = How.Id, Using = ("Password"))]
        private IWebElement Password;

        [FindsBy(How = How.Id, Using = ("signInButton"))]
        private IWebElement SignInBtn;

        [FindsBy(How = How.CssSelector, Using = "body > form > div > div.buttons > input.cnkBtnStd")]
        private  static IWebElement AgreeBtn;

        

        [FindsBy(How = How.CssSelector, Using = "#registrationForm > div.validation-summary-errors > ul > li")]
        private IWebElement ErrMsgDuplicateAcct;

        [Obsolete]
        public SignInMCM(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
           // this.driver = driver;
            action = new Actions(driver);
        }

        public void SignInMovieClubmember(string email,string password)
        {
            EmailAddr.SendKeys(email);
            Password.SendKeys(password);
            SignInBtn.Click();          
        }

        public IWebElement GetAgreeBtn()
        {
            return AgreeBtn;
        }

        public void AgreeButton()
        {
           AgreeBtn.Click();                         
        }

        public void PolicyButton()
        {
            AgreeBtn.Click();
        }



        public void Register()
        {
            RegisterNewAcctLink.Click();
        }

        public IWebElement GetResendLink()
        {
            return ResendLink;
        }

        public void ResetPasswordLnk()
        {
            ResetPasswordLink.Click();
        }

        public IWebElement GetErrMsgDuplicateAcct()
        {
            return ErrMsgDuplicateAcct;
        }

       public static bool AgreeButtonDisplayed()
        {
            bool AgreeBtnPresent ; 
            try
            {
                AgreeBtnPresent = AgreeBtn.Displayed;
                AgreeBtnPresent = true;
            }
            catch (Exception e)
            {
                AgreeBtnPresent = false;
            }


            return AgreeBtnPresent;
        } 

    }
}
