using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using System.Security.Cryptography;

namespace SeleniumTest
{
    class HandleAlertAction
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }

        [Test]

        public void HandleAlert()
        {
            String name = "Ahmad";
            driver.FindElement(By.CssSelector("#name")).SendKeys(name);
            driver.FindElement(By.CssSelector("input[onclick*='displayConfirm']")).Click();

            //This method will switch to alert pop up window and store the text of the pop up in 'alertText' 
            String alertText = driver.SwitchTo().Alert().Text;

            //This will switch to alert pop up and will 'OK' button
            driver.SwitchTo().Alert().Accept();

            //This 'StringAssert' will look for the name 'Ahmad' in the whole text from pop up that we store in the 'alertText'
            StringAssert.Contains(name, alertText);
        }

        [Test]

        public void AutoSuggestiveDropDown()
        {
            driver.FindElement(By.Id("autocomplete")).SendKeys("ind");
            Thread.Sleep(3000);

            IList<IWebElement> options = driver.FindElements(By.CssSelector(".ui-menu-item div"));
            foreach(IWebElement option in options)
            {
                if (option.Text.Equals("India")) ;
                {
                    option.Click();

                    // We use 'Attribute' to get the value 'india' from the dynamic drop down
                    // In run time '.Text' method won't work.
                    TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));
                }
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (driver != null)
            {
                driver.Quit();    // Close the browser
                driver.Dispose(); // Explicitly dispose of WebDriver
                driver = null;    // Clear the reference
            }
        }
    }
}
