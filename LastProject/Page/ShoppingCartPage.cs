using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastProject.Page
{
    public class ShoppingCartPage : BasePage
    {
        private const string PageAddress = "https://duefashion.com/cart/";
        private IWebElement ItemName => Driver.FindElement(By.CssSelector("#CartOuter > table > tbody > tr > td.desc > a"));
        private IWebElement KidsItem => Driver.FindElement(By.CssSelector("#CartOuter > table > tbody > tr:nth-child(1) > td.desc > a > small"));
        private IWebElement KidsItemPrice => Driver.FindElement(By.CssSelector("#CartOuter > table > tbody > tr:nth-child(1) > td.price.item__price > p"));
        private IWebElement WomenItem => Driver.FindElement(By.CssSelector("#CartOuter > table > tbody > tr:nth-child(2) > td.desc > a > small"));
        private IWebElement WomenItemPrice => Driver.FindElement(By.CssSelector("#CartOuter > table > tbody > tr:nth-child(2) > td.price.item__price > p"));
        private IWebElement CheckOutButton => Driver.FindElement(By.CssSelector("#Checkout"));

        public ShoppingCartPage(IWebDriver webdriver) : base(webdriver) { }

        public ShoppingCartPage NavigateToDefaultPage()
        {
            GetWait();
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public ShoppingCartPage CheckIfMyItemWasAdded(string itemName)
        {
            GetWait();
            Assert.That(ItemName.Text.Contains(itemName));
            return this;
        }

        public ShoppingCartPage CheckIfWomenSwimsuitMoreExpensiveThanKids()
        {
            if (KidsItem.Text.Contains("116 (5-6y)") && WomenItem.Text.Contains("S"))
            {
                string kidsOriginalPrice = KidsItemPrice.Text.Replace("€", "");
                string kidsPreparedPrice = kidsOriginalPrice.Replace(",00", "");
                int kidsItemPrice = Int32.Parse(kidsPreparedPrice);

                string womenOriginalPrice = WomenItemPrice.Text.Replace("€", "");
                string womenPreparedPrice = womenOriginalPrice.Replace(",00", "");
                int womenItemPrice = Int32.Parse(womenPreparedPrice);

                Assert.IsTrue(kidsItemPrice < womenItemPrice, "Women swimsuit cheaper than kids!");
            }
            return this;
        }


        public ShoppingCartPage ClickCheckOut()
        {
            CheckOutButton.Click();
            return this;
        }
    }
}
