using OpenQA.Selenium;
using SeleniumNUnitFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitFramework.PageObjects
{
    public class ConfirmationPage : DriverHelper
    {
        //Elements
        public IWebElement selectCountry => driver.FindElement(By.Id("country"));
        public IWebElement clickCountry => driver.FindElement(By.LinkText("India"));
        public IWebElement purchaseButton => driver.FindElement(By.CssSelector("[value='Purchase']"));
        
        //Methods
        public void SelectCountry()
        {
            selectCountry.SendKeys("ind");
        }
        public void ClickCountry()
        {
            clickCountry.Click();
        }
        public void PurchaseButton()
        {
            purchaseButton.Click();
        }
        public void ConfirmationMessageDisplay()
        {
            string confirmText = driver.FindElement(By.CssSelector(".alert-success")).Text;
            StringAssert.Contains("Success", confirmText);
        }
    }
}

