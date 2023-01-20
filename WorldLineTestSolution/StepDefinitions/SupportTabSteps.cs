using OpenQA.Selenium;
using WorldLineTestSolution.Helpers;
using WorldLineTestSolution.Pages.SupportPages;

namespace WorldLineTestSolution.StepDefinitions
{
    [Binding]
    public class SupportTabSteps
    {
        IWebDriver _driver;

        private readonly ScenarioContext _scenarioContext;

        private SupportPage _supportPage;

        private FaqsPage _faqsPage;

        public SupportTabSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
            _supportPage = new SupportPage(_driver);
            _faqsPage = new FaqsPage(_driver);
        }

        [When(@"I click on '([^']*)' Support tab")]
        public void WhenIClickOnSupportTab(string tabName)
        {
            _faqsPage.ClickOnSupportSubTab(tabName);
        }

        [When(@"I input text '([^']*)' for search")]
        public void WhenIInputTextForSearch(string text)
        {
            _driver.WaitForElement(_faqsPage.SearchToolBar);
            _faqsPage.SearchTextBox.SendKeys(text);
            _faqsPage.SearchButton.Click();
            _driver.WaitForElement(_faqsPage.SearchResultCount);
        }

        [Then(@"I check if search result is '(not empty|empty)'")]
        public void ThenICheckIfSearchResultIs(string state)
        {
            if (state != "empty")
            {
                _faqsPage.SearchResult.Should().NotBeNullOrEmpty();
            }
            else 
            {
                _faqsPage.SearchResult.Should().BeNullOrEmpty();
            }
        }

        [Then(@"I check every subTab for Support if there is no error")]
        public void ThenICheckEverySubTabForIfThereIsNoError()
        {
            _supportPage.ClickOnAllSupportSubTabs();
        }
    }
}
