using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Infrastructure;
using WorldLineTestSolution.Helpers;

namespace WorldLineTestSolution.Pages.SupportPages
{
    public class FaqsPage : SupportPage
    {
        public FaqsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IWebDriver _driver { get; set; }

        public IWebElement FaqsPageTab => _driver.FindElement(By.Id("lnk_FaqOgone"));

        public By SearchToolBar => By.Id("div-search-panel");

        public IWebElement SearchTextBox => _driver.FindElement(By.Name("SearchedText"));

        public IWebElement SearchButton => _driver.FindElement(By.Id("btn_ManageFaq"));

        public By SearchResultCount => By.XPath("//*[@id='divfaq']/div/span");

        public ReadOnlyCollection<IWebElement> SearchResult => _driver.FindElements(By.XPath("//div[@id='divfaq']//table//tbody//tr"));
    }
}
