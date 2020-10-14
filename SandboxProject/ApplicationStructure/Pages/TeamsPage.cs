using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sandbox_project.ApplicationStructure.Base;
using SandboxProject.ApplicationStructure.Constants;
using System;


namespace SandboxProject.ApplicationStructure.Pages
{
    public class TeamsPage : PageObject
    {
        WebDriverWait wait;
        public TeamsPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public TeamsPage ClickOnCreateTeamButton()
        {
            var teamButton = Driver.FindElement(By.XPath(TeamsPageConstants.CreateTeamButton));
            teamButton.Click();
            return this;
        }

        public TeamsPage EnterTeamTitle(string text)
        {
            var teamField = Driver.FindElement(By.Name(TeamsPageConstants.TeamTitleField));
            teamField.Clear();
            teamField.SendKeys(text);
            return this;
        }

        public TeamsPage SubmitTeam()
        {
            var submitButton = Driver.FindElement(By.XPath(TeamsPageConstants.SubmitButton));
            submitButton.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'Teams')]")));

            return this;

        }

        public TeamsPage ClickOnTeamFromTheList(int teamRow)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']/a[" + teamRow + "]")));

            var element = Driver.FindElement(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']/a[" + teamRow + "]"));
            element.Click();

            //var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(TeamsPageConstants.RemoveButton)));

            return this;
        }

        public TeamsPage ClickOnTrashIconToRemoveSelectedTeam()
        {
            var trashIcon = Driver.FindElement(By.XPath(TeamsPageConstants.RemoveButton));
            trashIcon.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(TeamsPageConstants.ConfirmDeletionButton))); //   

            return this;
        }

        public TeamsPage ClickOnSubmitButton()
        {
            var submitButton = Driver.FindElement(By.XPath(TeamsPageConstants.SubmitButton));
            submitButton.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class= 'invalid-feedback']"))); //

            return this;
        }
            public TeamsPage ClickOnDeleteButtonToConfirmDeletion()
        {
            var deleteButton = Driver.FindElement(By.XPath(TeamsPageConstants.ConfirmDeletionButton));
            deleteButton.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(TeamsPageConstants.CreateTeamButton))); //   

            return this;
        }

        private string GetTableCellText(string xpathLocation)
        {
            return Driver.FindElement(By.XPath(xpathLocation)).Text.Trim();
        }

        public string GetTitleOfTeam(int teamRow)
        {
            return GetTableCellText("//div[@class= 'card-profile shadow ml-1 mr-1']/a[" + teamRow + "]");
        }


        public int TeamCount
        {
            get
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                var element = Driver.FindElements(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']//a[contains(@href, '/roles')]"));
                return element.Count;

            }
        }
    }
}
