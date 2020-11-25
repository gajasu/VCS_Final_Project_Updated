using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastProject.Page
{
    public class CheapestClothPage : BasePage
    {
        private const string PageAddress = "https://duefashion.com/collections/women/products/plain-near-auvers-unisex-t-shirt";
        private SelectElement SizeDropDown => new SelectElement(Driver.FindElement(By.CssSelector("#SingleOptionSelector-0-1337033818159")));
        private IWebElement AddToCartButton => Driver.FindElement(By.XPath("//button[@type='submit']"));

        public CheapestClothPage(IWebDriver webdriver) : base(webdriver) { }

        public CheapestClothPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public CheapestClothPage ChooseAvailableSize(string size)
        {
            SizeDropDown.SelectByValue(size);
            if (AddToCartButton.Text.Equals("Sold Out"))
            {
                ChooseMSize();
            }
            return this;
        }

        private void ChooseMSize()
        {
            string size = "M";
            SizeDropDown.SelectByValue(size);
        }

        public CheapestClothPage AddToCart()
        {
            AddToCartButton.Click();
            WaitForShoppingCartPopUp();
            return this;
        }

        private void WaitForShoppingCartPopUp()
        {
            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 5));
            wait.Until(d => d.FindElement(By.CssSelector("#CartPopoverCont > div > div > div.product__add__success__content")));
        }
    }
}
