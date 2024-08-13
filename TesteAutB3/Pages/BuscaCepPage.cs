using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAutB3.Pages
{
    public class BuscaCepPage
    {
        IWebDriver webDriver = Drivers.WebDriver.GetDriver();

        //mapeamento da pagina de busca cep dos correios
        public IWebElement cxInsiraCep => webDriver.FindElement(By.Id("endereco"));
        public IWebElement btnBuscar => webDriver.FindElement(By.Id("btn_pesquisar"));
        public IWebElement btnNovaBusca => webDriver.FindElement(By.Id("btn_nbusca"));
        public IWebElement msgResultado => webDriver.FindElement(By.TagName("h6"));
        public IWebElement tdLogradouro => webDriver.FindElement(By.XPath("//table[@id='resultado-DNEC']/tbody/tr/td"));
        public IWebElement tdLocalidade => webDriver.FindElement(By.XPath("//table[@id='resultado-DNEC']/tbody/tr/td[3]"));
        public IWebElement voltarPagInicialIcon => webDriver.FindElement(By.XPath("//section[@id='menu']/a[2]"));
    }
}
