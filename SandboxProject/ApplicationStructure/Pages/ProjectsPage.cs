using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sandbox_project.ApplicationStructure.Base;
using SandboxProject.ApplicationStructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxProject.ApplicationStructure.Pages
{
    public class ProjectsPage : PageObject
    {
        WebDriverWait wait;
        public ProjectsPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public ProjectsPage ClickOnCreateProjectButton()
        {
            var createProjectButton = Driver.FindElement(By.XPath(ProjectsPageConstants.CreateProjectButton));
            createProjectButton.Click();
            return this;
        }

        public ProjectsPage EnterProjectTitle(string title)
        {
            var titleField = Driver.FindElement(By.Name(ProjectsPageConstants.ProjectTitleField));
            titleField.Clear();
            titleField.SendKeys(title);

            return this;
        }

        public ProjectsPage SelectPeople()
        {
            var expandDropDown = Driver.FindElement(By.XPath("//form/div[2]//div[@class= 'react-dropdown-select-dropdown-handle css-1jmeyq5-DropdownHandleComponent e1vudypg0']"));
            expandDropDown.Click();

            var choise = Driver.FindElement(By.XPath("//div[contains(@class, 'DropDown')]/span"));
            choise.Click();

            var collapseDropDown = Driver.FindElement(By.XPath("//form/div[2]//div[contains(@class, 'select-dropdown-handle')]"));
            collapseDropDown.Click();

            return this;
        }

        public ProjectsPage ClickOnSubmitButton()
        {
            var element = Driver.FindElement(By.XPath(SenioritiesPageConstants.SubmitButton));
            element.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']")));
            return this;
        }

        public string GetProjectTitle(int projectRow)
        {
            var element = Driver.FindElement(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']/a[" + projectRow + "]"));
            return element.Text;
        }

        public ProjectsPage ClickOnProjectFromTheList(int projectRow)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']/a[" + projectRow + "]")));

            var element = Driver.FindElement(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']/a[" + projectRow + "]"));
            element.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ProjectsPageConstants.EditProjectButton)));

            return this;
        }

        public ProjectsPage ClickOnEditProjectButton()
        {
            var element = Driver.FindElement(By.XPath(ProjectsPageConstants.EditProjectButton));
            element.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(PeoplePageConstants.RemoveButton)));

            return this;
        }

        public ProjectsPage ClickOnTrashIconToRemoveSelectedProject()
        {
            var trashIcon = Driver.FindElement(By.XPath(PeoplePageConstants.RemoveButton));
            trashIcon.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(PeoplePageConstants.ConfirmDeletionButton))); //   

            return this;
        }

        public ProjectsPage ClickOnDeleteButtonToConfirmDeletion()
        {
            var trashIcon = Driver.FindElement(By.XPath(PeoplePageConstants.ConfirmDeletionButton));
            trashIcon.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ProjectsPageConstants.CreateProjectButton))); //   

            return this;
        }
    }
}
