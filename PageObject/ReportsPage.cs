using OpenQA.Selenium;
using SeleniumFramework.Helpers;
using SpecflowDemo.TestBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowDemo.PageObject
{
    public class ReportsPage : PageBase
    {
        public IWebDriver _driver;

        public ReportsPage(IWebDriver _driver, int timeout, int interval) : base(_driver)
        {
            driver = _driver;
            WaitHelpers.WaitForUrl(driver, ReportsPageUrl, timeout, interval);
        }

        #region Web Elements
        public By ReportsSearchTxtbx => By.XPath("//input[@class='input-text input-entry ']");
        public By ProjectProfitabilityRow => By.XPath("//a[text()='Project Profitability']");
        #endregion Web Elements

        #region Actions
        public ReportDetailsPage SearchForReport(string reportName)
        {
            TextBoxHelpers.TypeInTextBox(driver, ReportsSearchTxtbx, reportName);
            TextBoxHelpers.TypeInTextBox(driver, ReportsSearchTxtbx, Keys.Return);
            WaitHelpers.WaitForElementToBeVisible(driver, ProjectProfitabilityRow, 10, 1);
            ButtonHelpers.ClickButton(driver, ProjectProfitabilityRow);
            return new ReportDetailsPage(driver, 60, 1);
        }
        #endregion Actions
    }
}
