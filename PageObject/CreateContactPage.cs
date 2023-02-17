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
    public class CreateContactPage : PageBase
    {
        public CreateContactPage(IWebDriver _driver, int timeout, int interval) : base(_driver)
        {
            driver = _driver;
            WaitHelpers.WaitForUrl(driver, CreateContactPageUrl, timeout, interval);
        }

        #region Web Elements
        public By FirstNameTxtbx => By.Id("DetailFormfirst_name-input");
        public By LastNameTxtbx => By.Id("DetailFormlast_name-input");
        public By CategoryDdl => By.Id("DetailFormcategories-input");
        public By CategoryEleBtn => By.XPath("//div[@class='menu-option single current']/div[@class='option-cell input-label ']");
        public By CategorySearchTxtbx => By.XPath("//div[@class='input-field input-field-group input-search active']/input");
        public By CategorySearchNotActiveTxtbx => By.XPath("//div[@class='input-field input-field-group input-search']/input");
        public By SaveBtn => By.XPath("//button[@id='DetailForm_save']");
        public By BusinessRoleDdl => By.XPath("//div[@id='DetailFormbusiness_role-input']");
        public By BusinessRoleTxt => By.XPath("//div[@class='menu-option single current']");
        
        #endregion Web Elements

        #region Actions
        public void EnterFirstName(string firstName)
        {
            TextBoxHelpers.TypeInTextBox(driver, FirstNameTxtbx, firstName);
        }

        public void EnterLastName(string lastName)
        {
            TextBoxHelpers.TypeInTextBox(driver, LastNameTxtbx, lastName);
        }

        public void EnterFullNameDetails(string firstName, string lastName)
        {
            EnterFirstName(firstName);
            EnterLastName(lastName);
        }

        public void EnterBusinessRole(string role)
        {
            ButtonHelpers.ClickButton(driver, BusinessRoleDdl);
            TextBoxHelpers.TypeInTextBox(driver, BusinessRoleDdl, role);
            ButtonHelpers.ClickButton(driver, BusinessRoleTxt);
        }

        public void EnterCategories(List<string> categories)
        {
            foreach (var category in categories)
            {
                Thread.Sleep(1000);
                ButtonHelpers.ClickButton(driver, CategoryDdl);
                Thread.Sleep(1000);
                if (GenericHelpers.IsElementPresent(driver, CategorySearchNotActiveTxtbx))
                {
                    TextBoxHelpers.TypeInTextBox(driver, CategorySearchNotActiveTxtbx, category);

                }
                else
                {
                    TextBoxHelpers.TypeInTextBox(driver, CategorySearchTxtbx, category);
                }

                ButtonHelpers.ClickButton(driver, CategoryEleBtn);
            }
        }

        public NewContactPage ClickContactSaveBtn()
        {
            ButtonHelpers.ClickButton(driver, SaveBtn);
            return new NewContactPage(driver, 60, 1);
        }
        #endregion Actions
    }
}
