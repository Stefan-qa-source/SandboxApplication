using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sandbox_project.ApplicationStructure.Base;
using Sandbox_project.ApplicationStructure.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sandbox_project.ApplicationStructure.Pages
{
    public class ReportsPage : PageObject
    {
        WebDriverWait wait;
        public ReportsPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public ReportsPage ClickOnReportIssueButton()
        {
            var reportIssueButton = Driver.FindElement(By.XPath(ReportsPageConstants.ReportIssueButton));
            reportIssueButton.Click();
            return this;
        }

        public ReportsPage EnterSummary(string summary)
        {
            var summaryField = Driver.FindElement(By.Name(ReportsPageConstants.SummaryField));
            summaryField.Clear();
            summaryField.SendKeys(summary);
            return this;
        }

        public ReportsPage SelectIssueType(string issueType)
        {
            var issueTypedropDown = Driver.FindElement(By.Name(ReportsPageConstants.IssueType));
            SelectElement select = new SelectElement(issueTypedropDown);
            select.SelectByValue(issueType);

            return this;
        }

        public ReportsPage SelectSeverityType(string severityType)
        {
            var severityDropDown = Driver.FindElement(By.Name(ReportsPageConstants.SeverityType));
            SelectElement select = new SelectElement(severityDropDown);
            select.SelectByValue(severityType);

            return this;
        }

        public ReportsPage SelectPriorityType(string priorityType)
        {
            var priorityDropDown = Driver.FindElement(By.Name(ReportsPageConstants.PriorityType));
            SelectElement select = new SelectElement(priorityDropDown);
            select.SelectByValue(priorityType);

            return this;
        }

        public ReportsPage EnterDescription(string description)
        {
            var descriptionField = Driver.FindElement(By.Name(ReportsPageConstants.DescriptionField));
            descriptionField.SendKeys(description);
            return this;
        }

        public ReportsPage EnterFirstStep(string text)
        {
            var firstStepField = Driver.FindElement(By.Name(ReportsPageConstants.FirstStepField));
            firstStepField.SendKeys(text);
            return this;
        }

        public ReportsPage AddNewStep()
        {
            var addStepButton = Driver.FindElement(By.XPath(ReportsPageConstants.AddStepButton));
            addStepButton.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name(ReportsPageConstants.SecondStepField)));

            return this;
        }

        public ReportsPage EnterSecondStep(string text)
        {
            var secondStepField = Driver.FindElement(By.Name(ReportsPageConstants.SecondStepField));
            secondStepField.SendKeys(text);
            return this;
        }

        public ReportsPage SubmitReportIssue()
        {
            var submitButton = Driver.FindElement(By.XPath(ReportsPageConstants.SubmitButton));
            submitButton.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15)); 
            Thread.Sleep(1000);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ReportsPageConstants.ListOfReportedIssue))); // lista kreiranih itema

            return this;
        }

        public ReportsPage ClickOnReportFromTheList(int reportRow)
        {
            var element = Driver.FindElement(By.XPath("//div[@class= 'list-group']/a[" + reportRow + "]"));
            element.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ReportsPageConstants.RemoveButton)));

            return this;
        }

        public ReportsPage ClickOnTrashIconToRemoveSelectedReport()
        {
            var trashIcon = Driver.FindElement(By.XPath(ReportsPageConstants.RemoveButton));
            trashIcon.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ReportsPageConstants.ConfirmDeletionButton))); //   

            return this;
        }

        public ReportsPage ClickOnDeleteButtonToConfirmDeletion()
        {
            var trashIcon = Driver.FindElement(By.XPath(ReportsPageConstants.ConfirmDeletionButton));
            trashIcon.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ReportsPageConstants.ReportIssueButton))); //   
            Thread.Sleep(1000);
            return this;
        }

        public int ReportIssuesCount
        {
            get
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                var element = Driver.FindElements(By.XPath("//a[contains(@href, '/reports')]"));
                return element.Count;
                
            }
        }


        private string GetTableCellText(string xpathLocation)
        {
            return Driver.FindElement(By.XPath(xpathLocation)).Text.Trim();
        }

        public string GetSummaryOfReportIssue(int reportIssueRow)
        {
            return GetTableCellText(ReportsPageConstants.ListOfReportedIssue + "/a["+reportIssueRow+"]");
        }


    }
}
