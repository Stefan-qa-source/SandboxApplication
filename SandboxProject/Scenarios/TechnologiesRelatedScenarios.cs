using Sandbox_project.ApplicationStructure.Pages;
using Sandbox_project.Scenarios;
using SandboxProject.ApplicationStructure.Helpers;
using SandboxProject.ApplicationStructure.Pages;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SandboxProject.Scenarios
{
    public class TechnologiesRelatedScenarios : BaseScenario
    {
        private DashboardPage _dashboardPage;
        private PlaygroundPage _playgroundPage;
        private TechnologiesPage _technologyPage;
        private TechnologyPageHelper _technologyPageHelper;
        private ValidationMessagesHelper _validationMessagesHelper;
        private PlaygroudPageHelpers _playgroundPageHelpers;
        public TechnologiesRelatedScenarios() : base()
        {
            _playgroundPageHelpers = new PlaygroudPageHelpers(Driver);
            _validationMessagesHelper = new ValidationMessagesHelper(Driver);
            _technologyPageHelper = new TechnologyPageHelper(Driver);
            _technologyPage = new TechnologiesPage(Driver);
            _dashboardPage = new DashboardPage(Driver);
            _playgroundPage = new PlaygroundPage(Driver);

            var homePage = LoginHelper.LoginAsStandardUser();
            _dashboardPage = homePage.MainNavigation.NavigateToDashboardPage().ClickOnPlaygroundCard();
            _playgroundPage.NavigateToTechnologiesPage();
        }

        [Fact]
        public void CreateNewTechnology_Success()
        {
            // arrange
            var technologyTitle = "Test technology title";

            // act
            _technologyPage.ClickOnCreateTechnologyButton();
            _technologyPage.EnterTechnologyTitle(technologyTitle);
            _technologyPage.SubmitTechnology();

            // assert
            Assert.Equal(technologyTitle, _technologyPage.GetTitleOfTechnology(1));

            // clean up
            _technologyPageHelper.DeleteTechnology();

        }

        [Fact]
        public void DeleteTechnology_Success()
        {
            // arrange
            string technologyTitle = "test technology";

            // act
            // --- in order to able to delete technology we must have some technology created
            _technologyPageHelper.CreateTechnology();

            // arrange
            //count the number of technologies before deleting
            var oldTechnologyCount = _technologyPage.TechnologiesCount;

            _technologyPage.ClickOnTechnologyFromTheList(1)
                            .ClickOnTrashIconToRemoveSelectedTechnology()
                            .ClickOnDeleteButtonToConfirmDeletion();

            // assert that number of technologies is reduced for 1
            Assert.Equal(oldTechnologyCount - 1, _technologyPage.TechnologiesCount);
            Assert.False(_playgroundPageHelpers.CheckIfTitleOfItemIsDisplayed(1, technologyTitle));
        }

        [Fact]
        public void EditTechnology_Success()
        {
            // arrange
            var editedTechnologyTitle = "edited technology title";

            // act
            // --- in order to able to update/edit technology we must have some technology created
            _technologyPageHelper.CreateTechnology();

            _technologyPage.ClickOnTechnologyFromTheList(1)
                           .EnterTechnologyTitle(editedTechnologyTitle)
                           .SubmitTechnology();

            // assert
            Assert.Equal(editedTechnologyTitle, _technologyPage.GetTitleOfTechnology(1));

            // clean up
            _technologyPageHelper.DeleteTechnology();
        }

        [Fact]
        public void CreateTechnologyWithMoreCharactersThanAllowed()
        {
            // arrange
            var technologyTitle = "1234567890123456789012345678901"; // here we have 31 characters
            var validationMessage = "Title needs to be between 2 and 30";

            // act
            _technologyPage.ClickOnCreateTechnologyButton();
            _technologyPage.EnterTechnologyTitle(technologyTitle);
            _technologyPage.ClickOnSubmitButton();

            // assert
            Assert.True(_validationMessagesHelper.CheckIfValidationMessageIsDisplayed());
            Assert.Equal(validationMessage, _validationMessagesHelper.GetValidationMessage());

        }

    }
}
