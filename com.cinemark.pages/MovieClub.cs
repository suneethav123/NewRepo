using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

//This is the Movie Club page where user enters Zipcode to go further

namespace Cinemark.com.cinemark.pages
{
    class MovieClub
    {
        WebDriverWait wait;
      

        [FindsBy(How = How.Id, Using = "billingZipBtn")]
        private IWebElement BillingZipBtn;

        [FindsBy(How = How.Id, Using = "billingZip")]
        private IWebElement BillingZip;

        [FindsBy(How = How.Id, Using = "billingZipUpdateBtn")]
        private IWebElement BillingZipUpdateBtn;

        [FindsBy(How = How.Id, Using = "billingZipPriceAddToCartBtn")]
        private IWebElement BillingZipPriceAdd;

        [Obsolete]
        public MovieClub(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        public IWebElement GetBillingZipBtn()
        {
            return BillingZipBtn;
        }

        [Obsolete]
        public void UpdateBillingZip(string Zip)
        {




            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("billingZipBtn")));
            BillingZipBtn.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("billingZip")));
            BillingZip.SendKeys(Zip);

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("billingZipUpdateBtn")));
            BillingZipUpdateBtn.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("billingZipPriceAddToCartBtn")));
            BillingZipPriceAdd.Click();



        }
    }

}
