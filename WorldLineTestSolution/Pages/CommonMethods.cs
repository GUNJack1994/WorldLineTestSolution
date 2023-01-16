using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WorldLineTestSolution.Drivers;

namespace WorldLineTestSolution.Pages
{
    public class CommonMethods : DriverProvider
    {
        protected IWebDriver _driver;

        public CommonMethods(IWebDriver driver)
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
    }
}
