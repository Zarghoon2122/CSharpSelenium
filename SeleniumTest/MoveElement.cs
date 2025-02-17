using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;

namespace SeleniumTest
{
    public class MoveElement
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/#/index";
        }

        [Test]

        public void MoveElementTest()
        {
            Actions a = new Actions(driver);
            a.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
            //driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a")).Click();

            //Click element using 'MoveToElement' action class
            a.MoveToElement(driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a"))).Click().Perform();
            
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