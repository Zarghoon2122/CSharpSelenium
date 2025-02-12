using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Collections;

namespace SeleniumTest
{
    class TableSort
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }

        [Test]

        public void TableSortTest()
        {
            //it will click '20' from the dropdown
            SelectElement dropDown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropDown.SelectByText("20");

            ArrayList a = new ArrayList();
            // step 1 - Get all the vegetables name into arraylist - A
            IList<IWebElement> veggies = driver.FindElements(By.XPath("//td[1]"));

            //The 'veggie' in every iteration from the web table veggies pick one veggie
            foreach(IWebElement veggie in veggies)
            {
                //it will add all the veggie in each iteration in 'a' arraylist in text form
                a.Add(veggie.Text);
            }

            //The element is String as we are storing and sorting the list in 'Text' form
            foreach (String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            // step 2 - Sort the arraylist - A
            
            TestContext.Progress.WriteLine("AFTER SORTING");

            a.Sort();
            // verify if it's sorted
            foreach(String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            // step 3 - Click on column sort button
            driver.FindElement(By.CssSelector("th[aria-label *= 'fruit name']")).Click();

            // step 4 - Get all the vegetables name into arraylist again after sorting - B
            ArrayList b = new ArrayList();

            IList<IWebElement> sortedveggies = driver.FindElements(By.XPath("//td[1]"));

            //The 'veggie' in every iteration from the web table veggies pick one veggie
            foreach (IWebElement veggie in sortedveggies)
            {
                //it will add all the veggie in each iteration in 'a' arraylist in text form
                b.Add(veggie.Text);
            }

            // arraylist A to B = equal
            Assert.AreEqual(a, b);
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
