using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WorldLineTestSolution.Helpers;

namespace WorldLineTestSolution.Pages.HomePages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void ClickOnAllMainTabs()
        {
            foreach (var element in MainTabElements)
            {
                var elementToFind = By.XPath(_mainTabXpath + $"//span[text()='{element}']");

                Actions action = new Actions(_driver);
                action.DoubleClick(_driver.FindElement(elementToFind)).Build().Perform();

                var error = CheckIfErrorIsOccurred();
                if (error)
                {
                    error.Should().Be(false, $"Error was occurred on {element}");
                }
            }
        }

        public void ClickOnSpecyficTab(string tabName)
        {
            var elementToFind = By.XPath(_mainTabXpath + $"//span[text()='{tabName}']");

            Actions action = new Actions(_driver);
            action.DoubleClick(_driver.FindElement(elementToFind)).Build().Perform();

            if (tabName != "Support")
            {
                var elementToWait = By.XPath(SubTabXpath);
                _driver.WaitForElement(elementToWait);
            }
        }

        public void ClickOnAllSubMainTabs()
        {
            foreach (var element in SubTabElements)
            {
                _driver.FindElement(By.XPath(SubTabXpath + $"//span[text()='{element}']")).Click();
                _driver.WaitForElement(_subTabMainScreen);
                var error = CheckIfErrorIsOccurred();
                if (error)
                {
                    error.Should().Be(false, $"Error was occurred on {element}");
                }
            }
        }

        internal void ClickOnSpecyficSubTab(string subTabName) => _driver.FindElement(By.XPath(SubTabXpath + $"//span[text()='{subTabName}']")).Click();

        private string _mainTabXpath => "//div[@id='headernavigation']//ul//li";

        private ReadOnlyCollection<IWebElement> _mainTab => _driver.FindElements(By.XPath(_mainTabXpath));

        internal List<string> MainTabElements => _mainTab.Select(x => x.Text).ToList();

        internal string SubTabXpath => "//ul[@id='myogonemenu']//li";

        private ReadOnlyCollection<IWebElement> _subMainTab => _driver.FindElements(By.XPath(SubTabXpath));

        internal List<string> SubTabElements => _subMainTab.Select(x => x.Text).ToList();

        private By _subTabMainScreen => By.ClassName("mid-grid");
    }
}
