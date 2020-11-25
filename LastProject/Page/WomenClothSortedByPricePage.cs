using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastProject.Page
{
    public class WomenClothSortedByPricePage : BasePage
    {
        private const string PageAddress = "https://duefashion.com/collections/women?sort_by=price-ascending";
        private IWebElement PriceField => Driver.FindElement(By.XPath("//span[@class='price']"));
        private IWebElement firstItemField => Driver.FindElement(By.CssSelector("#CollectionLoop > div:nth-child(1)"));

        public WomenClothSortedByPricePage(IWebDriver webdriver) : base(webdriver) { }

        public WomenClothSortedByPricePage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public WomenClothSortedByPricePage CheckIfFirstProductUnder35Eur(int iHaveMoney)
        {
            string originalPrice = PriceField.Text.Replace("€", "");
            string preparedPrice = originalPrice.Replace(",00", "");
            int lowestPrice = Int32.Parse(preparedPrice);
            Assert.IsTrue(lowestPrice <= iHaveMoney, $"No clothes for you! Cheapest item is: {PriceField.Text}");
            return this;
        }

        public WomenClothSortedByPricePage SelectFirstItem()
        {
            firstItemField.Click();
            return this;
        }
    }
}
