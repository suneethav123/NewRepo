using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

//This page has movies displayed when navigated thru Theatres

namespace Cinemark.com.cinemark.pages
{
    class TheatreFeaturedMovies
    {
        WebDriverWait wait;

        [FindsBy(How = How.LinkText, Using = "Book Your Virtual Reality Experience QA")]
        private IWebElement StarWarsMovie;

        [Obsolete]
        public TheatreFeaturedMovies(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Obsolete]
        public void MoviePick()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(StarWarsMovie));
            StarWarsMovie.Click();
        }
    }
}
