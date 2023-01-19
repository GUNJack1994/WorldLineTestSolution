using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Infrastructure;

namespace WorldLineTestSolution.Pages.ConfigurationPages
{
    public class UserPage : ConfigurationPage
    {
        private IWebDriver _driver;

        public UserPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public IWebElement AddNewUserButton => _driver.FindElement(By.Id("AddUser"));

        public IWebElement UserIdTextBox => _driver.FindElement(By.Id("txt_SelectedUserId"));

        public IWebElement UserNameTextBox => _driver.FindElement(By.Id("txt_UserName"));

        public IWebElement EmailAdressTextBox => _driver.FindElement(By.Id("txt_UserEmail"));

        public IWebElement ConfirmPasswordTextBox => _driver.FindElement(By.Id("pwd_Password"));

        public IWebElement CreateButton => _driver.FindElement(By.Id("btn_SaveUser"));

        public IWebElement BackToListButton => _driver.FindElement(By.Id("lnk_User_Index"));

        public By NewUserMessageXpath => By.XPath("//div[@id='generalMessage']//div//div[contains(text(), 'New user successfully added.')]");

        public IWebElement NewUserMessage => _driver.FindElement(NewUserMessageXpath);
    }
}
