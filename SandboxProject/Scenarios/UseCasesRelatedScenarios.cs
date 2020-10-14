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

namespace SandboxProject.Scenarios
{
    public class UseCasesRelatedScenarios : BaseScenario
    {
        private UseCasePage _useCasePage;
        private DashboardPage _dashboardPage;
        private UseCasePageHelper _useCasePageHelper;

        public UseCasesRelatedScenarios() : base()
        {
            _useCasePage = new UseCasePage(Driver);
            _useCasePageHelper = new UseCasePageHelper(Driver);
            var homePage = LoginHelper.LoginAsStandardUser();
            _dashboardPage = homePage.MainNavigation.NavigateToDashboardPage().ClickOnUseCaseCard();
        }

        [Fact]
        public void CreateAndEditMultipleUseCases()
        {
            #region Create first use case
            // arrange
            string firstUseCaseTitle = "test title1";
            string firstUseCaseDescription = "test description1";
            string firstUseCaseExpectedResult = "test expected result1";
            string firstUseCaseFirstStepText = "test first step1";
            string firstUseCaseSecondStepText = "test second step1";

            int oldUseCaseCount = _useCasePage.UseCasesCount;

            // act
            _useCasePage = _useCasePage.ClickOnCreateUseCaseButton();
            _useCasePageHelper.CreateUseCase(firstUseCaseTitle, firstUseCaseDescription, firstUseCaseExpectedResult, firstUseCaseFirstStepText, firstUseCaseSecondStepText);

            // assert
            Assert.Equal(firstUseCaseTitle, _useCasePage.GetTitleOfUseCase(1));
            #endregion

            #region Create second use case
            // arrange
            string secondUseCaseTitle = "test title22";
            string secondUseCaseDescription = "test description22";
            string secondUseCaseExpectedResult = "test expected result222";
            string secondUseCaseFirstStepText = "test first step232";
            string secondUseCaseSecondStepText = "test second step2234";

            // act
            _useCasePage = _useCasePage.ClickOnCreateUseCaseButton();
            _useCasePageHelper.CreateUseCase(secondUseCaseTitle, secondUseCaseDescription, secondUseCaseExpectedResult, secondUseCaseFirstStepText, secondUseCaseSecondStepText);

            // assert
            Assert.Equal(secondUseCaseTitle, _useCasePage.GetTitleOfUseCase(1));
            #endregion

            #region Create third use case
            // arrange
            string thirdUseCaseTitle = "test title333333";
            string thirdUseCaseDescription = "test description33233242";
            string thirdUseCaseExpectedResult = "test expected result342";
            string thirdUseCaseFirstStepText = "test first step3422522";
            string thirdUseCaseSecondStepText = "test second step3525";

            // act
            _useCasePage = _useCasePage.ClickOnCreateUseCaseButton();
            _useCasePageHelper.CreateUseCase(thirdUseCaseTitle, thirdUseCaseDescription, thirdUseCaseExpectedResult, thirdUseCaseFirstStepText, thirdUseCaseSecondStepText);
            // assert
            Assert.Equal(thirdUseCaseTitle, _useCasePage.GetTitleOfUseCase(1));
            #endregion

            #region Create fourth use case
            // arrange
            string fourthUseCaseTitle = "test title454564";
            string fourthUseCaseDescription = "test description464765777";
            string fourthUseCaseExpectedResult = "test expected result4777777";
            string fourthUseCaseFirstStepText = "test first step4";
            string fourthUseCaseSecondStepText = "test second step478";


            // act
            _useCasePage = _useCasePage.ClickOnCreateUseCaseButton();
            _useCasePageHelper.CreateUseCase(fourthUseCaseTitle, fourthUseCaseDescription, fourthUseCaseExpectedResult, fourthUseCaseFirstStepText, fourthUseCaseSecondStepText);

            // assert
            Assert.Equal(fourthUseCaseTitle, _useCasePage.GetTitleOfUseCase(1));
            Assert.Equal(oldUseCaseCount + 4, _useCasePage.UseCasesCount);
            #endregion

            #region Edit first use case 
            // act
            _useCasePage = _useCasePage.ClickOnUseCaseFromTheList(4);

            // arrange
            var actualNumberOfCharactersForFirstUseCaseTitleField = _useCasePage.GetNumberOfCharactersForUseCaseTitleField();
            // act
            _useCasePage = _useCasePage.EnterUseCaseTitle("This field previously had "+ actualNumberOfCharactersForFirstUseCaseTitleField + " characters.");

            // arrange
            var newEditedFirstUseCaseTitle = "This field previously had " + actualNumberOfCharactersForFirstUseCaseTitleField + " characters.";

            // arrange
            var actualNumberOfCharactersForFirstUseCaseDescriptionField = _useCasePage.GetNumberOfCharactersForUseDescriptionField();

            //act
            _useCasePage = _useCasePage.EnterUseCaseDescription("This field previously had " + actualNumberOfCharactersForFirstUseCaseDescriptionField + " characters.");

            // arrange
            var actualNumberOfCharactersForFirstUseCaseExpectResultField = _useCasePage.GetNumberOfCharactersForUseCaseExpectedResultField();

            //act
            _useCasePage = _useCasePage.EnterUseCaseExpectedResult("This field previously had " + actualNumberOfCharactersForFirstUseCaseExpectResultField + " characters.");

            // arrange
            var actualNumberOfCharactersForFirstUseCaseFirstStepField = _useCasePage.GetNumberOfCharactersForUseCaseFirstStepField();

            //act
            _useCasePage = _useCasePage.EnterFirstStep("This field previously had " + actualNumberOfCharactersForFirstUseCaseFirstStepField + " characters.");

            // arrange
            var actualNumberOfCharactersForFirstUseCaseSecondStepField = _useCasePage.GetNumberOfCharactersForUseCaseSecondStepField();

            // act
            _useCasePage = _useCasePage.EnterSecondStep("This field previously had " + actualNumberOfCharactersForFirstUseCaseSecondStepField + " characters.");
            _useCasePage = _useCasePage.SubmitUseCase();

            // assert
            Assert.Equal(newEditedFirstUseCaseTitle, _useCasePage.GetTitleOfUseCase(4));
            #endregion

            #region Edit second use case
            // act
            _useCasePage = _useCasePage.ClickOnUseCaseFromTheList(3);

            // arrange
            var expectedNumberOfCharactersForSecondUseCaseTitleField = secondUseCaseTitle.Length;
            var actualNumberOfCharactersForSecondUseCaseTitleField = _useCasePage.GetNumberOfCharactersForUseCaseTitleField();

            // assert
            Assert.Equal(expectedNumberOfCharactersForSecondUseCaseTitleField, actualNumberOfCharactersForSecondUseCaseTitleField);

            // act
            _useCasePage = _useCasePage.EnterUseCaseTitle("This field previously had " + actualNumberOfCharactersForSecondUseCaseTitleField + " characters.");

            // arrange
            var newEditedSecondUseCaseTitle = "This field previously had " + actualNumberOfCharactersForSecondUseCaseTitleField + " characters.";
           
            // arrange
            var expectedNumberOfCharactersForSecondUseCaseDescriptionField = secondUseCaseDescription.Length;
            var actualNumberOfCharactersForSecondUseCaseDescriptionField = _useCasePage.GetNumberOfCharactersForUseDescriptionField();

            // assert
            Assert.Equal(expectedNumberOfCharactersForSecondUseCaseDescriptionField, actualNumberOfCharactersForSecondUseCaseDescriptionField);

            //act
            _useCasePage = _useCasePage.EnterUseCaseDescription("This field previously had " + actualNumberOfCharactersForSecondUseCaseDescriptionField + " characters.");

            // arrange
            var expectedNumberOfCharactersForSecondUseCaseExpectedResultField = secondUseCaseExpectedResult.Length;
            var actualNumberOfCharactersForSecondUseCaseExpectResultField = _useCasePage.GetNumberOfCharactersForUseCaseExpectedResultField();

            // assert
            Assert.Equal(expectedNumberOfCharactersForSecondUseCaseExpectedResultField, actualNumberOfCharactersForSecondUseCaseExpectResultField);

            //act
            _useCasePage = _useCasePage.EnterUseCaseExpectedResult("This field previously had " + actualNumberOfCharactersForSecondUseCaseExpectResultField + " characters.");

            // arrange
            var expectedNumberOfCharactersForSecondUseCaseFirstStepField = secondUseCaseFirstStepText.Length;
            var actualNumberOfCharactersForSecondUseCaseFirstStepField = _useCasePage.GetNumberOfCharactersForUseCaseFirstStepField();

            // assert
            Assert.Equal(expectedNumberOfCharactersForSecondUseCaseFirstStepField, actualNumberOfCharactersForSecondUseCaseFirstStepField);

            //act
            _useCasePage = _useCasePage.EnterFirstStep("This field previously had " + actualNumberOfCharactersForSecondUseCaseFirstStepField + " characters.");

            // arrange
            var expectedNumberOfCharactersForSecondUseCaseSecondStepField = secondUseCaseSecondStepText.Length;
            var actualNumberOfCharactersForSecondUseCaseSecondStepField = _useCasePage.GetNumberOfCharactersForUseCaseSecondStepField();

            // assert
            Assert.Equal(expectedNumberOfCharactersForSecondUseCaseSecondStepField, actualNumberOfCharactersForSecondUseCaseSecondStepField);

            // act
            _useCasePage = _useCasePage.EnterSecondStep("This field previously had " + actualNumberOfCharactersForSecondUseCaseSecondStepField + " characters.");
            _useCasePage = _useCasePage.SubmitUseCase();

            // assert
            Assert.Equal(newEditedSecondUseCaseTitle, _useCasePage.GetTitleOfUseCase(3));
            #endregion

            #region Edit third use case
            // act
            _useCasePage = _useCasePage.ClickOnUseCaseFromTheList(2);

            // arrange
            var expectedNumberOfCharactersForThirdUseCaseTitleField = thirdUseCaseTitle.Length;
            var actualNumberOfCharactersForThirdhUseCaseTitleField = _useCasePage.GetNumberOfCharactersForUseCaseTitleField();

            // assert
            Assert.Equal(expectedNumberOfCharactersForThirdUseCaseTitleField, actualNumberOfCharactersForThirdhUseCaseTitleField);

            // act
            _useCasePage = _useCasePage.EnterUseCaseTitle("This field previously had " + actualNumberOfCharactersForThirdhUseCaseTitleField + " characters.");
            
            // arrange
            var newEditedThirdUseCaseTitle = "This field previously had " + actualNumberOfCharactersForThirdhUseCaseTitleField + " characters.";

            // arrange
            var expectedNumberOfCharactersForThirdUseCaseDescriptionField = thirdUseCaseDescription.Length;
            var actualNumberOfCharactersForThirdUseCaseDescriptionField = _useCasePage.GetNumberOfCharactersForUseDescriptionField();

            // assert
            Assert.Equal(expectedNumberOfCharactersForThirdUseCaseDescriptionField, actualNumberOfCharactersForThirdUseCaseDescriptionField);

            //act
            _useCasePage = _useCasePage.EnterUseCaseDescription("This field previously had " + actualNumberOfCharactersForThirdUseCaseDescriptionField + " characters.");

            // arrange
            var expectedNumberOfCharactersForThirdUseCaseExpectedResultField = thirdUseCaseExpectedResult.Length;
            var actualNumberOfCharactersForThirdUseCaseExpectResultField = _useCasePage.GetNumberOfCharactersForUseCaseExpectedResultField();

            // assert
            Assert.Equal(expectedNumberOfCharactersForThirdUseCaseExpectedResultField, actualNumberOfCharactersForThirdUseCaseExpectResultField);

            // act
            _useCasePage = _useCasePage.EnterUseCaseExpectedResult("This field previously had " + actualNumberOfCharactersForThirdUseCaseExpectResultField + " characters.");

            // arrange
            var expectedNumberOfCharactersForThirdUseCaseFirstStepField = thirdUseCaseFirstStepText.Length;
            var actualNumberOfCharactersForThirdUseCaseFirstStepField = _useCasePage.GetNumberOfCharactersForUseCaseFirstStepField();

            // assert
            Assert.Equal(expectedNumberOfCharactersForThirdUseCaseFirstStepField, actualNumberOfCharactersForThirdUseCaseFirstStepField);

            // act
            _useCasePage = _useCasePage.EnterFirstStep("This field previously had " + actualNumberOfCharactersForThirdUseCaseFirstStepField + " characters.");

            // arrange
            var expectedNumberOfCharactersForThirdUseCaseSecondStepField = thirdUseCaseSecondStepText.Length;
            var actualNumberOfCharactersForThirdUseCaseSecondStepField = _useCasePage.GetNumberOfCharactersForUseCaseSecondStepField();

            // assert
            Assert.Equal(expectedNumberOfCharactersForThirdUseCaseSecondStepField, actualNumberOfCharactersForThirdUseCaseSecondStepField);

            // act
            _useCasePage = _useCasePage.EnterSecondStep("This field previously had " + actualNumberOfCharactersForThirdUseCaseSecondStepField + " characters.");
            _useCasePage = _useCasePage.SubmitUseCase();

            // assert
            Assert.Equal(newEditedThirdUseCaseTitle, _useCasePage.GetTitleOfUseCase(2));
            #endregion

            #region Edit fourth use case
            // act
            _useCasePage = _useCasePage.ClickOnUseCaseFromTheList(1);

            // arrange
            var expectedNumberOfCharactersForFourthUseCaseTitleField = fourthUseCaseTitle.Length;
            var actualNumberOfCharactersForFourthUseCaseTitleField = _useCasePage.GetNumberOfCharactersForUseCaseTitleField();

            // assert
            Assert.Equal(expectedNumberOfCharactersForFourthUseCaseTitleField, actualNumberOfCharactersForFourthUseCaseTitleField);

            // act
            _useCasePage = _useCasePage.EnterUseCaseTitle("This field previously had " + actualNumberOfCharactersForFourthUseCaseTitleField + " characters.");

            // arrange
            var newEditedFourthUseCaseTitle = "This field previously had " + actualNumberOfCharactersForFourthUseCaseTitleField + " characters.";

            // arrange
            var expectedNumberOfCharactersForFourthUseCaseDescriptionField = fourthUseCaseDescription.Length;
            var actualNumberOfCharactersForFourthUseCaseDescriptionField = _useCasePage.GetNumberOfCharactersForUseDescriptionField();

            // assert
            Assert.Equal(expectedNumberOfCharactersForFourthUseCaseDescriptionField, actualNumberOfCharactersForFourthUseCaseDescriptionField);

            //act
            _useCasePage = _useCasePage.EnterUseCaseDescription("This field previously had " + actualNumberOfCharactersForFourthUseCaseDescriptionField + " characters.");

            // arrange
            var expectedNumberOfCharactersForFourthUseCaseExpectedResultField = fourthUseCaseExpectedResult.Length;
            var actualNumberOfCharactersForFourthUseCaseExpectResultField = _useCasePage.GetNumberOfCharactersForUseCaseExpectedResultField();

            // assert
            Assert.Equal(expectedNumberOfCharactersForFourthUseCaseExpectedResultField, actualNumberOfCharactersForFourthUseCaseExpectResultField);

            //act
            _useCasePage = _useCasePage.EnterUseCaseExpectedResult("This field previously had " + actualNumberOfCharactersForFourthUseCaseExpectResultField + " characters.");

            // arrange
            var expectedNumberOfCharactersForFourthUseCaseFirstStepField = fourthUseCaseFirstStepText.Length;
            var actualNumberOfCharactersForFourthUseCaseFirstStepField = _useCasePage.GetNumberOfCharactersForUseCaseFirstStepField();

            // assert
            Assert.Equal(expectedNumberOfCharactersForFourthUseCaseFirstStepField, actualNumberOfCharactersForFourthUseCaseFirstStepField);

            // act
            _useCasePage = _useCasePage.EnterFirstStep("This field previously had " + actualNumberOfCharactersForFourthUseCaseFirstStepField + " characters.");

            // arrange
            var expectedNumberOfCharactersForFourthUseCaseSecondStepField = fourthUseCaseSecondStepText.Length;
            var actualNumberOfCharactersForFourthUseCaseSecondStepField = _useCasePage.GetNumberOfCharactersForUseCaseSecondStepField();

            // assert
            Assert.Equal(expectedNumberOfCharactersForFourthUseCaseSecondStepField, actualNumberOfCharactersForFourthUseCaseSecondStepField);

            // act
            _useCasePage = _useCasePage.EnterSecondStep("This field previously had " + actualNumberOfCharactersForFourthUseCaseSecondStepField + " characters.");
            _useCasePage = _useCasePage.SubmitUseCase();

            // assert
            Assert.Equal(newEditedThirdUseCaseTitle, _useCasePage.GetTitleOfUseCase(1));
            #endregion

            #region Cleaning up after completion of test
            _useCasePage = _useCasePage.ClickOnUseCaseFromTheList(4);
            _useCasePageHelper = _useCasePageHelper.DeleteUseCase();
            _useCasePage = _useCasePage.ClickOnUseCaseFromTheList(3);
            _useCasePageHelper = _useCasePageHelper.DeleteUseCase();
            _useCasePage = _useCasePage.ClickOnUseCaseFromTheList(2);
            _useCasePageHelper = _useCasePageHelper.DeleteUseCase();
            _useCasePage = _useCasePage.ClickOnUseCaseFromTheList(1);
            _useCasePageHelper = _useCasePageHelper.DeleteUseCase();
            #endregion
        }
    }
}
