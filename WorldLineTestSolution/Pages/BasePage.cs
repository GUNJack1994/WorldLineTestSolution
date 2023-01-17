using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamitey;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Tracing;
using WorldLineTestSolution.Drivers;

namespace WorldLineTestSolution.Pages
{
    public class BasePage : DriverProvider
    {
        protected IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
        public void ClickOnButton(IWebElement element)
        {
            element.Click();
        }

        public void FillTextBox(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public bool CheckIfErrorIsOccurred() 
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            try
            {
                wait.Until(ExpectedConditions.ElementExists(ErrorIcon));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private By ErrorIcon => By.XPath("//span[@class='warning-ico']");
    }
}
