using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastProject.Page
{
    public class CheckOutPage : BasePage
    {
        private const string PageAddress = "https://duefashion.com/9716432943/checkouts/1784b2ae42675ef8a7a9e4aa51a2e980?step=contact_information";
        private IWebElement Email => Driver.FindElement(By.Id("checkout_email"));
        private IWebElement FirstName => Driver.FindElement(By.Id("checkout_shipping_address_first_name"));
        private IWebElement LastName => Driver.FindElement(By.Id("checkout_shipping_address_last_name"));
        private IWebElement Company => Driver.FindElement(By.Id("checkout_shipping_address_company"));
        private IWebElement Address => Driver.FindElement(By.Id("checkout_shipping_address_address1"));
        private IWebElement ApartmentNo => Driver.FindElement(By.Id("checkout_shipping_address_address2"));
        private IWebElement City => Driver.FindElement(By.Id("checkout_shipping_address_city"));
        private IWebElement Zip => Driver.FindElement(By.Id("checkout_shipping_address_zip"));
        private IWebElement PhoneNo => Driver.FindElement(By.Id("checkout_shipping_address_phone"));
        private IWebElement ContinueToShippingButton => Driver.FindElement(By.Id("continue_button"));
        private IWebElement SavePersonalInfoButton => Driver.FindElement(By.Id("checkout_remember_me"));
        public CheckOutPage(IWebDriver webdriver) : base(webdriver) { }

        public CheckOutPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public CheckOutPage InsertAndSubmitShippingInfo(string email, string firstName, string lastName, string company, string address, string appartmentNo, string city, string zip, string phoneNo)
        {
            Email.Clear();
            Email.SendKeys(email);
            FirstName.Clear();
            FirstName.SendKeys(firstName);
            LastName.Clear();
            LastName.SendKeys(lastName);
            Company.Clear();
            Company.SendKeys(company);
            Address.Clear();
            Address.SendKeys(address);
            ApartmentNo.Clear();
            ApartmentNo.SendKeys(appartmentNo);
            City.Clear();
            City.SendKeys(city);
            Zip.Clear();
            Zip.SendKeys(zip);
            PhoneNo.Clear();
            PhoneNo.SendKeys(phoneNo);

            ClickSavePersonalInfoButton();
            ContinueToShippingButton.Click();
            return this;
        }
        private CheckOutPage ClickSavePersonalInfoButton()
        {
            SavePersonalInfoButton.Click();
            return this;
        }
    }
}
