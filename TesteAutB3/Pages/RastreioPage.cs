using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriver = TesteAutB3.Drivers.WebDriver;
using System.Collections.Generic;
using System;
using TesteAutB3.Drivers;

namespace TesteAutB3.Pages
{
    public class RastreioPage
    {
       IWebDriver webDriver = WebDriver.GetDriver();
       
        //mapeamento da pagina de rastrear objeto dos correios
        public IWebElement btnConsultar => webDriver.FindElement(By.Id("b-pesquisar"));
        public IWebElement msgResult => webDriver.FindElement(By.Id("alerta"));
    }
}

