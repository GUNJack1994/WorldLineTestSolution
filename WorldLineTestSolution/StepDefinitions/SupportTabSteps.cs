using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WorldLineTestSolution.Helpers;
using WorldLineTestSolution.Pages;

namespace WorldLineTestSolution.StepDefinitions
{
    [Binding]
    public class SupportTabSteps
    {
        IWebDriver _driver;

        private readonly ScenarioContext _scenarioContext;

        private SupportPage supportPage;

        public SupportTabSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
            supportPage = new SupportPage(_driver);
        }

        [When(@"I click on '([^']*)' Support tab")]
        public void WhenIClickOnSupportTab(string tabName)
        {
            supportPage.ClickOnSupportSubTab(tabName);
        }

        [When(@"I input text '([^']*)' for search")]
        public void WhenIInputTextForSearch(string text)
        {
            _driver.WaitForElement(supportPage.SearchToolBar);
            supportPage.SearchTextBox.SendKeys(text);
            supportPage.SearchButton.Click();
            _driver.WaitForElement(supportPage.SearchResultCount);
        }

        [Then(@"I check if search result is '(not empty|empty)'")]
        public void ThenICheckIfSearchResultIs(string state)
        {
            if (state != "empty")
            {
                supportPage.SearchResult.Should().NotBeNullOrEmpty();
            }
            else 
            {
                supportPage.SearchResult.Should().BeNullOrEmpty();
            }
        }
    }
}
