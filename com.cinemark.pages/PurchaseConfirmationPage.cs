using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemark.com.cinemark.pages
{
    class PurchaseConfirmationPage
    {

        [FindsBy(How = How.XPath, Using = "(//h5[contains(@class,'right')])[2]")]
        private IWebElement AmountCharged;

        [Obsolete]
        public PurchaseConfirmationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public IWebElement GetAmountCharged()
        {
            return AmountCharged;
        }
    }
}
