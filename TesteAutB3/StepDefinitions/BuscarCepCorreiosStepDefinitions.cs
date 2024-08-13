using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TesteAutB3.Assertions;
using TesteAutB3.Pages;
using TesteAutB3.Global;
using TesteAutB3.Drivers;
using WebDriver = TesteAutB3.Drivers.WebDriver;

namespace TesteAutB3.StepDefinitions
{
    [Binding]
    public class BuscarCepCorreiosStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public BuscarCepCorreiosStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        HomePage homePage = new HomePage();
        BuscaCepPage buscaCepPage = new BuscaCepPage();
        RastreioPage rastreioPage = new RastreioPage();

        Assertions.Asserts asserts = new Assertions.Asserts();

        [Given(@"Eu acessei o site dos correios")]
        public void GivenEuAcesseiOSiteDosCorreios()
        {
            asserts.VerifyPageTitle();
        }

        [When(@"eu seleciono a opção buscar CEP ou endereço")]
        public void WhenEuSelecionoAOpcaoBuscarCEPOuEndereco()
        {
            homePage.cxPesquisaCep.Click();
        }

        [When(@"eu digito um cep invalido")]
        public void WhenEuDigitoUmCepInvalido()
        {
            buscaCepPage.cxInsiraCep.SendKeys(Constants.CEP_INVALIDO);
        }

        [When(@"eu aguardo a resolução do captcha")]
        public void WhenEuAguardoAResolucaoDoCaptcha()
        {
            //Aguardando a resolução do captcha manualmente
            Thread.Sleep(6000);
        }

        [When(@"eu clico no botão buscar")]
        public void WhenEuClicoNoBotaoBuscar()
        {
            buscaCepPage.btnBuscar.Click();
        }

        [Then(@"eu devo visualizar a mensagem de erro de cep invalido")]
        public void ThenEuDevoVisualizarAMensagemDeErroDeCepInvalido()
        {
            asserts.VerifyInvalidCep();
        }

        [When(@"eu digito um cep válido")]
        public void WhenEuDigitoUmCepValido()
        {
            buscaCepPage.cxInsiraCep.SendKeys(Constants.CEP_VALIDO);
        }

        [Then(@"eu devo visualizar o endereço correspondente ao CEP ""([^""]*)""")]
        public void ThenEuDevoVisualizarOEnderecoCorrespondenteAoCEP(string p0)
        {
            _scenarioContext["endereco"] = p0;
            asserts.VerifyEndereco(p0);
        }

        [When(@"eu insiro o código de rastreio")]
        public void WhenEuInsiroOCodigoDeRastreio()
        {
            homePage.cxInserirCodRastreio.SendKeys(Constants.CodigoRastreio);
        }

        [When(@"eu realizo a busca")]
        public void WhenEuRealizoABusca()
        {
            homePage.btnRastrear.Click();
        }

        [When(@"eu clico no botão consultar")]
        public void WhenEuClicoNoBotaoConsultar()
        {
            WebDriver.alterarTela();//mantem o foco na aba que foi aberta
            homePage.btnConsultar.Click();
        }

        [Then(@"eu devo visualizar a mensagem de objeto não encontrado")]
        public void ThenEuDevoVisualizarAMensagemDeObjetoNaoEncontrado()
        {
            asserts.VerifyInvalidObjMessage();
        }
    }
}
