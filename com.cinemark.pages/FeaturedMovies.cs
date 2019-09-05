using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

// Navigate thru Movies from HomePage
//Also when NMC member is added ,Clicking Choose Movie will land on this page

namespace Cinemark.com.cinemark.pages
{
    class FeaturedMovies
    {
        [FindsBy(How = How.XPath, Using = "(//a[contains(@class,'button col-xs-6')])[5]")]
        private IWebElement MovieSelectionTicketsBtn;

        [FindsBy(How = How.XPath, Using = "(//a[contains(@class,'button col-xs-6')])[1]")]
        private IWebElement ReservedSeatMovieTicketsBtn;

        [Obsolete]
        public FeaturedMovies(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void MovieSelection()
        {
            MovieSelectionTicketsBtn.Click();
        }

        public void ReservedSeatingMovie()
        {
            ReservedSeatMovieTicketsBtn.Click();
        }
    }
}
