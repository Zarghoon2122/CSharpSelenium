using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTest
{
    class DragAndDrop
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://demoqa.com/droppable";
        }

        [Test]

        public void DragandDrop()
        {
            Actions a = new Actions(driver);
            a.DragAndDrop(driver.FindElement(By.Id("draggable")), driver.FindElement(By.Id("droppable"))).Perform();
            Thread.Sleep(3000);
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (driver != null)
            {
                //driver.Quit();    // Close the browser
                driver.Dispose(); // Explicitly dispose of WebDriver
                driver = null;    // Clear the reference
            }
        }

    }
}