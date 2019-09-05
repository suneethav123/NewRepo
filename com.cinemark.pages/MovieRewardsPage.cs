using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

/*   This is Movie Rewards page */

namespace Cinemark.com.cinemark.pages
{
    class MovieRewardsPage
    {
        private IWebDriver driver;
        WebDriverWait wait;
        IJavaScriptExecutor js;
        private Actions action;


        [FindsBy(How = How.Id, Using = "discountCode")]
        private IWebElement DiscountCodeTxtBox;

        [FindsBy(How = How.CssSelector, Using = "#ValidateGiftCodeForm > fieldset > div.validateGiftCodeButtons > input")]
        private IWebElement RedeemBtn;

        [FindsBy(How = How.Id, Using = "btnApplyCode")]
        private IWebElement RedeemGiftBtn;

        [FindsBy(How = How.CssSelector, Using = "#movieRewardsSidebar > div.dashboard-top-module > div > div.dashboard-card-buttons > div:nth-child(3) > a > div > span.dashboard-cardnumber.mcCreditsAvailable")]
        private IWebElement CreditsAvailableText;

        [FindsBy(How = How.Id, Using = "manage-membership-link")]
        private IWebElement ManageYourMembershipLnk;

        [FindsBy(How = How.Id, Using = "cancelMembershipLink")]
        private IWebElement CancelMembershipLnk;

        [FindsBy(How = How.Id, Using = "cancelSubscriptionConfirmation")]
        private IWebElement YesCancelMembershipLnk;

        [FindsBy(How = How.Id, Using = "btnCancelChangeMembership")]
        private IWebElement NoThnxIDontWantToKeepMyBenefitsLnk;

        [FindsBy(How = How.Id, Using = "btnChangeMembership")]
        private IWebElement SwitchMembershipLnk;

        [FindsBy(How = How.Id, Using = "upgradeMembershipMYM")]
        private IWebElement UpgradeMembershipLnk;

        [FindsBy(How = How.Id, Using = "reactivateMembership")]
        private IWebElement ReactivateMembershipBtn;

        [FindsBy(How = How.XPath, Using = "(//div[@class='planValue'])[2]")]
        private IWebElement MembershipPlanValue;

        

        [FindsBy(How = How.CssSelector, Using = "#yourMembership > div.memberStatusHeadline > h2")]
        private IWebElement MemberStatusSuccessMsg;



        [Obsolete]
        public MovieRewardsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            js = (IJavaScriptExecutor)driver;
            this.driver = driver;

        }


        
        public IWebElement GetCreditsAvailableText()
        {
            return CreditsAvailableText;
        }

        /*  This method is to redeem movie club membership gift code for an existing Movie Club member*/
        public void RedeemMovieClubGiftCode(string code)
        {
            DiscountCodeTxtBox.SendKeys(code);
            RedeemBtn.Click();
            RedeemGiftBtn.Click();

        }

        public void ManageYourMembership()
        {
            ManageYourMembershipLnk.Click();
        }


        /* Change to Lite membership */
        [Obsolete]
        public void ChangeToLiteMembership()
        {
            SwitchMembershipLnk.Click();                             

        }

        /* Change to Full membership */
        public void ChangeToFullMembership()
        {
            ManageYourMembershipLnk.Click();
            UpgradeMembershipLnk.Click();

        }


        /* Cancelling Membership completely  */
        [Obsolete]
        public void CancelFullMembership()
        {                      
            wait.Until(ExpectedConditions.ElementToBeClickable(SwitchMembershipLnk));
            NoThnxIDontWantToKeepMyBenefitsLnk.Click();

        }


        /*  Below method is used for all cancellations & also Lite */
        /*  This is the 1st step in cancellation */
        [Obsolete]
        public void CancelMembership()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(ManageYourMembershipLnk));
            ManageYourMembershipLnk.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(CancelMembershipLnk));
            CancelMembershipLnk.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(YesCancelMembershipLnk));
            js.ExecuteScript("arguments[0].click()", YesCancelMembershipLnk);


        }


        /* Reactivating after cancellation*/
        [Obsolete]
        public void ReactivateMbrship()
        {
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("reactivateMembership")));
            js.ExecuteScript("arguments[0].click()", ReactivateMembershipBtn);
            //ReactivateMembershipBtn.Click();
           
            
        }

        [Obsolete]
        public void WaitToGetSuccessMessage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#yourMembership > div.memberStatusHeadline > h2")));
        }

        public IWebElement GetMemberStatusHeadLine()
        {
            return MemberStatusSuccessMsg;
        }

        [Obsolete]
        public void WaitForMembershipPlanValue()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//div[@class='planValue'])[2]")));
        }

        [Obsolete]
        public IWebElement GetMembershipPlanValue()
        {
            
            return MembershipPlanValue;
        }



    }
}
