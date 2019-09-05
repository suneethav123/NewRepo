using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

/*  This is the Rewards Information page */
/*  User is landed on this page from Rewards link on Home page */

namespace Cinemark.com.cinemark.pages
{
    class MovieRewardsInfoPage
    {

        /* [FindsBy(How = How.LinkText, Using = "Learn More")]
         private IWebElement lnkLearnMore; */


        [FindsBy(How = How.XPath, Using = "(//a[@class='cnkBtnCTA'])[2]")]
        private IWebElement lnkLearnMore;




        [FindsBy(How = How.CssSelector, Using = "body > div.container.container-grey > div.mr-info-member-welcome > span > a")]
        private IWebElement lnkSignIn;

        [FindsBy(How = How.LinkText, Using = "Join Now")]
        private IWebElement lnkJoinNow;


        public MovieRewardsInfoPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void LearnMoreLink()
        {
            lnkLearnMore.Click();
        }

        public void SignInLink()
        {
            Thread.Sleep(2000);
            lnkSignIn.Click();
        }

        public void JoinNowLink()
        {
            lnkJoinNow.Click();
        }


    }
}
