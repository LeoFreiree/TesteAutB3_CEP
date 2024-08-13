using OpenQA.Selenium;
using TesteAutB3.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebDriver = TesteAutB3.Drivers.WebDriver;

namespace TesteAutB3.Pages
{
    public class HomePage
    {
        IWebDriver webDriver = Drivers.WebDriver.GetDriver();

        //mapeamento da pagina principal dos correios
        public IWebElement cxPesquisaCep => webDriver.FindElement(By.XPath("//li[4]/a/span"));
        public IWebElement cxInserirCodRastreio => webDriver.FindElement(By.CssSelector("#objetos"));        
        public IWebElement btnRastrear => webDriver.FindElement(By.XPath("//form/div/div/button/i"));
        public IWebElement btnConsultar => webDriver.FindElement(By.CssSelector("#b-pesquisar"));
    }
}
