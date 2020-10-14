using Sandbox_project.ApplicationStructure.Pages;
using Sandbox_project.Scenarios;
using SandboxProject.ApplicationStructure.Helpers;
using SandboxProject.ApplicationStructure.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace SandboxProject.Scenarios
{
    public class PeopleRelatedScenarios : BaseScenario
    {
        private DashboardPage _dashboardPage;
        private PlaygroundPage _playgroundPage;
        private PeoplePage _peoplePage;
        private PeoplePageHelper _peoplePageHelper;
        private TechnologyPageHelper _technologyPageHelper;
        private SeniorityPageHelper _seniorityPageHelper;
        private TeamsPageHelper _teamsPageHelper;
        private PlaygroudPageHelpers _playgroundPageHelpers;
        public PeopleRelatedScenarios() : base()
        {
            _playgroundPageHelpers = new PlaygroudPageHelpers(Driver);
            _teamsPageHelper = new TeamsPageHelper(Driver);
            _seniorityPageHelper = new SeniorityPageHelper(Driver);
            _technologyPageHelper = new TechnologyPageHelper(Driver);
            _peoplePageHelper = new PeoplePageHelper(Driver);
            _peoplePage = new PeoplePage(Driver);
            _dashboardPage = new DashboardPage(Driver);
            _playgroundPage = new PlaygroundPage(Driver);

            // this will be called before each test on people page
            var homePage = LoginHelper.LoginAsStandardUser();
            _dashboardPage = homePage.MainNavigation.NavigateToDashboardPage().ClickOnPlaygroundCard();
            _playgroundPage.NavigateToPeoplePage();
        }

        [Fact]
        public void CreatePerson_Success()
        {
            // arrange
            var personFullName = "Marko Markovic";

            #region CreateDataBeforeTest
            // in order to create person we need to have technology, team and seniority created

            _playgroundPage.NavigateToTechnologiesPage();
            _technologyPageHelper.CreateTechnology();

            _playgroundPage.NavigateToSenioritiesPage();
            _seniorityPageHelper.CreateSeniority();

            _playgroundPage.NavigateToTeamsPage();
            _teamsPageHelper.CreateTeam();
            #endregion

            // act
            _playgroundPage.NavigateToPeoplePage();
            _peoplePage.ClickOnCreatePersonButton()
                       .EnterPersonFullName(personFullName)
                       .SelectTechnology()
                       .SelectSeniority()
                       .SelectTeam()
                       .SubmitPerson();

            // assert
            Assert.Equal(personFullName, _peoplePage.GetPersonFullName(1));

            // clean up
            #region Cleaning up after completion of the test
            _peoplePageHelper.DeletePerson();

            _playgroundPage.NavigateToTechnologiesPage();
            _technologyPageHelper.DeleteTechnology();

            _playgroundPage.NavigateToSenioritiesPage();
            _seniorityPageHelper.DeleteSeniority();

            _playgroundPage.NavigateToTeamsPage();
            _teamsPageHelper.DeleteTeam();
            #endregion

        }

        [Fact]
        public void DeletePeople()
        {
            #region CreateDataBeforeTest
            // in order to create person we need to have technology, team and seniority created

            _playgroundPage.NavigateToTechnologiesPage();
            _technologyPageHelper.CreateTechnology();

            _playgroundPage.NavigateToSenioritiesPage();
            _seniorityPageHelper.CreateSeniority();

            _playgroundPage.NavigateToTeamsPage();
            _teamsPageHelper.CreateTeam();
            #endregion

            _playgroundPage.NavigateToPeoplePage();

            // --- in order to able to delete people we must have some people created
            _peoplePageHelper.CreatePerson();

            string personFullName = "Darko Darkovic";
            var oldPeopleCount = _peoplePage.PeopleCount;

            _peoplePage.ClickOnPersonFromTheList(1)
                            .ClickOnTrashIconToRemoveSelectedPerson()
                            .ClickOnDeleteButtonToConfirmDeletion();

            // assert
            Assert.Equal(oldPeopleCount - 1, _peoplePage.PeopleCount);
            Assert.False(_playgroundPageHelpers.CheckIfTitleOfItemIsDisplayed(1, personFullName));

            // clean up
            #region Cleaning up after completion of the test
            _playgroundPage.NavigateToTechnologiesPage();

            _technologyPageHelper.DeleteTechnology();

            _playgroundPage.NavigateToSenioritiesPage();

            _seniorityPageHelper.DeleteSeniority();

            _playgroundPage.NavigateToTeamsPage();

            _teamsPageHelper.DeleteTeam();
            #endregion
        }
    }
}
