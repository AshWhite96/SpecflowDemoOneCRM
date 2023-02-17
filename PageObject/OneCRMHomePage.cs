using OpenQA.Selenium;
using SeleniumFramework.Helpers;
using SpecflowDemo.TestBase;

namespace SpecflowDemo.PageObject
{
    public class OneCRMHomePage : PageBase
    {
        public IWebDriver _driver;

        public OneCRMHomePage(IWebDriver _driver, int timeout, int interval) : base(_driver)
        {
            driver = _driver;
            WaitHelpers.WaitForUrl(driver, OneCrmHomePageUrl, timeout, interval);
            WaitHelpers.WaitForElementToBeVisible(driver, SalesAndMarketingNavBtn, timeout, interval);
        }

        #region Web Elements
        public By SalesAndMarketingNavBtn => By.XPath("//a[@title='Sales & Marketing']");
        public By ReportsAndSettingsNavBtn => By.XPath("//a[@title='Reports & Settings']");
        public By ContactsNavBtn => By.XPath("//a[contains(text(),' Contacts')]/parent::div");
        public By ActivityLogNavBtn => By.XPath("//a[contains(text(),' Activity Log')]/parent::div");
        #endregion Web Elements

        #region Actions
        public OneCRMContactsPage ClickContactsButtonInNavBar()
        {
            GenericHelpers.MoveToElement(driver, SalesAndMarketingNavBtn);
            ButtonHelpers.ClickButton(driver,ContactsNavBtn);
            return new OneCRMContactsPage(driver, 60, 1);
        }

        public ActivityLogPage ClickActivityLogButtonInNavBar()
        {
            GenericHelpers.MoveToElement(driver, ReportsAndSettingsNavBtn);
            ButtonHelpers.ClickButton(driver, ActivityLogNavBtn);
            return new ActivityLogPage(driver, 60, 1);
        }

        public ReportsPage ClickReportsAndSettingsButtonInNavBar()
        {
            ButtonHelpers.ClickButton(driver, ReportsAndSettingsNavBtn);
            return new ReportsPage(driver, 60, 1);
        }
        #endregion Actions
    }
}
