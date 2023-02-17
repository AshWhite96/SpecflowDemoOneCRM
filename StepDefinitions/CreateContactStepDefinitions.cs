using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecflowDemo.Drivers;
using SpecflowDemo.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace SpecflowDemo.StepDefinitions
{
    [Binding]
    public sealed class CreateContactStepDefinitions
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        
        public OneCRMLoginPage oneCRMLoginPage;
        public OneCRMHomePage oneCRMHomePage;
        public OneCRMContactsPage oneCRMContactsPage;
        public CreateContactPage createContactPage;
        public NewContactPage newContactPage;

        public CreateContactStepDefinitions(ScenarioContext senarioContext)
        {
            _scenarioContext = senarioContext;
        }

        [Given(@"I navigate to OneCRM and navigate to contacts page")]
        public void GivenINavigateToOneCRMAndNavigateToContactsPage(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup((string)data.Browser);

            oneCRMLoginPage = new OneCRMLoginPage(driver);
            oneCRMLoginPage.NavigateToOneCrmLoginPage();
            oneCRMLoginPage.EnterUsername("admin");
            oneCRMLoginPage.EnterPassword("admin");

            oneCRMHomePage = oneCRMLoginPage.ClickLoginButton();

            oneCRMContactsPage = oneCRMHomePage.ClickContactsButtonInNavBar();
        }

        [Given(@"I click create new contact button")]
        public void GivenIClickCreateNewContactButton()
        {
            createContactPage = oneCRMContactsPage.ClickCreateContactButton();
        }

        [When(@"I enter contact information of firstname '([^']*)' and lastname '([^']*)' and categories of '([^']*)' '([^']*)' and click save")]
        public void WhenIEnterContactInformationOfFirstnameAndLastnameAndCategoriesOfAndClickSave(string firstName, string lastName, string category1, string category2)
        {
            createContactPage.EnterFullNameDetails(firstName, lastName);
            createContactPage.EnterCategories(new List<string> { category1, category2 });
            createContactPage.EnterBusinessRole("Sales");
            newContactPage = createContactPage.ClickContactSaveBtn();
        }


        [Then(@"I can see contact details and verify they are correct: firstname '([^']*)' and lastname '([^']*)' and categories of '([^']*)' '([^']*)'")]
        public void ThenICanSeeTheHomepage(string firstName, string lastName, string category1, string category2)
        {
            string name = newContactPage.GetContactNameString().Trim();
            string categories = newContactPage.GetCategoriesString().Trim();
            string role = newContactPage.GetContactRoleString().Trim();

            Assert.Multiple(() =>
            {
                Assert.That(name, Is.EqualTo("Test Test"), "The name does not match the expected outcome.");
                Assert.That(categories, Is.EqualTo("Category\r\nCustomers, Suppliers"), "The categories do not match the expected outcome.");
                Assert.That(role, Is.EqualTo("Sales"), "The role does not match the expected outcome.");
            });
        }
    }
}
