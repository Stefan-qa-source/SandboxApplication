using OpenQA.Selenium;
using Sandbox_project.ApplicationStructure.Constants;
using Sandbox_project.ApplicationStructure.Helpers;
using Sandbox_project.ApplicationStructure.Pages;
using SandboxProject.ApplicationStructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Sandbox_project.Scenarios
{
    public class ReportsRelatedScenario : BaseScenario
    {
        private ReportsPage _reportsPage;
        private DashboardPage _dashboardPage;
        private ReportsPageHelper _reportsPageHelper;

        public ReportsRelatedScenario() : base()
        {
            _reportsPage = new ReportsPage(Driver);
            _reportsPageHelper = new ReportsPageHelper(Driver);

            var homePage = LoginHelper.LoginAsStandardUser();
            _dashboardPage = homePage.MainNavigation.NavigateToDashboardPage().ClickOnReportsCard();
        }

        [Fact]
        public void CreateNewReportIssue_Success()
        {
            // arrange
            string summary = "test summary";

            // these two values of variables is taken from enums
            string issueType = ReportsPageConstants.REPORT_ISSUE_TYPE_Task;
            string severityType = ReportsPageConstants.SEVERITY_TYPE_Medium; 

            string priorityType = "Blocker";
            string description = "test description";
            string firstStepText = "test first step";
            string secondStepText = "test second step";

            //count the number of reports before deleting
            int oldReportIssuesCount = _reportsPage.ReportIssuesCount;

            // act
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

            // assert that number of technologies is reduced for 1
            Assert.Equal(oldReportIssuesCount + 1, _reportsPage.ReportIssuesCount);
            Assert.Equal(summary, _reportsPage.GetSummaryOfReportIssue(1));


            //  clean up
            _reportsPage.ClickOnReportFromTheList(1);
            _reportsPageHelper.DeleteReport();

        }

        [Fact]
        public void DeleteReportIssue_Success()
        { 
            // act

            _reportsPageHelper.CreateReport();

            // arrange
            int oldReportsIssueCount = _reportsPage.ReportIssuesCount;

            // act
            _reportsPage.ClickOnReportFromTheList(1)
                        .ClickOnTrashIconToRemoveSelectedReport()
                        .ClickOnDeleteButtonToConfirmDeletion();

            // assert
            Assert.Equal(oldReportsIssueCount - 1, _reportsPage.ReportIssuesCount);

        }

        [Fact]
        public void EditReportIssue_Success()
        {
            // arrange
            var editedSummary = "Edited report summary";

            // act
            _reportsPageHelper.CreateReport();

            _reportsPage.ClickOnReportFromTheList(1)
                        .EnterSummary(editedSummary)
                        .SubmitReportIssue();

            // assert
            Assert.Equal(editedSummary, _reportsPage.GetSummaryOfReportIssue(1));

            // clean up
            _reportsPage.ClickOnReportFromTheList(1);
            _reportsPageHelper.DeleteReport();
        }
    }
}
