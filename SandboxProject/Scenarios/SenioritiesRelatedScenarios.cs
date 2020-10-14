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
    public class SenioritiesRelatedScenarios : BaseScenario
    {
        private DashboardPage _dashboardPage;
        private PlaygroundPage _playgroundPage;
        private SenioritiesPage _seniorityPage;
        private SeniorityPageHelper _seniorityPageHelper;
        private PlaygroudPageHelpers _playgroundPageHelpers;

        public SenioritiesRelatedScenarios() : base()
        {
            _seniorityPageHelper = new SeniorityPageHelper(Driver);
            _seniorityPage = new SenioritiesPage(Driver);
            _dashboardPage = new DashboardPage(Driver);
            _playgroundPage = new PlaygroundPage(Driver);
            _playgroundPageHelpers = new PlaygroudPageHelpers(Driver);

            var homePage = LoginHelper.LoginAsStandardUser();
            _dashboardPage = homePage.MainNavigation.NavigateToDashboardPage().ClickOnPlaygroundCard();
            _playgroundPage.NavigateToSenioritiesPage();
        }

        [Fact]
        public void CreateNewSeniority_Success()
        {
            // arrange
            var seniorityTitle = "Test seniority title";

            // act
            _seniorityPage.ClickOnCreateSeniorityButton();
            _seniorityPage.EnterSeniorityTitle(seniorityTitle);
            _seniorityPage.SubmitSeniority();

            // assert
            Assert.Equal(seniorityTitle, _seniorityPage.GetTitleOfSeniority(1));

            // clean up
            _seniorityPageHelper.DeleteSeniority();
        }

        [Fact]
        public void DeleteSeniority_Success()
        {
            // arrange
            string seniorityTitle = "test seniority";

            // act
            // --- in order to able to delete seniority we must have some seniority created
            _seniorityPageHelper.CreateSeniority();

            // arrange
            //count the number of seniorities before deleting
            var oldSeniorityCount = _seniorityPage.SenioritiesCount;

            _seniorityPage.ClickOnSeniorityFromTheList(1)
                            .ClickOnTrashIconToRemoveSelectedSeniority()
                            .ClickOnDeleteButtonToConfirmDeletion();

            // assert that number of seniorities is reduced for 1
            Assert.Equal(oldSeniorityCount - 1, _seniorityPage.SenioritiesCount);
            Assert.False(_playgroundPageHelpers.CheckIfTitleOfItemIsDisplayed(1, seniorityTitle));
        }

        [Fact]
        public void EditSeniority_Success()
        {
            // arrange
            var editedSeniorityTitle = "edited seniority title";

            // act
            // --- in order to able to update/edit seniority we must have some seniority created
            _seniorityPageHelper.CreateSeniority();

            _seniorityPage.ClickOnSeniorityFromTheList(1)
                           .EnterSeniorityTitle(editedSeniorityTitle)
                           .SubmitSeniority();

            // assert
            Assert.Equal(editedSeniorityTitle, _seniorityPage.GetTitleOfSeniority(1));

            // clean up
            _seniorityPageHelper.DeleteSeniority();
        }

        [Fact]
        public void CreateTwoSeniorityWithSameTitle()
        {
            // arrange

            string seniorityTitle = "test seniority";
            var validationMessage = "Seniority title already exists";

            // act
            _seniorityPageHelper.CreateSeniority();

            _seniorityPage.ClickOnCreateSeniorityButton();
            _seniorityPage.EnterSeniorityTitle(seniorityTitle);
            _seniorityPage.ClickOnSubmitButton();


            Assert.True(_seniorityPage.CheckIfValidationMessageIsDisplayed());
            Assert.Equal(validationMessage, _seniorityPage.GetValidationMessageForSameNameSeniority());

            // clean up
            _seniorityPage.ClickOnLeftArrowToRevertOnSenioritiessSection();
            _seniorityPageHelper.DeleteSeniority();



        }
    }
}

