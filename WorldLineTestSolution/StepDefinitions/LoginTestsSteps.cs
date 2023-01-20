using OpenQA.Selenium;
using WorldLineTestSolution.Helpers;
using WorldLineTestSolution.Pages.LoginPages;

namespace WorldLineTestSolution.StepDefinitions
{
    [Binding]
    public class LoginTestsSteps
    {
        IWebDriver _driver;

        private readonly ScenarioContext _scenarioContext;

        private LoginPage _loginPage;

        public LoginTestsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
            _loginPage = new LoginPage(_driver);
        }

        [Then(@"I check if login result is (.*) with message (.*)")]
        public void ThenICheckIfLoginResultIsSuccessWithMessageCongratulationsYourTestAccountIsNowActive(string result, string loginMessage)
        {
            if (result.Equals("success"))
            {
                _driver.WaitForElement(_loginPage.CorrectLoginXpath);
                _loginPage.CorrectLoginMessage.TrimStart().Should().Be(loginMessage);
            }
            else if (result.Equals("fail"))
            {
                _driver.WaitForElement(_loginPage.ErrorLoginXpath);
                _loginPage.ErrorLoginMessage.Trim().Should().Be(loginMessage);
            }
        }

        [When(@"I click on logout button")]
        public void WhenIClickOnLogoutButton()
        {
            _loginPage.UserInfoButton.Click();
            _driver.WaitForElement(_loginPage.LogoutButtonXpath);
            _loginPage.LogoutButton.Click();
        }

        [Then(@"I check if login screen is visible")]
        public void ThenICheckIfLoginScreenIsVisible()
        {
            _driver.WaitForElement(_loginPage.PspidTextBoxXpath);
            _loginPage.PspidTextBox.Displayed.Should().Be(true);
        }
    }
}
