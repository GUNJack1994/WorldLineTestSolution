using OpenQA.Selenium;
using TechTalk.SpecFlow.Assist;
using WorldLineTestSolution.Drivers;
using WorldLineTestSolution.Helpers;
using WorldLineTestSolution.Pages.ConfigurationPages;

namespace WorldLineTestSolution.StepDefinitions
{
    [Binding]
    public class ConfigurationTabSteps : DriverProvider
    {
        private readonly ScenarioContext _scenarioContext;

        private ConfigurationPage _configurationPage;

        private UserPage _userPage;

        public ConfigurationTabSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
            _configurationPage = new ConfigurationPage(_driver);
            _userPage = new UserPage(_driver);
        }

        [When(@"I add new user")]
        public void WhenIAddNewUser()
        {
            _userPage.ClickOnButton(_userPage.AddNewUserButton);
        }

        [When(@"I fill require fields for create new user")]
        public void WhenIFillRequireFieldsForCreateNewUser(Table table)
        {
            var datas = table.CreateInstance<NewUserFields>();
            var currentDate = DateTime.Now.ToString("yyyy-MM-dd-h:mm:ss-tt");

            _userPage.FillTextBox(_userPage.UserIdTextBox, datas.UserId + currentDate);
            _userPage.FillTextBox(_userPage.UserNameTextBox, datas.UserName);
            _userPage.FillTextBox(_userPage.EmailAdressTextBox, datas.EmailAddress);
            _userPage.FillTextBox(_userPage.ConfirmPasswordTextBox, datas.ConfirmPassword);

            _configurationPage.ClickOnButton(_userPage.CreateButton);
            WaitHelper.WaitForElement(_driver, _userPage.NewUserMessageXpath);
            _userPage.NewUserMessage.Displayed.Should().BeTrue();

            _configurationPage.ClickOnButton(_userPage.BackToListButton);
        }

        [Then(@"I check if '([^']*)' user was created")]
        public void ThenICheckIfUserWasCreated(string userName)
        {
            WaitHelper.WaitForElement(_driver, _userPage.UserNameXpath);
            _configurationPage.GetUserFromTable(userName).Should().NotBeNull();
        }

        [When(@"I deactivate '([^']*)' user")]
        public void WhenIDeactivateUser(string userName)
        {
            WaitHelper.WaitForElement(_driver, _configurationPage.UserNameXpath);
            _configurationPage.DeactivateUser(userName);
            WaitHelper.WaitForElement(_driver, _configurationPage.DeactivateMessageXpath);
        }

        [Then(@"I check if deactivate message for '([^']*)' was shown")]
        public void ThenICheckIfDeactivateMessageWasShown(string userName)
        {
            _configurationPage.GetDeactivateMessage(userName).Displayed.Should().BeTrue();
        }

        public record NewUserFields
        {
            public string UserId { get; set; }
            public string UserName { get; set; }
            public string EmailAddress { get; set; }
            public string ConfirmPassword { get; set; }
        }
    }
}