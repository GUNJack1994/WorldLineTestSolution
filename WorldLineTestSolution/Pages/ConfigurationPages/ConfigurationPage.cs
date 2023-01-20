using OpenQA.Selenium;

namespace WorldLineTestSolution.Pages.ConfigurationPages
{
    public class ConfigurationPage : BasePage
    {
        public ConfigurationPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public IWebElement GetUserFromTable(string userName) 
        {
            return _driver.FindElement(By.XPath(UserNamePath + $"[contains(text(), '{userName}')]"));
        }

        public void DeactivateUser(string userName) 
        {
            ClickOnButton(DeactivateButton(userName));
        }

        public IWebElement GetDeactivateMessage(string userName) 
        {
            return _driver.FindElement(By.XPath(DeactivateMessagePath + $"//div[contains(text(), '{userName}')]"));
        }

        public string UserNamePath => "//div[@id='div-usergrid']//table//tbody//tr//td";

        public By UserNameXpath => By.XPath(UserNamePath);

        public IWebElement DeactivateButton(string userName) => _driver.FindElement(By.XPath($"//a[contains(@userId, '{userName}')]"));

        public string DeactivateMessagePath => "//*[@id='successMessage']";

        public By DeactivateMessageXpath => By.XPath(DeactivateMessagePath);
    }
}
