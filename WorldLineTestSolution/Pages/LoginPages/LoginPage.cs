using OpenQA.Selenium;

namespace WorldLineTestSolution.Pages.LoginPages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        internal string PageUrl => "https://secure.ogone.com/Ncol/Test/Backoffice/login/";

        public void SignIn(string pspid, string password)
        {
            PspidTextBox.SendKeys(pspid);
            _passwordTextBox.SendKeys(password);
            SubmitButton.Click();
        }

        internal By PspidTextBoxXpath => By.Id("txt_AuthenticationResult_PspId");

        internal IWebElement PspidTextBox => _driver.FindElement(PspidTextBoxXpath);

        private IWebElement _passwordTextBox => _driver.FindElement(By.Id("pwd_AuthenticationResult_Password"));

        private IWebElement SubmitButton => _driver.FindElement(By.Id("btn_Login"));

        internal By CorrectLoginXpath => By.XPath("//div[@class='info-msg margin10']");

        internal string CorrectLoginMessage => _driver.FindElement(CorrectLoginXpath).Text;

        internal By ErrorLoginXpath => By.XPath("//div[@class='margin-left35']");

        internal string ErrorLoginMessage => _driver.FindElement(ErrorLoginXpath).Text;

        internal IWebElement UserInfoButton => _driver.FindElement(By.Id("userInfoModalSVG"));

        internal By LogoutButtonXpath => By.Id("logout");

        internal IWebElement LogoutButton => _driver.FindElement(LogoutButtonXpath);
    }
}
