using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Infrastructure;
using WorldLineTestSolution.Drivers;
using WorldLineTestSolution.Pages.ConfigurationPages;
using static WorldLineTestSolution.Pages.ConfigurationPages.UserPage;

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

            _userPage.FillTextBox(_userPage.UserIdTextBox, datas.UserId);
            _userPage.FillTextBox(_userPage.UserNameTextBox, datas.UserName);
            _userPage.FillTextBox(_userPage.EmailAdressTextBox, datas.EmailAddress);
            _userPage.FillTextBox(_userPage.ConfirmPasswordTextBox, datas.ConfirmPassword);

            //_configurationPage.ClickOnButton(_configurationPage.CreateButton);
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