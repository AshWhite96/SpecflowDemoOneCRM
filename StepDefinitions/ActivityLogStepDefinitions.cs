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
    public sealed class ActivityLogStepDefinitions
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public OneCRMLoginPage oneCRMLoginPage;
        public OneCRMHomePage oneCRMHomePage;
        public ActivityLogPage activityLogPage;

        public int initialLogCount;

        public ActivityLogStepDefinitions(ScenarioContext senarioContext)
        {
            _scenarioContext = senarioContext;
        }

        [Given(@"I navigate to OneCRM and navigate to activity log page")]
        public void GivenINavigateToOneCRMAndNavigateToActivityLogPage(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup((string)data.Browser);

            oneCRMLoginPage = new OneCRMLoginPage(driver);
            oneCRMLoginPage.NavigateToOneCrmLoginPage();
            oneCRMLoginPage.EnterUsername("admin");
            oneCRMLoginPage.EnterPassword("admin");

            oneCRMHomePage = oneCRMLoginPage.ClickLoginButton();

            activityLogPage = oneCRMHomePage.ClickActivityLogButtonInNavBar();
        }

        [When(@"I search delete first '([^']*)' logs")]
        public void WhenISearchDeleteFirstLogs(int deletionCount)
        {
            initialLogCount = activityLogPage.GetLogCount();
            activityLogPage.SelectLogsForDeletion(deletionCount);
            activityLogPage.ClickActionsAndDelete();
            Thread.Sleep(1000);
        }

        [Then(@"I can verify logs have been deleted")]
        public void ThenICanVerifyLogsHaveBeenDeleted()
        {
            Assert.Multiple(() =>
            {
                Assert.That(initialLogCount, Is.GreaterThan(activityLogPage.GetLogCount()), "The log count was not lower than expected.");
                Assert.That((initialLogCount - 3), Is.EqualTo(activityLogPage.GetLogCount()), "The log count did not match.");
            });
        }


    }
}
