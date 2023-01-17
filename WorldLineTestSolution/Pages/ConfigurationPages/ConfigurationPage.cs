using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WorldLineTestSolution.Pages.ConfigurationPages
{
    public class ConfigurationPage : BasePage
    {
        private IWebDriver _driver;

        public ConfigurationPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

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
