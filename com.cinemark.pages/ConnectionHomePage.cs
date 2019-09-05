using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

//This is the Home Connections page where it is prompted to Sign In

namespace Cinemark.com.cinemark.pages
{
    class ConnectionHomePage
    {

        [FindsBy(How = How.PartialLinkText, Using = ("Sign In"))]
        private IWebElement SignInLink;

        //Sign in to"

        [Obsolete]
        public ConnectionHomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void SignInThruConnections()
        {
            SignInLink.Click();
        }
    }
}
