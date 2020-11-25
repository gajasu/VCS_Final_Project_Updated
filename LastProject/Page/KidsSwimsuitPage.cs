using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastProject.Page
{
    public class KidsSwimsuitPage : BasePage
    {
        private const string PageAddress = "https://duefashion.com/collections/kids-swimsuits";
        private IWebElement firstSwimsuit => Driver.FindElement(By.CssSelector("#CollectionLoop > div:nth-child(1)"));
        private WebDriverWait wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        private IWebElement QuickViewButton => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='trigger-quick-view caps']")));
        private IWebElement AddToCartButton => Driver.FindElement(By.XPath("//button[@type='submit']"));

        public KidsSwimsuitPage(IWebDriver webdriver) : base(webdriver) { }

        public KidsSwimsuitPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public KidsSwimsuitPage AddToCart()
        {
            OpenQuickView();
            AddToCartButton.Click();
            return this;
        }

        private KidsSwimsuitPage OpenQuickView()
        {
            Actions builder = new Actions(Driver);
            builder.MoveToElement(firstSwimsuit).Perform();
            QuickViewButton.Click();
            return this;
        }
    }
}
