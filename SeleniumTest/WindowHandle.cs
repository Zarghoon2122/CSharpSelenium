using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTest
{
    class WindowHandle
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]

        public void WindowHandleTest()
        {
            //New will open after clicking the link
            driver.FindElement(By.ClassName("blinkingText")).Click();

            //This will verify that 2 windows are opened
            Assert.AreEqual(2, driver.WindowHandles.Count);

            //You can swith to the second window with below code, in '0' index parent window or main window is opened
            //driver.SwitchTo().Window(driver.WindowHandles[1]);

            // Or you can switch to another window with below code
            String childWindow = driver.WindowHandles[1];
            driver.SwitchTo().Window(childWindow);

            //Print some inoformation in the second page or child page
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);

            //Switch back to 'parent' or main window. 
            String parentWindow = driver.WindowHandles[0];
            driver.SwitchTo().Window(parentWindow);
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