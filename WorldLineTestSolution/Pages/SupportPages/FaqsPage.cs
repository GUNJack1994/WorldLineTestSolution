using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace WorldLineTestSolution.Pages.SupportPages
{
    public class FaqsPage : SupportPage
    {
        public FaqsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        internal By SearchToolBar => By.Id("div-search-panel");

        internal IWebElement SearchTextBox => _driver.FindElement(By.Name("SearchedText"));

        internal IWebElement SearchButton => _driver.FindElement(By.Id("btn_ManageFaq"));

        internal By SearchResultCount => By.XPath("//*[@id='divfaq']/div/span");

        internal ReadOnlyCollection<IWebElement> SearchResult => _driver.FindElements(By.XPath("//div[@id='divfaq']//table//tbody//tr"));
    }
}
