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
    public class OneCRMContactsPage : PageBase
    {
        public OneCRMContactsPage(IWebDriver _driver, int timeout, int poll) : base(_driver)
        {
            driver = _driver;
            WaitHelpers.WaitForUrl(driver, OneCrmContactsPageUrl, timeout, poll);
            WaitHelpers.WaitForElement(driver, CreateContactBtn, timeout, poll);
        }

        #region Web Elements
        public By CreateContactBtn => By.XPath("//button[@name='SubPanel_create']");
        #endregion Web Elements

        #region Actions
        public CreateContactPage ClickCreateContactButton()
        {
            ButtonHelpers.ClickButton(driver, CreateContactBtn);
            return new CreateContactPage(driver, 60, 1);
        }
        #endregion Actions
    }
}
