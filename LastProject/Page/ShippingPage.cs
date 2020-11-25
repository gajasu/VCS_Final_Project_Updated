using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastProject.Page
{
    public class ShippingPage : BasePage
    {
        private const string PageAddress = "https://duefashion.com/pages/eager-to-receive-want-to-return-or-exchange";
        private IWebElement DeliveryToUkField => Driver.FindElement(By.CssSelector("#MainContent > section > p:nth-child(24)"));

        public ShippingPage(IWebDriver webdriver) : base(webdriver) { }

        public ShippingPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public ShippingPage ScrollToShippingAbroad()
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(DeliveryToUkField);
            actions.Perform();
            return this;
        }

        public ShippingPage CheckIfShippingToUkUpTo6WorkingDays()
        {
            if (DeliveryToUkField.Text.Contains("United Kingdom"))
            {
                Assert.IsTrue(DeliveryToUkField.Text.Contains("5-6 working days"));
            }
            return this;
        }
    }
}
