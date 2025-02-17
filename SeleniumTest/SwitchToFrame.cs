using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTest
{
    class SwitchToFrame
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

        public void SwitchToFrameTest()
        {
            //Scroll to frame below before swithing

            //Method for frame
            IWebElement frameScroll = driver.FindElement(By.Id("courses-iframe"));
            
            //Code for switching to frame using 'JavaScriptExecutor'
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", frameScroll);

            // You can swith to Frame by id, name, index. in below method I used Id in the argument
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.LinkText("All Access Plan")).Click();
            //Verify text in the after clicking on the 'All Access Plan' with the below code. 'h1' is the header tag
            //Remember "h1" is tag name inside the frame only
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
            Thread.Sleep(3000);

            //Below code will bring you back to the main page
            driver.SwitchTo().DefaultContent();

            //After Switching to main, this method will print information of the header of the main page
            //Because the header name in the Frame and in the main page are the same.
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
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