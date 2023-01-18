using System.Collections.ObjectModel;
using OpenQA.Selenium;
using WorldLineTestSolution.Helpers;

namespace WorldLineTestSolution.Pages.SupportPages
{
    public class SupportPage : BasePage
    {
        private IWebDriver _driver { get; set; }

        public SupportPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void ClickOnAllSupportSubTabs() 
        {
            foreach (var element in SupportTabsNames)
            {
                _driver.FindElement(By.XPath(SupportTabXpath + $"//a[contains(text(),'{element}')]")).Click();
                var error = CheckIfErrorIsOccurred();
                if (error)
                {
                    error.Should().Be(false, $"Error was occurred on {element}");
                }
            }
        }

        public void ClickOnSupportSubTab(string tabName)
        {
            _driver.FindElement(By.XPath(SupportTabXpath + $"//a[text()='{tabName}']")).Click();
            _driver.WaitForElement(WorkFlowBox);
        }

        public string SupportTabXpath => "//ul[@id='maintab']//li";

        public ReadOnlyCollection<IWebElement> SupportTabs => _driver.FindElements(By.XPath(SupportTabXpath));

        public List<string> SupportTabsNames => SupportTabs.Select(x => x.Text).ToList();

        public By WorkFlowBox => By.ClassName("insidebg");
    }
}
