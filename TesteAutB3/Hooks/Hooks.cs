using OpenQA.Selenium;
using TesteAutB3.Drivers;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TesteAutB3.Global;
using WebDriver = TesteAutB3.Drivers.WebDriver;

namespace TesteAutB3.Hooks
{
    [Binding]
    public sealed class Hooks
    {

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {

        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            WebDriver.GetDriver().Navigate().GoToUrl(Global.Constants.URL);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //WebDriver.GetDriver().Quit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            //KillCHDriver.CloseBrowser();
        }

    }
}