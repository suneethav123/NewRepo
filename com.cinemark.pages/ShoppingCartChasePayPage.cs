using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemark.com.cinemark.pages
{
    class ShoppingCartChasePayPage
    {
        private IWebDriver driver;
        IJavaScriptExecutor js;

        [FindsBy(How = How.Id, Using = "ChasePayButton")]
        private IWebElement ChasePayLnk;

        [FindsBy(How = How.CssSelector, Using = "body > div.jpmc-pwc-modal > div > iframe")]
        private IWebElement Frame1;

        [FindsBy(How = How.XPath, Using = "//div[@class='selectedOption']")]
        private IWebElement User;

        

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement Password;

        [FindsBy(How = How.Id, Using = "btnLogin")]
        private IWebElement SignIn;

        [FindsBy(How = How.Id, Using = "btnLogin")]
        private static IWebElement SignIn2;

        [FindsBy(How = How.Id, Using = "btnContinue")]
        private IWebElement NextBtn;

        [FindsBy(How = How.Id, Using = "ValidationSummary")]
        private static IWebElement Errors;



        [Obsolete]
        public ShoppingCartChasePayPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            

            js = (IJavaScriptExecutor)driver;
            this.driver = driver;
        }

        public void ChaseLink()
        {
            ChasePayLnk.Click();
        }

        public void SwitchFrame()
        {
            driver.SwitchTo().Frame(Frame1);
        }

        public void ChasePay()
        {

            /* SelectElement select = new SelectElement(User);
             select.SelectByIndex(3);*/

            User.Click();
            Password.SendKeys("password");
            
        }

        public void SignInButton()
        {
            // SignIn.Click();
            js.ExecuteScript("arguments[0].click()", SignIn);
        }

        public void NextButton()
        {
            NextBtn.Click();
            driver.SwitchTo().DefaultContent();
        }


        

        public static bool MissingCardFieldErrorsDisplayed()
        {
            bool ErrorsPresent;
            try
            {
                ErrorsPresent = Errors.Displayed;

            }
            catch(Exception e)
            {
                ErrorsPresent = false;
            }
            return ErrorsPresent;
        }




    }
}
