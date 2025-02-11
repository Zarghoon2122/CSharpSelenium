using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    public class DropDown
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise";
        }

        [Test]

        public void DropDownTest()
        {
            //Below is element found by 'Css' 'select' is the tag name and 'form-control' is the class name. need to add (.) before class
            IWebElement dropDown = driver.FindElement(By.CssSelector("select.form-control"));

            //This 'SelectElement' take web element 'dropDown' as an input and have to pass as an argument
            SelectElement select = new SelectElement(dropDown);

            //In th dropDoen the method 'SelectByText' will look for 'Teacher' and it will select it
            select.SelectByText("Teacher");

            //Select by value. Check the value in html and chose which value is there for consultant
            select.SelectByValue("consult");

            // 'SelectByIndex' will select the option by the number
            //Below code will select the the second option in the dropdown
            select.SelectByIndex(1);

            // Below locator has two elements and both elements will store in 'rdos' variable
            IList<IWebElement> rdos = driver.FindElements(By.CssSelector("input[type='radio']"));

            /*
            In the first iterate or run, the first locator will be picked and it will look if the value is
            equals to 'user' because we are looking for user 'radio button' and then it will click 
            on the element but if the value is not equal to 'user' then, it will iterate or run again and 
            look for the 'value' if it's equal to 'user' it will click in the element;

            foreach (IWebElement radioButton in rdos)
            {
                if (radioButton.GetAttribute("value").Equals("user"))
                {
                    radioButton.Click();
                }
            */

            driver.FindElement(By.XPath("(//span[@class='checkmark'])[2]")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));

            driver.FindElement(By.Id("okayBtn")).Click();
            Boolean result = driver.FindElement(By.Id("usertype")).Selected;

            Assert.That(result, Is.True);
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