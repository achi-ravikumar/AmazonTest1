using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Extensions;
using TechTalk.SpecFlow;

namespace AmazonTest.Hooks
{
    [Binding]
    public class Hooks : BasePage
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            OpenBrowser();
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            CloseBrowser();
        }
    }
}