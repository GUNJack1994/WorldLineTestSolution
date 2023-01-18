using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WorldLineTestSolution.Pages.ConfigurationPages
{
    public class ConfigurationPage : BasePage
    {
        private IWebDriver _driver;

        public ConfigurationPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }
    }
}
