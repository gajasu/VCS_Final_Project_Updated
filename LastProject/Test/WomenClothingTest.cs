using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastProject.Test
{
    public class WomenClothingTest : BaseTest
    {
        [Order(1)]
        [Test]
        public static void TestIfCheapestClothIsUnder35Eur()
        {
            womenClothingPage.NavigateToDefaultPage()
                .SortByFromLowestToHighest();
            womenClothSortedByPricePage.NavigateToDefaultPage()
                .CheckIfFirstProductUnder35Eur(35);
        }

        [Order(2)]
        [Test]
        public static void TestIfICanAddCheapestItemToCart()
        {
            womenClothSortedByPricePage.NavigateToDefaultPage()
                .SelectFirstItem();
            cheapestTShirtPage.ChooseAvailableSize("XL")
                .AddToCart();
            shoppingCartPage.NavigateToDefaultPage()
                .CheckIfMyItemWasAdded("Black Basic");
        }

        [Order(3)]
        [Test]
        public static void TestIfShippingToUkUpTo6WorkingDays()
        {
            shippingPage.NavigateToDefaultPage()
                .ScrollToShippingAbroad()
                .CheckIfShippingToUkUpTo6WorkingDays();
        }

        [Order(4)]
        [Test]
        public static void TestIfWomenSwimsuitMoreExpensiveThanKids()
        {
            womenSwimsuitPage.NavigateToDefaultPage()
                .AddToCart();
            kidsSwimsuitPage.NavigateToDefaultPage()
                .AddToCart();
            shoppingCartPage.NavigateToDefaultPage()
                .CheckIfWomenSwimsuitMoreExpensiveThanKids();
        }

        [Order(5)]
        [Test]
        public static void TestSearchBox()
        {
            searchBoxPage.NavigateToDefaultPage()
                .SearchForText("Swimsuit")
                .CheckIfSearchWordDisplayed();
        }

        [Order(6)]
        [Test]
        public static void TestIfMyShippingDetailsSaved()
        {
            womenSwimsuitPage.NavigateToDefaultPage()
                .AddToCart();
            shoppingCartPage.NavigateToDefaultPage()
                .ClickCheckOut();
            checkOutPage.NavigateToDefaultPage()
                .InsertAndSubmitShippingInfo("g.jasutyte@gmail.com", "Gabriele", "Jasutyte", "-", "Vilnius", "10", "Vilnius", "02220", "+37060000000");
            confirmShippingPage.NavigateToDefaultPage()
                .CheckIfContactDetailsSaved("g.jasutyte@gmail.com");
        }
    }
}
