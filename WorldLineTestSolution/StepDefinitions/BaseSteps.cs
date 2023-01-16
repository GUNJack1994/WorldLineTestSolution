using System.Reflection;
using OpenQA.Selenium;
using WorldLineTestSolution.Drivers;
using WorldLineTestSolution.Pages;

namespace WorldLineTestSolution.StepDefinitions
{
    [Binding]
    public class BaseSteps
    {
        public IWebDriver _driver;

        private readonly ScenarioContext _scenarioContext;

        private LoginPage loginPage;

        public BaseSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            loginPage = new LoginPage(_driver);
        }

        [Given(@"I am on loggin page")]
        public void GivenIAmOnLogginPage()
        {
            _driver.Url = loginPage.PageUrl;
        }

        [When(@"I am singing into application by (.*) and (.*)")]
        public void WhenIAmSingingIntoApplicationByKpfrontbAndTesting(string pspid, string password)
        {
            loginPage.SignIn(pspid, password);
        }

        [When(@"I click on '([^']*)' button on '([^']*)' page")]
        public void WhenIClickOnButtonOnPage(string buttonName, string pageName)
        {
            var currentPage = _scenarioContext.Get<object>(pageName);
            var props = currentPage.GetType().GetProperties();
            var t = (IWebElement)props.First(x => x.Name == buttonName).GetValue(currentPage);
            t.Click();
        }
    }
}
