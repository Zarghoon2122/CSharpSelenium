using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumNUnitFramework.Utilities;
using SeleniumNUnitFramework.PageObjects;

namespace SeleniumNUnitFramework.Tests
{
    public class E2ETest : BaseClass
    {
        [Test]

        public void E2EFlow()
        {
            var loginPage = new LoginPage();
            var productPage = new Products();
            var wait = new WaitMethods();
            var checkOutPage = new CheckOutPage();
            var confirmationPage = new ConfirmationPage();

            string[] expectedProducts = { "iphone X", "Blackberry" };
            string[] actualProducts = new string[2];

            //Page login
            loginPage.LogIn();

            //Add product to the cart
            productPage.AddProductsInCart();

            //Wait for checkout button to visible
            wait.WaitForElementDisplay(By.PartialLinkText("Checkout"));

            IList<IWebElement> products = productPage.getCards();

            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(product.FindElement(productPage.getCardTitle()).Text))
                {
                    product.FindElement(productPage.addToCartButton()).Click();
                }
            }

            //Checkout product
            productPage.checkOut();

            IList<IWebElement> checkoutCard = checkOutPage.getCarts();

            for (int i = 0; i < checkoutCard.Count; i++)
            {
                actualProducts[i] = checkoutCard[i].Text;
            }

            Assert.That(actualProducts, Is.EqualTo(expectedProducts));
         
            //Click checkout button in the checkout page
            checkOutPage.chechOut();

            //Select country from list
            confirmationPage.SelectCountry();

            wait.WaitForElementDisplay(By.LinkText("India"));

            //Click on the country
            confirmationPage.ClickCountry();

            //Click purchase button
            confirmationPage.PurchaseButton();

            //Verfiy 'Success' message appears after clicking on 'Purchase' button
            confirmationPage.ConfirmationMessageDisplay();
        }
    }
}