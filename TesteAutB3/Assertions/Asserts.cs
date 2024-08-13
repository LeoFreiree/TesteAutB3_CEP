using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TesteAutB3.Pages;
using TesteAutB3.Drivers;
using WebDriver = TesteAutB3.Drivers.WebDriver;
using System.Text.RegularExpressions;

namespace TesteAutB3.Assertions
{
    public class Asserts
    {
        BuscaCepPage buscaCepPage = new BuscaCepPage();
        RastreioPage rastreioPage = new RastreioPage();
        public void VerifyPageTitle()
        {
            Assert.AreEqual("Correios", WebDriver.GetDriver().Title);
        }

        public void VerifyInvalidCep()
        {
            Thread.Sleep(2000);
            string msg = buscaCepPage.msgResultado.Text;
            Assert.AreEqual("Dados não encontrado", msg);
        }

        public void VerifyInvalidObjMessage()
        {
            Thread.Sleep(1000);
            string input = rastreioPage.msgResult.Text;
            string pattern = @"(Objeto não encontrado na base de dados dos Correios\.)\s*.*";
            string resultMsg = Regex.Replace(input, pattern, "$1");

            Assert.AreEqual("Objeto não encontrado na base de dados dos Correios.", resultMsg);
        }

        public void VerifyEndereco(string endereco) {
            Thread.Sleep(2000);
            string logradouro = buscaCepPage.tdLogradouro.Text;
            string localidade = buscaCepPage.tdLocalidade.Text;

            string palavra = "Rua Quinze de Novembro";
            string logradouroPattern = $@"\b{palavra}\b.*";
            string resultLogradouro = Regex.Replace(logradouro, logradouroPattern,palavra);

            string resultEndereco = $"{resultLogradouro}, {localidade}";
            Assert.AreEqual(endereco, resultEndereco);
        }
    }
}
