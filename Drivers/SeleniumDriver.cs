using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowDemo.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IWebDriver Setup(string browserName)
        {
             driver = GetBrowserDriver(browserName);

            _scenarioContext.Set(driver, "WebDriver");

            driver.Manage().Window.Maximize();

            return driver;
        }

        private dynamic GetBrowserDriver(string browserName)
        {
            if (browserName == "chrome")
                return new ChromeDriver();
            if (browserName == "firefox")
                return new FirefoxDriver();
            if (browserName == "edge")
                return new EdgeDriver();
            if (browserName == "safari")
                return new SafariDriver();

            return new ChromeOptions();
        }
    }
}
