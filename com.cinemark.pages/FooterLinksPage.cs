using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This page contains the hyperlinks present in the Page footer

namespace Cinemark.com.cinemark.pages
{
    class FooterLinksPage
    {

        [FindsBy(How = How.LinkText, Using = "Register")]
        private IWebElement RegisterLink;

        [FindsBy(How = How.LinkText, Using = "Private Events")]
        private IWebElement PrivateEventsLink;

        [Obsolete]
        public FooterLinksPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void GoToRegister()
        {
            RegisterLink.Click();
        }

        public void GoToPrivateEvents()
        {
            PrivateEventsLink.Click();
        }
    }


}
