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
    }
}
