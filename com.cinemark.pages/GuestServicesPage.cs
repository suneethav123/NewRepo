using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemark.com.cinemark.pages
{
    class GuestServicesPage
    {
        [FindsBy(How = How.XPath, Using = "(//span[@class= 'quickLinkTitle'])[3]")]
        private IWebElement RefundTicketsLink;

        [FindsBy(How = How.XPath, Using = "(//span[@class= 'quickLinkTitle'])[10]")]
        private IWebElement RegisterAGiftCardLink;

        [Obsolete]
        public GuestServicesPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void GoToRefundLink()
        {
            RefundTicketsLink.Click();
        }

        public void GoToRegisterGiftCardLink()
        {
            RegisterAGiftCardLink.Click();
        }
    }
}
