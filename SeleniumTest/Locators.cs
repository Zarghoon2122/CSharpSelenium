using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras;
namespace SeleniumTest
{
    public class Locators
    {

        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //Implicit wait method
            //Belwo method will implemet on every driver method
            //5 seconds wait will be added globally for every method
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise";
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

            /*
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.
            FindElement(By.Id("SignInBtn")), "Sign In"));
            */

            //Explicit wait method
            Thread.Sleep(3000);
            //Code will capture the String "alert-danger" using the 'Text' method into the varriable "errorMessage"
            String errorMessage = driver.FindElement(By.ClassName("alert-danger")).Text;
            //This will print the varriable in output
            TestContext.WriteLine(errorMessage);


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
