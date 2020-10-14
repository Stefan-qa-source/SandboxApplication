using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SandboxProject.ApplicationStructure.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxProject.ApplicationStructure.Helpers
{
    class ProjectPageHelpers : ProjectsPage
    {
        private ProjectsPage _projectPage;
        WebDriverWait wait;
        public ProjectPageHelpers(IWebDriver driver) : base(driver)
        {
            _projectPage = new ProjectsPage(Driver);
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public ProjectPageHelpers DeleteProject()
        {
            _projectPage.ClickOnProjectFromTheList(1)
                .ClickOnEditProjectButton()
               .ClickOnTrashIconToRemoveSelectedProject()
               .ClickOnDeleteButtonToConfirmDeletion();

            return this;
        }
    }
}
