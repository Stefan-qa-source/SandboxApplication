using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sandbox_project.ApplicationStructure.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxProject.ApplicationStructure.Helpers
{
    public class ReportsPageHelper : ReportsPage
    {

        private ReportsPage _reportsPage;
        WebDriverWait wait;
        public ReportsPageHelper(IWebDriver driver) : base(driver)
        {
            _reportsPage = new ReportsPage(Driver);

            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public ReportsPageHelper CreateReport()
        {
            string summary = "test summary1";
            string issueType = "Task";
            string severityType = "Medium";
            string priorityType = "Blocker";
            string description = "test description1";
            string firstStepText = "test first step1";
            string secondStepText = "test second step1";

            _reportsPage = _reportsPage.ClickOnReportIssueButton();
            _reportsPage = _reportsPage.EnterSummary(summary);
            _reportsPage = _reportsPage.SelectIssueType(issueType);
            _reportsPage = _reportsPage.SelectSeverityType(severityType);
            _reportsPage = _reportsPage.SelectPriorityType(priorityType);
            _reportsPage = _reportsPage.EnterDescription(description);
            _reportsPage = _reportsPage.EnterFirstStep(firstStepText);
            _reportsPage = _reportsPage.AddNewStep();
            _reportsPage = _reportsPage.EnterSecondStep(secondStepText);
            _reportsPage = _reportsPage.SubmitReportIssue();
            return this;
        }

        public ReportsPageHelper DeleteReport()
        {
            _reportsPage.ClickOnTrashIconToRemoveSelectedReport()
                        .ClickOnDeleteButtonToConfirmDeletion();

            return this;
        }

    }
}
