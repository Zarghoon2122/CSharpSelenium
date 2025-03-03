using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace SeleniumNUnitFramework.Utilities
{
    internal class WaitMethods : DriverHelper
    {
        public static WebDriverWait Wait => GetWait();
        private static WebDriverWait GetWait()
        {
            var wait = new WebDriverWait(DriverHelper.driver, TimeSpan.FromSeconds(25));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait;
        }

        /*
        
        
    }

    public static Func<IWebDriver, IWebElement> ElementVisible(IWebElement element)
    {
        return (driver) =>
        {
            if (element.Displayed)
            {
                return element;
            }
            else
            {
                return null;
            }
        };
    }
        */

        public static Func<IWebDriver, IWebElement> ElementIsVisible(By locator)
        {
            return (driver) =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null; // Element not found yet — wait continues
                }
                catch (StaleElementReferenceException)
                {
                    return null; // Element became stale — wait continues
                }
            };
        }

        public void WaitForElementDisplay(By locator, int timeoutInSeconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}