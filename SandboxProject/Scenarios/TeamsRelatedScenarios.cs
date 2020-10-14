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
    public class TeamsRelatedScenarios : BaseScenario
    {
        private DashboardPage _dashboardPage;
        private PlaygroundPage _playgroundPage;
        private TeamsPage _teamsPage;
        private TeamsPageHelper _teamsPageHelper;
        private ValidationMessagesHelper _validationMessagesHelper;
        private PlaygroudPageHelpers _playgroundPageHelpers;

        public TeamsRelatedScenarios() : base()
        {
            _playgroundPageHelpers = new PlaygroudPageHelpers(Driver);
            _validationMessagesHelper = new ValidationMessagesHelper(Driver);
            _teamsPageHelper = new TeamsPageHelper(Driver);
            _teamsPage = new TeamsPage(Driver);
            _dashboardPage = new DashboardPage(Driver);
            _playgroundPage = new PlaygroundPage(Driver);

            var homePage = LoginHelper.LoginAsStandardUser();
            _dashboardPage = homePage.MainNavigation.NavigateToDashboardPage().ClickOnPlaygroundCard();
            _playgroundPage.NavigateToTeamsPage();
        }

        [Fact]
        public void CreateTeam_Success()
        {
            // arrange
            var teamTitle = "Test team title";

            // act
            _teamsPage.ClickOnCreateTeamButton();
            _teamsPage.EnterTeamTitle(teamTitle);
            _teamsPage.SubmitTeam();

            // assert
            Assert.Equal(teamTitle, _teamsPage.GetTitleOfTeam(1));

            // clean up
            _teamsPageHelper.DeleteTeam();
        }

        [Fact]
        public void DeleteTeam_Success()
        {
            // arrange
            string teamTitle = "test team";
            // act
            // --- in order to able to delete team we must have some team created
            _teamsPageHelper.CreateTeam();

            // arrange
            var oldTeamCount = _teamsPage.TeamCount;

            _teamsPage.ClickOnTeamFromTheList(1)
                      .ClickOnTrashIconToRemoveSelectedTeam()
                      .ClickOnDeleteButtonToConfirmDeletion();

            // assert
            Assert.Equal(oldTeamCount - 1, _teamsPage.TeamCount);
            Assert.False(_playgroundPageHelpers.CheckIfTitleOfItemIsDisplayed(1, teamTitle));
        }

        [Fact]
        public void EditTeam_Success()
        {
            // arrange
            var editedTeamTitle = "edited team title";

            // act
            // --- in order to able to update/edit team we must have some team created
            _teamsPageHelper.CreateTeam();

            _teamsPage.ClickOnTeamFromTheList(1)
                           .EnterTeamTitle(editedTeamTitle)
                           .SubmitTeam();

            // assert
            Assert.Equal(editedTeamTitle, _teamsPage.GetTitleOfTeam(1));

            // clean up
            _teamsPageHelper.DeleteTeam();
        }

        [Fact]
        public void CreateTeamWithoutFillingInTitleField_UnSuccess()
        {

            // arrange
            var validationMessage = "Role name is required";

            // act
            _teamsPage.ClickOnCreateTeamButton();
            _teamsPage.ClickOnSubmitButton();

            Assert.True(_validationMessagesHelper.CheckIfValidationMessageIsDisplayed());
            Assert.Equal(validationMessage, _validationMessagesHelper.GetValidationMessage());
        }
    }
}
