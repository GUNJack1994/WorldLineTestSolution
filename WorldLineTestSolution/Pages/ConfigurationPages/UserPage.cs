using OpenQA.Selenium;

namespace WorldLineTestSolution.Pages.ConfigurationPages
{
    public class UserPage : ConfigurationPage
    {
        private IWebDriver _driver;

        public UserPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        internal IWebElement AddNewUserButton => _driver.FindElement(By.Id("AddUser"));

        internal IWebElement UserIdTextBox => _driver.FindElement(By.Id("txt_SelectedUserId"));

        internal IWebElement UserNameTextBox => _driver.FindElement(By.Id("txt_UserName"));

        internal IWebElement EmailAdressTextBox => _driver.FindElement(By.Id("txt_UserEmail"));

        internal IWebElement ConfirmPasswordTextBox => _driver.FindElement(By.Id("pwd_Password"));

        internal IWebElement CreateButton => _driver.FindElement(By.Id("btn_SaveUser"));

        internal IWebElement BackToListButton => _driver.FindElement(By.Id("lnk_User_Index"));

        internal By NewUserMessageXpath => By.XPath("//div[@id='generalMessage']//div//div[contains(text(), 'New user successfully added.')]");

        internal IWebElement NewUserMessage => _driver.FindElement(NewUserMessageXpath);
    }
}
