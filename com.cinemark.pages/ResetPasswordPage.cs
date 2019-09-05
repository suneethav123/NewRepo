using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

// This page has Reset Password Request

namespace Cinemark.com.cinemark.pages
{
    class ResetPasswordPage
    {
        [FindsBy(How = How.Id, Using = "EmailAddress")]
        private IWebElement EmailAddrTxtBox;

        [FindsBy(How = How.Id, Using = "resetPasswordRequestButton")]
        private IWebElement ContinueBtn;

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(7) > div > h3")]
        private IWebElement ResetMsg;

        [Obsolete]
        public ResetPasswordPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public IWebElement GetResetMsg()
        {
            return ResetMsg;
        }

        public void ResetPassword(string Email)
        {
            EmailAddrTxtBox.SendKeys(Email);
            ContinueBtn.Click();
        }
    }
}
