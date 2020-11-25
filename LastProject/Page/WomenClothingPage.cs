using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastProject.Page
{
    public class WomenClothingPage : BasePage
    {
        private const string PageAddress = "https://duefashion.com/collections/women";
        private IWebElement SortByDropDown => Driver.FindElement(By.CssSelector(".js-dropdown__label"));
        private IWebElement SelectFromLowToHighest => Driver.FindElement(By.CssSelector("#sort_by > li:nth-child(5)"));

        public WomenClothingPage(IWebDriver webdriver) : base(webdriver) { }

        public WomenClothingPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public WomenClothingPage SortByFromLowestToHighest()
        {
            SortByDropDown.Click();
            GetWait();
            SelectFromLowToHighest.Click();
            return this;
        }
    }
}
