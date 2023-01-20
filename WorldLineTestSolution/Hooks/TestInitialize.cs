using OpenQA.Selenium;
using WorldLineTestSolution.Drivers;
using WorldLineTestSolution.Helpers;

namespace WorldLineTestSolution.Hooks
{
    [Binding]
    public sealed class TestInitialize
    {
        private readonly ScenarioContext _scenarioContext;

        public TestInitialize(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
            _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
        }

        [AfterTestRun]
        public static void AfterTestRun() 
        {
            ProcessHelper processHelper = new ProcessHelper();
            processHelper.CheckingIfReportFilesExist();
            processHelper.GenerateReport();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }
    }
}