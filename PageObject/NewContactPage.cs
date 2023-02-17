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
    public class NewContactPage : PageBase
    {
        public NewContactPage(IWebDriver _driver, int timeout, int interval) : base(_driver)
        {
            driver = _driver;
            WaitHelpers.WaitForUrlToContain(driver, CreatedContactPageUrl, timeout, interval);
        }

        #region Web Elements
        public By NewContactNameTxt => By.XPath("//div[@class='column summary-main']//h3");
        public By NewContactCategoryTxt => By.XPath("//ul[@class='summary-list']/li[1]");
        public By NewContactRoleTxt => By.XPath("//p[contains(text(), 'Business Role')]/ancestor::div[@class='form-entry label-left']/div");
        #endregion Web Elements

        #region Actions
        public string GetCategoriesString()
        {
            return GenericHelpers.GetElement(driver, NewContactCategoryTxt).Text;
        }

        public string GetContactNameString()
        {
            return GenericHelpers.GetElement(driver, NewContactNameTxt).Text;
        }

        public string GetContactRoleString()
        {
            return GenericHelpers.GetElement(driver, NewContactRoleTxt).Text;
        }
        #endregion Actions
    }
}
