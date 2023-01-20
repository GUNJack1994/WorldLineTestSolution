using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WorldLineTestSolution.Drivers
{
    public class SeleniumDriver
    {

        private IWebDriver _driver;

        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IWebDriver Setup() 
        {
            _driver = new ChromeDriver();

            _scenarioContext.Set(_driver, "WebDriver");

            _driver.Manage().Window.Maximize();
            _scenarioContext["WebDriver"] = _driver;

            return _driver;
        }
    }
}