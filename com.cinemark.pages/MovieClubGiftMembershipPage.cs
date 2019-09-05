using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Cinemark.com.cinemark.pages
{
    class MovieClubGiftMembershipPage
    {

        [FindsBy(How = How.Id, Using = "ProductVariantId")]
        private IWebElement MembershipLength;

        [FindsBy(How = How.Id, Using = "Recipient_Name")]
        private IWebElement RecipientName;

        [FindsBy(How = How.Id, Using = "Recipient_EmailAddress")]
        private IWebElement RecipientEmailAddr;

        [FindsBy(How = How.Id, Using = "DeliveryDateCalendarImg")]
        private IWebElement DeliverDateCalenderImage;

        [FindsBy(How = How.CssSelector, Using = "#DeliveryDateCalendarDiv > div > div > a.ui-datepicker-next.ui-corner-all")]
        private IWebElement DeliveryDateCalenderNextMonthArrow;

        [FindsBy(How = How.Id, Using = "DeliveryDateCalendarDiv")]
        private IWebElement DeliveryDateCalenderNextMonth;
                        
        [FindsBy(How = How.Id, Using = "Recipient_Message")]
        private IWebElement Message;

        [FindsBy(How = How.CssSelector, Using = "#MovieClubGiftMembershipForm > fieldset > div.buttons.text-center > input")]
        private IWebElement AddToCartBtn;

        [FindsBy(How = How.XPath, Using = "//div[@class='fmd']")]
        private IWebElement RecipientGiftCode;

        [Obsolete]
        public MovieClubGiftMembershipPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void BuyGiftMembership(string name,string email,string message)
        {
            SelectElement selectElement = new SelectElement(MembershipLength);
            selectElement.SelectByValue("9000");
            RecipientName.SendKeys(name);
            RecipientEmailAddr.SendKeys(email);

            //Picking a date in Delivery Date textbox

            DeliverDateCalenderImage.Click();
            DeliveryDateCalenderNextMonthArrow.Click();
            IList<IWebElement>columns = DeliveryDateCalenderNextMonth.FindElements(By.TagName("td"));

            foreach(IWebElement X in columns)
            {
                string date = X.Text;

                if(date.Equals("1"))
                {
                    X.Click();
                    break;
                }

            }


            Message.SendKeys(message);
            AddToCartBtn.Click();

        }

        public IWebElement GetRecipientGiftCode()
        {
            return RecipientGiftCode;
        }
    }
}
