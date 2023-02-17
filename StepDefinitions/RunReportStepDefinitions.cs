using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumFramework.Helpers;
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
    public sealed class RunReportStepDefinitions
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public OneCRMLoginPage oneCRMLoginPage;
        public OneCRMHomePage oneCRMHomePage;
        public ReportsPage reportsPage;
        public ReportDetailsPage reportDetailsPage;

        public RunReportStepDefinitions(ScenarioContext senarioContext)
        {
            _scenarioContext = senarioContext;
        }

        [Given(@"I navigate to OneCRM and navigate to reports page")]
        public void GivenINavigateToOneCRMAndNavigateToReportsPage(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup((string)data.Browser);

            oneCRMLoginPage = new OneCRMLoginPage(driver);
            oneCRMLoginPage.NavigateToOneCrmLoginPage();
            oneCRMLoginPage.EnterUsername("admin");
            oneCRMLoginPage.EnterPassword("admin");

            oneCRMHomePage = oneCRMLoginPage.ClickLoginButton();

            reportsPage = oneCRMHomePage.ClickReportsAndSettingsButtonInNavBar();
        }

        [When(@"I search for '([^']*)' report and click run report")]
        public void WhenISearchForReportAndClickRunReport(string reportName)
        {
            reportDetailsPage = reportsPage.SearchForReport(reportName);
            reportDetailsPage.ClickRunReport();
        }

        [Then(@"I can verify results have been returned")]
        public void ThenICanVerifyResultsHaveBeenReturned()
        {
            Assert.Multiple(() =>
            {
                Assert.That(GenericHelpers.GetElements(driver, reportDetailsPage.ReportRows).Count, Is.GreaterThan(0), "The report did not return any results");
                Assert.That(GenericHelpers.GetElements(driver, reportDetailsPage.ReportRows).Count, Is.EqualTo(20), "The results returned does not match the expected outcome");
            });
        }

    }
}
