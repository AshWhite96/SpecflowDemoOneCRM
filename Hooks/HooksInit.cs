using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowDemo.Drivers;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]
namespace SpecflowDemo.Hooks
{
    [Binding]
    public sealed class HooksInit
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private readonly ScenarioContext _scenarioContext;
        public HooksInit(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void FirstBeforeScenario()
        {
            SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
            _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Selenium web driver quit");
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }
    }
}