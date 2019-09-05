using Cinemark.com.cinemark.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* This test is to add a movie ticket using the Theatre link from HomePage  */

namespace Cinemark.com.cinemark.testscripts
{
    class AddAMovieTest
    {
        IWebDriver driver;
        private HomePage HP;
        private ChooseTheatre CT;
        private TheatreFeaturedMovies TF;
        private TimeSlots TS;
        private SelectTickets ST;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://qasiteb.usa.cinemark.com";
        }

        [Test]
        public void TicketTest()
        {
            HP = new HomePage(driver);
            CT = new ChooseTheatre(driver);
            TF = new TheatreFeaturedMovies(driver);
            TS = new TimeSlots(driver);
            ST = new SelectTickets(driver);

            HP.GoToTheatres();
            CT.TheatreSelection();
            TF.MoviePick();
            TS.MovieTimeSelection();
            ST.AddTicketsToCart();
        }

    }
}
