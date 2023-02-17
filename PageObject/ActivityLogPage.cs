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
    public class ActivityLogPage : PageBase
    {
        public IWebDriver driver;

        public ActivityLogPage(IWebDriver _driver, int timeout, int interval) : base(_driver)
        {
            driver = _driver;
            WaitHelpers.WaitForUrl(driver, ActivityLogPageUrl, timeout, interval);
        }

        #region WebElements
        public By TotalLogsTxt => By.XPath("//div[@class='card-header panel-subheader listview-header']//span[@class='text-number'][2]");
        public By RowChkbxs => By.XPath("//td[@class='listViewTd listViewMeta']/div/input");
        public By HeaderActionsBtn => By.XPath("//div[@class='card-header panel-subheader listview-header']//button[@class='input-button menu-source']");
        public By DeleteBtn => By.XPath("//div[@class='option-cell input-label ' and text()='Delete']");
        #endregion Web Elements

        #region Actions
        public int GetLogCount()
        {
            return Convert.ToInt32(GenericHelpers.GetElement(driver, TotalLogsTxt).Text.Replace(",", ""));
        }

        public void SelectLogsForDeletion(int deletionCount)
        {
            IList<IWebElement> rowCheckBoxes = GenericHelpers.GetElements(driver, RowChkbxs);

            for (int i = 0; i < deletionCount; i++)
            {
                rowCheckBoxes[i].Click();
            }
        }

        public void ClickActionsAndDelete()
        {
            ButtonHelpers.ClickButton(driver, HeaderActionsBtn);
            ButtonHelpers.ClickButton(driver, DeleteBtn);
            GenericHelpers.ClickOkayOnJSPopUp(driver);
        }
        #endregion Actions
    }
}
