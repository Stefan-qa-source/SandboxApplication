using SandboxProject.ApplicationStructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox_project.ApplicationStructure.Constants
{
    public class ReportsPageConstants
    {
        public static readonly string ReportIssueButton = "//a[contains(@data-testid, 'report_issue_btn')]";
        public static readonly string AddStepButton = "//button[contains(@data-testid, 'add_step_btn')]";
        public static readonly string SummaryField = "summary";
        public static readonly string IssueType = "type";
        public static readonly string SeverityType = "severity";
        public static readonly string PriorityType = "priority";
        public static readonly string DescriptionField = "description";
        public static readonly string FirstStepField = "testStepId-0";
        public static readonly string SecondStepField = "testStepId-1";
        public static readonly string SubmitButton = "//button[contains(@data-testid, 'submit_btn')]";
        public static readonly string ListOfReportedIssue = "//div[@class='list-group']";
        public static readonly string RemoveButton = "//button[contains(@data-testid, 'remove_report_btn')]";
        public static readonly string ConfirmDeletionButton = "//button[@class= 'btn btn-lg btn-danger ']";

        // enums
        public static readonly string REPORT_ISSUE_TYPE_Task = ReportIssueTypeEnum.Task.ToString();
        public static readonly string SEVERITY_TYPE_Medium = SeverityTypeEnum.Medium.ToString();
        public static readonly string PRIORITY_TYPE_Blocker = PriorityTypeEnum.Blocker.ToString();
    }
}
