using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This page contains Shopping Cart with SuperSaver text boxes

namespace Cinemark.com.cinemark.pages
{
    class ShoppingCartSupersavers
    {

        [FindsBy(How = How.LinkText, Using = "Cinemark Supersaver")]
        private IWebElement SupersaverDropDownLnk;

        [FindsBy(How = How.Id, Using = "supersaverCode")]
        private IWebElement SupersaverCodeTxtBox;

        [FindsBy(How = How.Id, Using = "supersaverPin")]
        private IWebElement SupersaverPinTxtBox;

        [FindsBy(How = How.Id, Using = "supersaverSubmit")]
        private IWebElement SuperSaverApplyCode;

        [FindsBy(How = How.Id, Using = "errorSummary")]
        private IWebElement SuperSaverUsedErrMsg;


        //Below is the text that displays after a purchase is done using supersaver
        [FindsBy(How = How.XPath, Using = ("(//h5)[3]"))]
        private IWebElement SupersaverText;

        //Below is the text that displays after a purchase is done using Gift card
        [FindsBy(How = How.XPath, Using = ("(//h5)[5]"))]
        private IWebElement GiftCardText;

        [Obsolete]
        public ShoppingCartSupersavers(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);

        }

        public void SupersaversCode(string Code,string PIN)
        {
            SupersaverDropDownLnk.Click();
            SupersaverCodeTxtBox.SendKeys(Code);
            SupersaverPinTxtBox.SendKeys(PIN);
            SuperSaverApplyCode.Click();
        }

        public IWebElement GetSuperSaverUsedErrMsg()
        {
            return SuperSaverUsedErrMsg;
        }

        public IWebElement GetSupersaverText()
        {
            return SupersaverText;
        }

        public IWebElement GetGiftCardText()
        {
            return GiftCardText;
        }
    }
}
