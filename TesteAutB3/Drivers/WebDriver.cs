using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TesteAutB3.Drivers
{
    public class WebDriver
    {
        private static IWebDriver _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                ChromeOptions options = new ChromeOptions();
                //options.AddArgument("--disable-popup-blocking");
                _driver = new ChromeDriver(options);
                _driver.Manage().Window.Maximize();              
            }
            return _driver;
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
            }

        }

    }
}
