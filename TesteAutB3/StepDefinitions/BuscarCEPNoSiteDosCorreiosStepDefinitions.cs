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
    public class BuscarCEPNoSiteDosCorreiosStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public BuscarCEPNoSiteDosCorreiosStepDefinitions(ScenarioContext scenarioContext)
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

        [When(@"eu clico no botão nova busca")]
        public void WhenEuClicoNoBotaoNovaBusca()
        {
            buscaCepPage.btnNovaBusca.Click();
        }

        [When(@"eu digito um cep válido")]
        public void WhenEuDigitoUmCepValido()
        {
            buscaCepPage.cxInsiraCep.SendKeys(Constants.CEP_VALIDO);
        }

        [When(@"eu aguardo a resolução do captcha novamente")]
        public void WhenEuAguardoAResolucaoDoCaptchaNovamente()
        {
            //Aguardando a resolução do captcha manualmente
            Thread.Sleep(6000);
        }

        [When(@"eu clico no botão buscar novamente")]
        public void WhenEuClicoNoBotaoBuscarNovamente()
        {
            buscaCepPage.btnBuscar.Click();
        }

        [Then(@"eu devo visualizar o endereço correspondente ao CEP ""(.*)""")]
        public void ThenEuDevoVisualizarOEnderecoCorrespondenteAoCEP(string enderecoCadastrado)
        {
            _scenarioContext["endereco"] = enderecoCadastrado;
            asserts.VerifyEndereco(enderecoCadastrado);
        }

        [When(@"eu volto para a pagina inicial")]
        public void WhenEuVoltoParaAPaginaInicial()
        {
            buscaCepPage.voltarPagInicialIcon.Click();
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

        [When(@"eu aguardo a resolução do captcha para a tela de rastreio")]
        public void WhenEuAguardoAResolucaoDoCaptchaParaATelaDeRastreio()
        {
            //aguardando a resolução do captcha manualmente
            Thread.Sleep(6000);
        }

        [When(@"eu clico no botão consultar")]
        public void WhenEuClicoNoBotaoConsultar()
        {
            string currentWindow = WebDriver.GetDriver().WindowHandles.Last();
            WebDriver.GetDriver().SwitchTo().Window(currentWindow);
            homePage.btnConsultar.Click();
        }

        [Then(@"eu devo visualizar a mensagem de objeto não encontrado")]
        public void ThenEuDevoVisualizarAMensagemDeObjetoNaoEncontrado()
        {
            asserts.VerifyInvalidObjMessage();
        }
    }
}
