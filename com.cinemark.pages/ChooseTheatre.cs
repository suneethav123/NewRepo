using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

//Selecting a Theatre

namespace Cinemark.com.cinemark.pages
{
    class ChooseTheatre
    {
        
        WebDriverWait wait;

        [FindsBy(How = How.Id, Using = "changeLocationDropdown")]
        private IWebElement ChangeLocDropDwn;

        [FindsBy(How = How.Id, Using = "SearchText")]
        private IWebElement SearchTextBox;

        [FindsBy(How = How.CssSelector, Using = "#TheaterSearchForm > button")]
        private IWebElement SearchSubmitBtn;



        [FindsBy(How = How.LinkText, Using = "Theater 944 QA POS 1.25.x")]
        private IWebElement Theatre944;


        [Obsolete]
        public ChooseTheatre(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void LocationDropDown()
        {
            ChangeLocDropDwn.Click();
            SearchTextBox.SendKeys("75093");
            SearchSubmitBtn.Click();

        }

        [Obsolete]
        public void TheatreSelection()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Theatre944));
            Theatre944.Click();
        }
    }
}
