using OpenQA.Selenium;
using TechTalk.SpecFlow.Infrastructure;
using WorldLineTestSolution.Drivers;
using WorldLineTestSolution.Pages;
using WorldLineTestSolution.Pages.LoginPages;

namespace WorldLineTestSolution.StepDefinitions
{
    [Binding]
    public class BaseSteps
    {
        public IWebDriver _driver;

        private readonly ScenarioContext _scenarioContext;

        private BasePage _basePage;

        private LoginPage _loginPage;

        public BaseSteps(ScenarioContext scenarioContext, ISpecFlowOutputHelper output)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            _basePage = new BasePage(_driver);
            _loginPage = new LoginPage(_driver);   
        }

        [Given(@"I am on loggin page")]
        public void GivenIAmOnLogginPage()
        {
            _driver.Url = _loginPage.PageUrl;
        }

        [When(@"I am logging in application by '([^']*)' and '([^']*)'")]
        public void WhenIAmLoggingInApplicationByAnd(string pspid, string password)
        {
            _loginPage.SignIn(pspid, password);
        }

        //TO DO
        //[When(@"I click on '([^']*)' button on '([^']*)' page")]
        //public void WhenIClickOnButtonOnPage(string buttonName, string pageName)
        //{
        //    var currentPage = _scenarioContext.Get<object>(pageName);
        //    var props = currentPage.GetType().GetProperties();
        //    var t = (IWebElement)props.First(x => x.Name == buttonName).GetValue(currentPage);
        //    t.Click();
        //}

        [Then(@"I check every subTab if there is no error")]
        public void ThenICheckEverySubTabForIfThereIsNoError()
        {
            _basePage.ClickOnAllSubTabs();
        }
    }
}
