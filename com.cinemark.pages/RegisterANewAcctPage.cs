using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Cinemark.com.cinemark.pages
{
    class RegisterANewAcctPage
    {

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement txtEmail;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement txtPassword;

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        private IWebElement txtConfirmPassword;

        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement txtFirstName;

        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement txtLastName;

        [FindsBy(How = How.Id, Using = "Phone")]
        private IWebElement txtPhone;

        [FindsBy(How = How.Id, Using = "ZipCode")]
        private IWebElement txtZipCode;

        [FindsBy(How = How.Id, Using = "registrationButton")]
        private IWebElement btnRegister;

        [FindsBy(How = How.CssSelector, Using = "body > form > div > div.buttons > input.cnkBtnStd")]
        private IWebElement btnIAgree;

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(7) > div.col-sm-8.contentMain > h3")]
        private IWebElement MessageEmailVerificationText;






        [Obsolete]
        public RegisterANewAcctPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void RegisterNewAcct(string email,string password,string confirmPass,string fname,string lname,string phone,string zip)
        {
            txtEmail.SendKeys(email);
            txtPassword.SendKeys(password);
            txtConfirmPassword.SendKeys(confirmPass);
            txtFirstName.SendKeys(fname);
            txtLastName.SendKeys(lname);
            txtPhone.SendKeys(phone);
            txtZipCode.SendKeys(zip);
            btnRegister.Click();
            btnIAgree.Click();
            btnIAgree.Click();

        }

        public void RegisterDuplicateNewAcct(string email, string password, string confirmPass, string fname, string lname, string phone, string zip)
        {
            txtEmail.SendKeys(email);
            txtPassword.SendKeys(password);
            txtConfirmPassword.SendKeys(confirmPass);
            txtFirstName.SendKeys(fname);
            txtLastName.SendKeys(lname);
            txtPhone.SendKeys(phone);
            txtZipCode.SendKeys(zip);
            btnRegister.Click();
        }

            public  IWebElement GetMessageEmailVerificationText()
        {
           return  MessageEmailVerificationText;
        }


    }
}
