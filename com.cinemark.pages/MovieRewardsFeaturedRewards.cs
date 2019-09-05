using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

//This is the Connection page displayed once the user is signed in

namespace Cinemark.com.cinemark.pages
{
    class MovieRewardsFeaturedRewards
    {
        WebDriverWait wait;

        [FindsBy(How = How.LinkText, Using = ("Your Account"))]
        private IWebElement YourAcctLink;

        [FindsBy(How = How.XPath, Using = "(//span[@class='dashboard-cardnumber'])[2]")]
        private IWebElement RewardsAvailable;

        [FindsBy(How = How.XPath, Using = "//span[@class='dashboard-cardnumber mcCreditsAvailable']")]
        private IWebElement CreditsAvailable;

        [FindsBy(How = How.XPath , Using = "(//span[@class='dashboard-cardnumber'])[1]")]
        private IWebElement PointsAvailabe;

        [FindsBy(How = How.XPath, Using = "(//span[@class='dashboard-cardnumber'])[3]")]
        private IWebElement TicketsAvailable;

        [FindsBy(How = How.XPath, Using = "(//div[@class = 'rewardName rewardLoggedIn'])[1]")]
        private IWebElement MovieTicketRewardLink;

        [FindsBy(How = How.CssSelector, Using = "#divRegistrationContainer > div.col-sm-8.col-sm-push-4.contentMain > form > div > div.redeemContainer > input")]
        private IWebElement MovieTicketRewardBtn;


        [Obsolete]
        public MovieRewardsFeaturedRewards(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }


        public IWebElement GetYourAccountLink()
        {
            return YourAcctLink;
        }

        [Obsolete]
        public IWebElement GetCheckingCredits()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='dashboard-cardnumber mcCreditsAvailable']")));
            return CreditsAvailable;
        }

        [Obsolete]
        public IWebElement GetCheckingPoints()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//span[@class='dashboard-cardnumber'])[1]")));
            return PointsAvailabe;
        }

        [Obsolete]
        public IWebElement GetCheckingTickets()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//span[@class='dashboard-cardnumber'])[3]")));
            return TicketsAvailable;
        }

        [Obsolete]
        public IWebElement GetCheckingRewards()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//span[@class='dashboard-cardnumber'])[2]")));
            return RewardsAvailable;
        }

        public void FeaturedRewardLinks()
        {
            MovieTicketRewardLink.Click();
            MovieTicketRewardBtn.Click();
        }
    }
}

