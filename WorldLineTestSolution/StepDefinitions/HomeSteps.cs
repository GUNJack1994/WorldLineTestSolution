using OpenQA.Selenium;
using WorldLineTestSolution.Pages.HomePages;

namespace WorldLineTestSolution.StepDefinitions
{
    [Binding]
    public class HomeSteps
    {
        IWebDriver _driver;

        private readonly ScenarioContext _scenarioContext;

        private HomePage _homePage;

        public HomeSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
            _homePage = new HomePage(_driver);
        }

        [Then(@"I check all tabs are compatible with documentation")]
        public void ThenICheckAllTabsIfConsiderWitchDocumentation()
        {
            _homePage.ClickOnAllMainTabs();

            _homePage.MainTabElements.Should().BeEquivalentTo(Constants.Constants.TabNamesFromDocumentation);
        }

        [When(@"I click on '([^']*)' tab")]
        public void WhenIClickOnTab(string tabName)
        {
            _homePage.ClickOnSpecyficTab(tabName);
        }

        [When(@"I click on '([^']*)' subtab")]
        public void WhenIClickOnInTab(string subTab)
        {
            _homePage.ClickOnSpecyficSubTab(subTab);
        }

        [Then(@"I check all subtabs for '([^']*)' are compatible with documentation")]
        public void ThenICheckAllSubtabsForAreCompatibleWithDocumentation(string TabName)
        {
            _homePage.ClickOnAllSubMainTabs();
            var elementsToCheck = new List<string>();

            switch (TabName)
            {
                case "Configuration":
                    elementsToCheck = Constants.Constants.SubTabNamesForConfigurations;
                    break;
                case "Advanced":
                    elementsToCheck = Constants.Constants.SubTabNamesForAdvanced;
                    break;
                case "Operations":
                    elementsToCheck = Constants.Constants.SubTabNamesForOperations;
                    break;
                default:
                    break;
            }

            _homePage.SubTabElements.Should().BeEquivalentTo(elementsToCheck);
        }
    }
}
