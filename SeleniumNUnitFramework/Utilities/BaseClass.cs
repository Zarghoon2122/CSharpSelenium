using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;

namespace SeleniumNUnitFramework.Utilities
{
    public class BaseClass : DriverHelper
    {
        [SetUp]
        public void StartBrowser()
        {
            // in 'ConfigiruationManager' file under 'AppSettings' in 'key' browser value is set to 'Chrome'
            //So, chrome is set to launch by defult
            String browserName = ConfigurationManager.AppSettings["browser"];
            InitializeBrowser(browserName);

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise";
        }

        //You should pass the browser name via string 
        public void InitializeBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            {
                driver.Quit();
            }
        }
    }
}