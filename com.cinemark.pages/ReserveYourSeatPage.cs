using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemark.com.cinemark.pages
{
    class ReserveYourSeatPage
    {

        [FindsBy(How = How.Id, Using = "row2col15")]
        private IWebElement SeatA1;

        [FindsBy(How = How.Id, Using = "btnReserveSeats")]
        private IWebElement ReserveSelectedSeatsBtn;

        [Obsolete]
        public ReserveYourSeatPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void SeatSelection()
        {
            SeatA1.Click();
        }

        public void ReserveSelectedSeats()
        {
            ReserveSelectedSeatsBtn.Click();
        }
    }
}
