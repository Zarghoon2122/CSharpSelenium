using OpenQA.Selenium;
using SeleniumNUnitFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitFramework.PageObjects
{
    public class CheckOutPage : DriverHelper
    {
        public IList<IWebElement> checkOutCards => driver.FindElements(By.CssSelector("h4 a"));
        public IWebElement checkOutButton => driver.FindElement(By.CssSelector(".btn-success"));

        public IList<IWebElement> getCarts()
        {
            return checkOutCards;
        }
        public void chechOut()
        {
            checkOutButton.Click();
        }
    }
}
