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
    public class SearchBoxPage : BasePage
    {
        private const string PageAddress = "https://duefashion.com/search";
        private IWebElement SearchBoxField => Driver.FindElement(By.CssSelector("#MainContent > section > div > form > input.search-box"));
        private IWebElement SearchButton => Driver.FindElement(By.XPath("//button[@class='search-submit']"));
        private IWebElement SearchMessage => Driver.FindElement(By.XPath("//div[@class='search-results-text theme gutter-bottom']"));
        private string searchKeyword;
        private IWebElement firstItemName => Driver.FindElement(By.CssSelector("#SearchLoop > div:nth-child(1)"));

        public SearchBoxPage(IWebDriver webdriver) : base(webdriver) { }

        public SearchBoxPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public SearchBoxPage SearchForText(string searchKeyword)
        {
            SearchBoxField.SendKeys(searchKeyword);
            this.searchKeyword = searchKeyword;
            SearchButton.Click();
            return this;
        }

        public SearchBoxPage CheckIfSearchWordDisplayed()
        {
            Assert.IsTrue(SearchMessage.Text.Equals($@"Your search for ""{ searchKeyword}"" revealed the following:"));
            Assert.IsTrue(firstItemName.Text.Contains($"{searchKeyword}"));
            return this;
        }
    }
}
