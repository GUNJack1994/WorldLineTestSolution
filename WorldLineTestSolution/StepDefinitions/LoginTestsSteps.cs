using OpenQA.Selenium;
using TechTalk.SpecFlow.Infrastructure;
using WorldLineTestSolution.Helpers;
using WorldLineTestSolution.Pages.LoginPages;

namespace WorldLineTestSolution.StepDefinitions
{
    [Binding]
    public class LoginTestsSteps
    {
        IWebDriver _driver;

        private readonly ScenarioContext _scenarioContext;

        private LoginPage loginPage;

        public LoginTestsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
            loginPage = new LoginPage(_driver);
        }

        [Then(@"I check if login result is (.*) with message (.*)")]
        public void ThenICheckIfLoginResultIsSuccessWithMessageCongratulationsYourTestAccountIsNowActive(string result, string loginMessage)
        {
            if (result.Equals("success"))
            {
                _driver.WaitForElement(loginPage.CorrectLoginXpath);
                loginPage.CorrectLoginMessage.TrimStart().Should().Be(loginMessage);
            }
            else if (result.Equals("fail"))
            {
                _driver.WaitForElement(loginPage.ErrorLoginXpath);
                loginPage.ErrorLoginMessage.Trim().Should().Be(loginMessage);
            }
        }
    }
}
