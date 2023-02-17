using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.Helpers;
using SpecflowDemo.TestBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowDemo.PageObject
{
    public class OneCRMLoginPage : PageBase
    {
        public IWebDriver _driver;

        public OneCRMLoginPage(IWebDriver _driver) : base(_driver)
        {
            driver = _driver;
        }

        #region Web Elements

        public By UsernameTxtbx => By.XPath("//input[@id='login_user']");
        public By PasswordTxtbx => By.XPath("//input[@id='login_pass']");
        public By LoginBtn => By.TagName("button");

        #endregion Web Elements

        #region Actions
        public OneCRMLoginPage NavigateToOneCrmLoginPage()
        {
            driver.Navigate().GoToUrl(OneCrmLoginPageUrl);
            return new OneCRMLoginPage(driver);
        }

        public void EnterUsername(string username)
        {
            TextBoxHelpers.TypeInTextBox(driver, UsernameTxtbx, username);
        }

        public void EnterPassword(string password)
        {
            TextBoxHelpers.TypeInTextBox(driver, PasswordTxtbx, password);
        }

        public OneCRMHomePage ClickLoginButton()
        {
            ButtonHelpers.ClickButton(driver, LoginBtn);
            return new OneCRMHomePage(driver, 60, 1);
        }
        #endregion Actions
    }
}
