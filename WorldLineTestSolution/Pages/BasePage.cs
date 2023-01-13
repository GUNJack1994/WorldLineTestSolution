using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WorldLineTestSolution.Pages
{
    public abstract class BasePage
    {
        public abstract IWebDriver _driver { get; set; }

        public abstract string PageUrl { get; }

        public BasePage(IWebDriver driver) 
        {
            _driver = driver;
        }
    }
}
