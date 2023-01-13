﻿using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WorldLineTestSolution.Helpers;

namespace WorldLineTestSolution.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public override IWebDriver _driver { get; set; }

        public override string PageUrl => throw new NotImplementedException();

        public void ClickOnAllMainTabs() 
        {
            MainTabElements.ForEach(x => _driver.FindElement(By.XPath(MainTabXpath + $"//span[text()='{x}']")).Click());
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
