using Sandbox_project.ApplicationStructure.Pages;
using Sandbox_project.Scenarios;
using SandboxProject.ApplicationStructure.Helpers;
using SandboxProject.ApplicationStructure.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SandboxProject.Scenarios
{
    public class ProjectsRelatedScenarios : BaseScenario
    {
        private DashboardPage _dashboardPage;
        private PlaygroundPage _playgroundPage;
        private ProjectsPage _projectPage;
        private TechnologyPageHelper _technologyPageHelper;
        private SeniorityPageHelper _seniorityPageHelper;
        private TeamsPageHelper _teamsPageHelper;
        private PeoplePageHelper _peoplePageHelper;
        private ProjectPageHelpers _projectPageHelper;

        public ProjectsRelatedScenarios() : base()
        {
            _projectPageHelper = new ProjectPageHelpers(Driver);
            _peoplePageHelper = new PeoplePageHelper(Driver);
            _technologyPageHelper = new TechnologyPageHelper(Driver);
            _seniorityPageHelper = new SeniorityPageHelper(Driver);
            _teamsPageHelper = new TeamsPageHelper(Driver);
            _projectPage = new ProjectsPage(Driver);
            _dashboardPage = new DashboardPage(Driver);
            _playgroundPage = new PlaygroundPage(Driver);

            var homePage = LoginHelper.LoginAsStandardUser();
            _dashboardPage = homePage.MainNavigation.NavigateToDashboardPage().ClickOnPlaygroundCard();
        }

        [Fact]
        public void CreateProject_Success()
        {
            #region Precondion data creation (technology, seniority, team, person)
            _playgroundPage.NavigateToTechnologiesPage();
            _technologyPageHelper.CreateTechnology();
            _playgroundPage.NavigateToSenioritiesPage();
            _seniorityPageHelper.CreateSeniority();
            _playgroundPage.NavigateToTeamsPage();
            _teamsPageHelper.CreateTeam();
            _playgroundPage.NavigateToPeoplePage();
            _peoplePageHelper.CreatePerson();
            #endregion

            // arrange
            var projectTitle = "Test project title";

            // act
            _playgroundPage.NavigateToProjectsPage();

            _projectPage.ClickOnCreateProjectButton()
                .EnterProjectTitle(projectTitle)
                .SelectPeople()
                .ClickOnSubmitButton();

            // assert
            Assert.Equal(projectTitle, _projectPage.GetProjectTitle(1));

            #region Cleaning up after test
            _playgroundPage.NavigateToTechnologiesPage();
            _technologyPageHelper.DeleteTechnology();
            _playgroundPage.NavigateToTeamsPage();
            _teamsPageHelper.DeleteTeam();
            _playgroundPage.NavigateToSenioritiesPage();
            _seniorityPageHelper.DeleteSeniority();
            _playgroundPage.NavigateToPeoplePage();
            _peoplePageHelper.DeletePerson();
            _playgroundPage.NavigateToProjectsPage();
            _projectPageHelper.DeleteProject();
            #endregion
        }
    }
}
