using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumNUnitFramework.Utilities;
using SeleniumNUnitFramework.PageObjects;
using System.Collections;

namespace SeleniumNUnitFramework.Tests
{
    //This will run all tests are within below class
    //[Parallelizable(ParallelScope.Children)]

    //This will run all tests within the same folder. Put below method in the test inside the same folder
    //[Parallelizable(ParallelScope.Self)]
    public class E2ETest : BaseClass
    {
        //TestCaseData class will help to add all test data for your test
        //Yeild: use for multiple 'return' method and it will wait until all 'return's have completed
        //IEnumerable: in below 'TestData' it returns multiple test data so we use 'IEnumerable' to collect all the data 
        //IEnumerable: if you returining multiple test data then we use 'IEnumerable'
        //[TestCase] if you have single parameter like "username, password" then you can use [TestCase]

        //Run all data sets of tets method in parallel
        //Run all test methods in one class parallel
        //Run all test files in project parallel

        public static IEnumerable TestData
        {
            get
            {
                yield return new TestCaseData(GetDataParser().extractData("username"), GetDataParser().extractData("password"), GetDataParser().extractDataArray("products"));
                yield return new TestCaseData(GetDataParser().extractData("wrong_username"), GetDataParser().extractData("wrong_password"), GetDataParser().extractDataArray("products"));
            }
        }

        //TestCaseSource: has the powerfull capability that will run multiple times with different data set
        //TestCaseSource: it encapsulate everything in a single method
        //You need to pass that test data below in 'TestCaseSource'
        //TestCaseSource expects method name as an input which have all the test data
        //TestCase: directy expect the data

        //This below method will run all tests in parallel that has multiple test data sets
        //[Parallelizable(ParallelScope.All)]
        [Test, TestCaseSource("TestData")]

        public void E2EFlow(String username, String password, String[] expectedProducts)
        {
            var loginPage = new LoginPage();
            var productPage = new Products();
            var wait = new WaitMethods();
            var checkOutPage = new CheckOutPage();
            var confirmationPage = new ConfirmationPage();

            //string[] expectedProducts = { "iphone X", "Blackberry" };
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

        [Test]
        public void Locator()
        {
            driver.FindElement(By.Id("username")).SendKeys("Ahmad Shinwari");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("Ahmad");
            driver.FindElement(By.Name("password")).SendKeys("12345");

            // css selector
            // tagname[attribute='value']
            // driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();

            //Find element by xpath through the parent tag by using forward '/'
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            // Xpath
            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();

            //Explicit wait method
            Thread.Sleep(3000);
            //Code will capture the String "alert-danger" using the 'Text' method into the varriable "errorMessage"
            String errorMessage = driver.FindElement(By.ClassName("alert-danger")).Text;
            //This will print the varriable in output
            TestContext.WriteLine(errorMessage);
        }
    }
}