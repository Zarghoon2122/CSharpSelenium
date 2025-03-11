using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumNUnitFramework.Utilities;
using SeleniumNUnitFramework.PageObjects;
using System.Collections;

namespace SeleniumNUnitFramework.Tests
{
    public class E2ETest : BaseClass
    {
        //TestCaseData class will help to add all test data for your test
        //Yeild: use for multiple 'return' method and it will wait until all 'return's have completed
        //IEnumerable: in below 'TestData' it returns multiple test data so we use 'IEnumerable' to collect all the data 
        //IEnumerable: if you returining multiple test data then we use 'IEnumerable'
        //[TestCase] if you have single parameter like "username, password" then you can use [TestCase]
        public static IEnumerable TestData
        {
            get
            {
                yield return new TestCaseData ("rahulshettyacademy", "learning");
                yield return new TestCaseData ("rahulshettyacademy", "learning");
            }
        }

        //TestCaseSource: has the powerfull capability that will run multiple times with different data set
        //TestCaseSource: it encapsulate everything in a single method
        //You need to pass that test data below in 'TestCaseSource'
        //TestCaseSource expects method name as an input which have all the test data
        //TestCase: directy expect the data
        [Test, TestCaseSource("TestData")]

        public void E2EFlow(String username, String password)
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