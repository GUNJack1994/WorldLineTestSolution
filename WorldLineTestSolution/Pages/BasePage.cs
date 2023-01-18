using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public void ClickOnAllSubTabs()
        {
            foreach (var element in SubTabsNames)
            {
                _driver.FindElement(By.XPath(SubTabsXpath + $"//a[contains(text(),'{element}')]")).Click();
                var error = CheckIfErrorIsOccurred();
                if (error)
                {
                    error.Should().Be(false, $"Error was occurred on {element}");
                }
            }
        }

        public string SubTabsXpath => "//ul[@id='maintab']//li";

        public ReadOnlyCollection<IWebElement> SubTabs => _driver.FindElements(By.XPath(SubTabsXpath));

        public List<string> SubTabsNames => SubTabs.Select(x => x.Text).ToList();
    }
}
