using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WorldLineTestSolution.Pages
{
    public class ConfigurationPage : CommonMethods
    {
        private IWebDriver _driver;

        public ConfigurationPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public IWebElement AddNewUserButton => _driver.FindElement(By.Id("AddUser"));

        public IWebElement UserIdTextBox => _driver.FindElement(By.Id("txt_SelectedUserId"));

        public IWebElement UserNameTextBox => _driver.FindElement(By.Id("txt_UserName"));

        public IWebElement EmailAdressTextBox => _driver.FindElement(By.Id("txt_UserEmail"));

        public IWebElement ConfirmPasswordTextBox => _driver.FindElement(By.Id("pwd_Password"));

        public IWebElement CreateButton => _driver.FindElement(By.Id("btn_SaveUser"));
    }
}
