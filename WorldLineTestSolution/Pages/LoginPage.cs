﻿using OpenQA.Selenium;

namespace WorldLineTestSolution.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public override IWebDriver _driver { get; set; }

        public override string PageUrl => "https://secure.ogone.com/Ncol/Test/Backoffice/login/";

        public void SignIn(string pspid, string password) 
        {
            PspidTextBox.SendKeys(pspid);
            PasswordTextBox.SendKeys(password);
            SubmitButton.Click();
        }

        public IWebElement PspidTextBox => _driver.FindElement(By.Id("txt_AuthenticationResult_PspId"));

        public IWebElement PasswordTextBox => _driver.FindElement(By.Id("pwd_AuthenticationResult_Password"));

        public IWebElement SubmitButton => _driver.FindElement(By.Id("btn_Login"));

        public By CorrectLoginXpath => By.XPath("//div[@class='info-msg margin10']");

        public string CorrectLoginMessage => _driver.FindElement(CorrectLoginXpath).Text;

        public By ErrorLoginXpath => By.XPath("//div[@class='margin-left35']");

        public string ErrorLoginMessage => _driver.FindElement(ErrorLoginXpath).Text;
    }
}