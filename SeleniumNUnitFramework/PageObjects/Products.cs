using OpenQA.Selenium;
using SeleniumNUnitFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitFramework.PageObjects
{
    class Products : DriverHelper
    {

        //Elements
        public IWebElement btnCheckout => driver.FindElement(By.CssSelector(".btn-success"));
        public IWebElement btnHomeCheckout => driver.FindElement(By.PartialLinkText("Checkout"));
        public IWebElement txtCountry => driver.FindElement(By.Id("country"));
        public IList<IWebElement> cards => driver.FindElements(By.TagName("app-card"));
        public IWebElement checkOutButton => driver.FindElement(By.PartialLinkText("Checkout"));
        By cardTitle => By.CssSelector(".card-title");
        By addToCart => By.CssSelector(".card-footer button");

        //Methods
        string[] expectedProducts = { "iphone X", "Blackberry" };
        string[] actualProducts = new string[2];
       
        public void AddProductsInCart()
        {
            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                    TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
                }
            }
        }

        public IList<IWebElement> getCards()
        {
            return cards;
        }
        public By getCardTitle()
        {
            return cardTitle;
        }
        public By addToCartButton()
        {
            return addToCart;
        }
        public void checkOut()
        {
            checkOutButton.Click();
        }
    }
}
