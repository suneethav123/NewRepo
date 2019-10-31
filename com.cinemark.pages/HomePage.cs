using Cinemark.com.cinemark.testscripts;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using Cinemark.Base;
using Cinemark.Utilities;

//This is the initial landing page where all the links are present

namespace Cinemark.com.cinemark.pages
{
    public class HomePage 
    {
       
        WebDriverWait wait;
        private Actions action;
             

        [FindsBy(How = How.LinkText, Using = "movie club")]
        private IWebElement MovieClubLink;

        [FindsBy(How = How.LinkText, Using = "movies")]
        private IWebElement MoviesLink;

        [FindsBy(How = How.LinkText, Using = "theatres")]
        private IWebElement Theatreslink;

        [FindsBy(How = How.LinkText, Using = "connections")]
        private IWebElement ConnectionsLink;

        [FindsBy(How = How.LinkText, Using = "movie rewards")]
        private IWebElement MovieRewardsLink;

        [FindsBy(How = How.LinkText, Using = "Gifts")]
        private IWebElement GiftsLink;

        [FindsBy(How = How.LinkText, Using = "Guest Services")]
        private IWebElement GuestServicesLink;

        [FindsBy(How = How.Id, Using = "signinLink")]
        private IWebElement SignInLnk;

        [FindsBy(How = How.Id, Using = "myCinemarkDropdown")]
        private IWebElement YourAccountLnk;

        [FindsBy(How = How.LinkText, Using = "Sign Out")]
        private IWebElement SignOutLnk;

        [FindsBy(How = How.LinkText, Using = "Gift Cards")]
        private IWebElement YourAcctGiftCards;

        [FindsBy(How = How.LinkText, Using = "Discounts")]
        private IWebElement DiscountsLnk;

        [FindsBy(How = How.LinkText, Using = ("Your Account"))]
        private IWebElement YourAcctLink;

        [Obsolete]
        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));

            action = new Actions(driver);

        }

        [Obsolete]
        public void GoToMovieClub()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(MovieClubLink));
            MovieClubLink.Click();
        }

        [Obsolete]
        public void GoToMovies()
        {
            //Thread.Sleep(3000);
          // wait.Until(ExpectedConditions.ElementToBeClickable(MoviesLink));
            wait.Until(ExpectedConditions.ElementExists(By.LinkText("movies")));
            MoviesLink.Click();
        }

        [Obsolete]
        public void GoToTheatres()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Theatreslink));
            Theatreslink.Click();
        }

        public void GoToConnections()
        {
            ConnectionsLink.Click();
        }

        [Obsolete]
        public void GoToMovieRewards()
        {
            //Thread.Sleep(5000);
            //wait.Until(ExpectedConditions.ElementToBeClickable(MovieRewardsLink));
            wait.Until(ExpectedConditions.ElementExists(By.LinkText("movie rewards")));
            MovieRewardsLink.Click();
        }


        public void GoToMovieRewardsAction()
        {
            action.Click(MovieRewardsLink).Perform();
        }
        

        [Obsolete]
        public void GoToGifts()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(GiftsLink));
            GiftsLink.Click();
        }

        public void GoToSignIn()
        {
            SignInLnk.Click();

        }

        public void YourAccount()
        {
            YourAccountLnk.Click();
        }

        public void SignOut()
        {
            YourAccountLnk.Click();
            SignOutLnk.Click();
        }

        public void GoToGuestServices()
        {
            GuestServicesLink.Click();
        }

        public void GoToYourAcctGiftCards()
        {
            YourAcctGiftCards.Click();
        }

        public void GoToDiscounts()
        {
            DiscountsLnk.Click();
        }

        public IWebElement GetYourAccountLink()
        {
            return YourAcctLink;
        }


    }
}
