using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowDemo.TestBase
{
    public class PageBase
    {
        protected IWebDriver driver;

        public PageBase(IWebDriver _driver)
        {
            driver = _driver;
        }

        #region Urls
        public static string OneCrmLoginPageUrl => "https://demo.1crmcloud.com/login.php";
        public string OneCrmHomePageUrl => "https://demo.1crmcloud.com/index.php";
        public string OneCrmContactsPageUrl => "https://demo.1crmcloud.com/index.php?module=Contacts&action=index";
        public string CreateContactPageUrl => "https://demo.1crmcloud.com/index.php?module=Contacts&action=EditView&record=&list_layout_name=Browse";
        public string CreatedContactPageUrl => "https://demo.1crmcloud.com/index.php?module=Contacts&action=DetailView&record=";
        public string ReportDetailsPageUrl => "https://demo.1crmcloud.com/index.php?module=Project&action=index&layout=Reports&report_id";
        public string ReportsPageUrl => "https://demo.1crmcloud.com/index.php?module=Reports&action=index";
        public string ActivityLogPageUrl => "https://demo.1crmcloud.com/index.php?module=ActivityLog&action=index";

        #endregion Urls
    }
}
