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
    public class ReportDetailsPage : PageBase
    {
        public IWebDriver _driver;

        public ReportDetailsPage(IWebDriver _driver, int timeout, int interval) : base(_driver)
        {
            driver = _driver;
            WaitHelpers.WaitForUrlToContain(driver, ReportDetailsPageUrl, timeout, interval);
        }

        #region Web Elements
        public By RunReportBtn => By.XPath("//button[@name='FilterForm_applyButton']");
        public By ReportTbl => By.XPath("//table[@class='listView']");
        public By ReportRows => By.XPath("//table[@class='listView']/tbody/tr");
        #endregion Web Elements

        #region Actions
        public void ClickRunReport()
        {
            ButtonHelpers.ClickButton(driver, RunReportBtn);
            WaitHelpers.WaitForElementToBeVisible(driver, ReportTbl, 10, 1);
        }
        #endregion Actions
    }
}
