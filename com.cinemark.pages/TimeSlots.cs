using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

//This page displays Movies day & Timings

namespace Cinemark.com.cinemark.pages
{
    class TimeSlots
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private Actions action;
        IJavaScriptExecutor js;

        [FindsBy(How = How.Id, Using = "changeLocationDropdown")]
        private IWebElement ChangeLocDropDwn1;

        [FindsBy(How = How.Id, Using = "SearchText")]
        private IWebElement SearchTextBox1;

        [FindsBy(How = How.CssSelector, Using = "#TheaterSearchForm > button")]
        private IWebElement SearchSubmitBtn1;



        [FindsBy(How = How.Id, Using = "1")]
        private IWebElement MovieDay;

        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'vr-showtime')])[1]")]
        private IWebElement VirtualRealityMovieTime;

        [FindsBy(How = How.XPath, Using = "(//div[@class='showtime'])[5]")]
        private IWebElement MovieTime;

      

        [FindsBy(How = How.XPath, Using = "(//div[@class='showtime'])[2]")]
        private IWebElement ReservedSeatingMovieTime;







        [Obsolete]
        public TimeSlots(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            js = (IJavaScriptExecutor)driver;
            this.driver = driver;
            action = new Actions(driver);
        }


        // Virtual Reality Movie time selection

        [Obsolete]
        public void VirtualRealityMovieTimeSelection()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(MovieDay));
            //Thread.Sleep(5000);
            MovieDay.Click();



            Thread.Sleep(2000);
            // Utils.WaitForLoad(driver);

            //wait.Until(ExpectedConditions.ElementToBeClickable(MovieTime));


            //js.ExecuteScript("arguments[0].click()", MovieTime);
            action.Click(VirtualRealityMovieTime).Perform();

        }

        // Regular Movie time selection

        [Obsolete]
        public void MovieTimeSelection()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(MovieDay));
            MovieDay.Click();



            Thread.Sleep(2000);

            action.Click(MovieTime).Perform();

        }


        //Reserved Seating Movie Time Selection

        [Obsolete]
        public void ReservedSeatingMovieTimeSelection()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(MovieDay));
            MovieDay.Click();



            Thread.Sleep(2000);

            action.Click(ReservedSeatingMovieTime).Perform();

        }


        // Choosing the zipcode 75093
        public void LocationDropDown1()
        {
            ChangeLocDropDwn1.Click();
            SearchTextBox1.SendKeys("75093");
            SearchSubmitBtn1.Submit();

        }

        public void RefreshWindow()
        {
            driver.Navigate().Refresh();
        }








    }

}
