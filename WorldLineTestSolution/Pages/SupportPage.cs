using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WorldLineTestSolution.Helpers;

namespace WorldLineTestSolution.Pages
{
    public class SupportPage : BasePage
    {
        public SupportPage(IWebDriver driver) : base(driver)
        {
        }

        public override IWebDriver _driver { get; set; }

        public override string PageUrl => throw new NotImplementedException();

        public void ClickOnSupportSubTab(string tabName)
        {
            _driver.FindElement(By.XPath(SupportTabXpath + $"//a[text()='{tabName}']")).Click();
            _driver.WaitForElement(WorkFlowBox);
        }

        public IWebElement FaqsPage => _driver.FindElement(By.Id("lnk_FaqOgone"));

        public By SearchToolBar => By.Id("div-search-panel");

        public IWebElement SearchTextBox => _driver.FindElement(By.Name("SearchedText"));

        public string SupportTabXpath => "//ul[@id='maintab']//li";

        public ReadOnlyCollection<IWebElement> SupportTabs => _driver.FindElements(By.XPath(SupportTabXpath));

        public List<string> SupportTabsNames => SupportTabs.Select(x => x.Text).ToList();

        public By WorkFlowBox => By.ClassName("insidebg");

        public IWebElement SearchButton => _driver.FindElement(By.Id("btn_ManageFaq"));

        public By SearchResultCount => By.XPath("//*[@id='divfaq']/div/span");

        public ReadOnlyCollection<IWebElement> SearchResult => _driver.FindElements(By.XPath("//div[@id='divfaq']//table//tbody//tr"));
    }
}
