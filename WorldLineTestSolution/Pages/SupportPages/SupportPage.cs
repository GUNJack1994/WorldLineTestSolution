using System.Collections.ObjectModel;
using OpenQA.Selenium;
using WorldLineTestSolution.Helpers;

namespace WorldLineTestSolution.Pages.SupportPages
{
    public class SupportPage : BasePage
    {
        public SupportPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void ClickOnAllSupportSubTabs() 
        {
            foreach (var element in _supportTabsNames)
            {
                _driver.FindElement(By.XPath(_supportTabXpath + $"//a[contains(text(),'{element}')]")).Click();
                var error = CheckIfErrorIsOccurred();
                if (error)
                {
                    error.Should().Be(false, $"Error was occurred on {element}");
                }
            }
        }

        public void ClickOnSupportSubTab(string tabName)
        {
            _driver.FindElement(By.XPath(_supportTabXpath + $"//a[text()='{tabName}']")).Click();
            _driver.WaitForElement(_workFlowBox);
        }

        private string _supportTabXpath => "//ul[@id='maintab']//li";

        private ReadOnlyCollection<IWebElement> _supportTabs => _driver.FindElements(By.XPath(_supportTabXpath));

        private List<string> _supportTabsNames => _supportTabs.Select(x => x.Text).ToList();

        private By _workFlowBox => By.ClassName("insidebg");
    }
}
