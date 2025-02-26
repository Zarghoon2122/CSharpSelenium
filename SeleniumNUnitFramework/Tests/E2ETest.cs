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

            string[] expectedProducts = { "iphone X", "Blackberry" };
            string[] actualProducts = new string[2];

            loginPage.LogIn();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                    TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
                }
            }

            driver.FindElement(By.PartialLinkText("Checkout")).Click();
            IList<IWebElement> checkoutCard = driver.FindElements(By.CssSelector("h4 a"));

            for (int i = 0; i < checkoutCard.Count; i++)
            {
                actualProducts[i] = checkoutCard[i].Text;
            }

            Assert.AreEqual(expectedProducts, actualProducts);
            driver.FindElement(By.CssSelector(".btn-success")).Click();
            driver.FindElement(By.Id("country")).SendKeys("ind");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.FindElement(By.LinkText("India")).Click();
            //driver.FindElement(By.CssSelector("label[for*='chechbox2']")).Click();
            driver.FindElement(By.CssSelector("[value='Purchase']")).Click();

            //Verfiy 'Success' message appears after clicking on 'Purchase' button
            string confirmText = driver.FindElement(By.CssSelector(".alert-success")).Text;
            StringAssert.Contains("Success", confirmText);
        }
    }
}