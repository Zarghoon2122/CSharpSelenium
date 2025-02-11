using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTest
{
    public class SeleniumTest
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            //'driver' is the object of the ChromeDriver and return type of the object is 'IWebdriver'
            //IWebDriver is an interface and it exposes some methods but can not give the body of the method it just provide signature
            //IWebDriver will expose below methods like 'click' but it won't tell what you to write to perform the 'click' operation
            //IWebDriver methods = getURL, click and etc.. 
            //Chromdriver.exe will get all the commands from Selenium and then Chromdriver.exe will pass all the commands to
            //Chrome web browser to perform all the commands in the browser.
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise";
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);

            if (driver != null)
            {
                //driver.Quit();    // Close the browser
                driver.Dispose(); // Explicitly dispose of WebDriver
                driver = null;    // Clear the reference
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

