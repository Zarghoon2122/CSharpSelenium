using OpenQA.Selenium;
using SeleniumNUnitFramework.Utilities;

namespace SeleniumNUnitFramework.PageObjects
{
    class LoginPage : DriverHelper
    {
        //Locators
        public IWebElement txtUser => driver.FindElement(By.Id("username"));
        public IWebElement txtPassword => driver.FindElement(By.Name("password"));
        public IWebElement chkBox => driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input"));
        public IWebElement btnSignIn => driver.FindElement(By.XPath("//input[@value='Sign In']"));
        
        //Methods
        public void LogIn()
        {
            txtUser.SendKeys("rahulshettyacademy");
            txtPassword.SendKeys("learning");
            chkBox.Click();
            btnSignIn.Click();
        }
    }
}
