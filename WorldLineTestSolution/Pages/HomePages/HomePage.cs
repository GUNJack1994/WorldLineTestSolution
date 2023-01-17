using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Tracing;
using WorldLineTestSolution.Helpers;

namespace WorldLineTestSolution.Pages.HomePages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IWebDriver _driver { get; set; }

        public void ClickOnAllMainTabs()
        {
            //MainTabElements.ForEach(x => _driver.FindElement(By.XPath(MainTabXpath + $"//span[text()='{x}']")).Click());

            foreach (var element in MainTabElements)
            {
                _driver.FindElement(By.XPath(MainTabXpath + $"//span[text()='{element}']")).Click();
                var error = CheckIfErrorIsOccurred();
                if (error)
                {
                    error.Should().Be(false, $"Error was occurred on {element}");
                }
            }
        }

        public void ClickOnSpecyficTab(string tabName)
        {
            _driver.FindElement(By.XPath(MainTabXpath + $"//span[text()='{tabName}']")).Click();
            if (tabName != "Support")
            {
                var elementToWait = By.XPath(SubTabXpath);
                _driver.WaitForElement(elementToWait);
            }
        }

        public void HoverOnSpectficTab(string tabName)
        {
            var elementToFind = By.XPath(MainTabXpath + $"//span[text()='{tabName}']");
            _driver.WaitForElement(elementToFind);

            Actions action = new Actions(_driver);
            action.MoveToElement(_driver.FindElement(elementToFind)).Perform();
        }

        public void ClickOnAllSubMainTabs()
        {
            foreach (var element in SubTabElements)
            {
                _driver.FindElement(By.XPath(SubTabXpath + $"//span[text()='{element}']")).Click();
                _driver.WaitForElement(SubTabMainScreen);
                var error = CheckIfErrorIsOccurred();
                if (error)
                {
                    error.Should().Be(false, $"Error was occurred on {element}");
                }
            }
        }

        public void ClickOnSpecyficSubTab(string subTabName)
        {
            _driver.FindElement(By.XPath(SubTabXpath + $"//span[text()='{subTabName}']")).Click();
        }

        public string MainTabXpath => "//div[@id='headernavigation']//ul//li";

        public ReadOnlyCollection<IWebElement> MainTab => _driver.FindElements(By.XPath(MainTabXpath));

        public List<string> MainTabElements => MainTab.Select(x => x.Text).ToList();

        public string SubTabXpath => "//ul[@id='myogonemenu']//li";

        public ReadOnlyCollection<IWebElement> SubMainTab => _driver.FindElements(By.XPath(SubTabXpath));

        public List<string> SubTabElements => SubMainTab.Select(x => x.Text).ToList();

        private By SubTabMainScreen => By.ClassName("mid-grid");
    }
}
