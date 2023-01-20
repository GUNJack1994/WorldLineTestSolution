using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WorldLineTestSolution.Drivers;

namespace WorldLineTestSolution.Pages
{
    public class BasePage : DriverProvider
    {
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
                wait.Until(ExpectedConditions.ElementExists(_errorIcon));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private By _errorIcon => By.XPath("//span[@class='warning-ico']");

        public void ClickOnAllSubTabs()
        {
            foreach (var element in _subTabsNames)
            {
                _driver.FindElement(By.XPath(_subTabsXpath + $"//a[contains(text(),'{element}')]")).Click();
                var error = CheckIfErrorIsOccurred();
                if (error)
                {
                    error.Should().Be(false, $"Error was occurred on {element}");
                }
            }
        }

        private string _subTabsXpath => "//ul[@id='maintab']//li";

        private ReadOnlyCollection<IWebElement> _subTabs => _driver.FindElements(By.XPath(_subTabsXpath));

        public List<string> _subTabsNames => _subTabs.Select(x => x.Text).ToList();
    }
}