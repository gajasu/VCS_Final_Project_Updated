using LastProject.Drivers;
using LastProject.Page;
using LastProject.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastProject.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static WomenClothingPage womenClothingPage;
        public static WomenClothSortedByPricePage womenClothSortedByPricePage;
        public static CheapestClothPage cheapestTShirtPage;
        public static ShoppingCartPage shoppingCartPage;
        public static ShippingPage shippingPage;
        public static WomenSwimsuitPage womenSwimsuitPage;
        public static KidsSwimsuitPage kidsSwimsuitPage;
        public static CheckOutPage checkOutPage;
        public static ConfirmShippingPage confirmShippingPage;
        public static SearchBoxPage searchBoxPage;

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetIncognitoChrome();
            womenClothingPage = new WomenClothingPage(driver);
            womenClothSortedByPricePage = new WomenClothSortedByPricePage(driver);
            cheapestTShirtPage = new CheapestClothPage(driver);
            shoppingCartPage = new ShoppingCartPage(driver);
            shippingPage = new ShippingPage(driver);
            womenSwimsuitPage = new WomenSwimsuitPage(driver);
            kidsSwimsuitPage = new KidsSwimsuitPage(driver);
            checkOutPage = new CheckOutPage(driver);
            confirmShippingPage = new ConfirmShippingPage(driver);
            searchBoxPage = new SearchBoxPage(driver);
        }

        [TearDown]
        public static void TakeScreeshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreeshot(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}
