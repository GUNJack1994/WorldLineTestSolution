using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WorldLineTestSolution.Helpers
{
    public static class WaitHelper
    {
        private static TimeSpan AmountOfTime { get; } = TimeSpan.FromSeconds(10);

        public static void WaitForElement(this IWebDriver driver, By elementForWait) 
        {
            var wait = new WebDriverWait(driver, AmountOfTime);          
            wait.Until(ExpectedConditions.ElementExists(elementForWait));
        }
    }
}
