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
    class TeamsPageHelper : TeamsPage
    {
        private UseCasePage _useCasePage;
        private TechnologiesPage _technologyPage;
        private SenioritiesPage _seniorityPage;
        private TeamsPage _teamsPage;
        WebDriverWait wait;
        public TeamsPageHelper(IWebDriver driver) : base(driver)
        {
            _teamsPage = new TeamsPage(Driver);
            _seniorityPage = new SenioritiesPage(Driver);
            _useCasePage = new UseCasePage(Driver);
            _technologyPage = new TechnologiesPage(Driver);
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public TeamsPageHelper CreateTeam()
        {
            string teamTitle = "test team";

            _teamsPage.ClickOnCreateTeamButton()
                            .EnterTeamTitle(teamTitle)
                            .SubmitTeam();

            return this;
        }

        public TeamsPageHelper DeleteTeam()
        {
            _teamsPage.ClickOnTeamFromTheList(1)
                           .ClickOnTrashIconToRemoveSelectedTeam()
                           .ClickOnDeleteButtonToConfirmDeletion();
            return this;
        }
    }
}
