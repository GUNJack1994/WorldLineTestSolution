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
using WorldLineTestSolution.Drivers;
using WorldLineTestSolution.Pages;
using static WorldLineTestSolution.Pages.ConfigurationPage;

namespace WorldLineTestSolution.StepDefinitions
{
    [Binding]
    public class ConfigurationTabSteps : DriverProvider
    {
        private readonly ScenarioContext _scenarioContext;
        private ConfigurationPage _configurationPage;

        public ConfigurationTabSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
            _configurationPage = new ConfigurationPage(_driver);
        }

        [When(@"I add new user")]
        public void WhenIAddNewUser()
        {
            _configurationPage.ClickOnButton(_configurationPage.AddNewUserButton);
        }

        [When(@"I fill require fields for create new user")]
        public void WhenIFillRequireFieldsForCreateNewUser(Table table)
        {
            var datas = table.CreateInstance<NewUserFields>();

            _configurationPage.FillTextBox(_configurationPage.UserIdTextBox, datas.UserId);
            _configurationPage.FillTextBox(_configurationPage.UserNameTextBox, datas.UserName);
            _configurationPage.FillTextBox(_configurationPage.EmailAdressTextBox, datas.EmailAddress);
            _configurationPage.FillTextBox(_configurationPage.ConfirmPasswordTextBox, datas.ConfirmPassword);

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