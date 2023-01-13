using OpenQA.Selenium;
using WorldLineTestSolution.Pages;

namespace WorldLineTestSolution.StepDefinitions
{
    [Binding]
    public class MainTabSteps
    {
        IWebDriver _driver;

        private readonly ScenarioContext _scenarioContext;

        private HomePage homePage;

        public MainTabSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
            homePage = new HomePage(_driver);
        }

        [Then(@"I check all tabs are compatible with documentation")]
        public void ThenICheckAllTabsIfConsiderWitchDocumentation()
        {
            homePage.ClickOnAllMainTabs();

            homePage.MainTabElements.Should().BeEquivalentTo(Constants.Constants.TabNamesFromDocumentation);
        }

        [When(@"I click on '([^']*)' tab")]
        public void WhenIClickOnTab(string tabName)
        {
            homePage.ClickOnSpecyficTab(tabName);
        }

        [Then(@"I check all subtabs for '([^']*)' are compatible with documentation")]
        public void ThenICheckAllSubtabsForAreCompatibleWithDocumentation(string TabName)
        {
            homePage.ClickOnAllSubMainTabs();
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

            homePage.SubTabElements.Should().BeEquivalentTo(elementsToCheck);
        }
    }
}
