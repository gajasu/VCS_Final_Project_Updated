using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastProject.Page
{
    public class ConfirmShippingPage : BasePage
    {
        private const string PageAddress = "https://duefashion.com/9716432943/checkouts/1784b2ae42675ef8a7a9e4aa51a2e980?previous_step=contact_information&step=shipping_method";
        private IWebElement ContactField => Driver.FindElement(By.XPath("//div[@role='cell']"));
        private IWebElement ContinueToPaymentButton => Driver.FindElement(By.CssSelector("#continue_button > span"));

        public ConfirmShippingPage(IWebDriver webdriver) : base(webdriver) { }

        public ConfirmShippingPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public ConfirmShippingPage CheckIfContactDetailsSaved(string email)
        {
            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@role='cell']")));
            Assert.IsTrue(ContactField.Text.Equals("email"));
            return this;
        }
    }
}
