using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sandbox_project.ApplicationStructure.Pages;
using SandboxProject.ApplicationStructure.Pages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SandboxProject.ApplicationStructure.Helpers
{
    class UseCasePageHelper : UseCasePage
    {
       // private DashboardPage _dashboardPage;
        private UseCasePage _useCasePage;
        WebDriverWait wait;
        public UseCasePageHelper(IWebDriver driver) : base(driver)
        {
           // _dashboardPage = new DashboardPage(Driver);
            _useCasePage = new UseCasePage(Driver);

            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public UseCasePageHelper CreateUseCase(string useCaseTitle, string useCaseDescription, string useCaseExpectedResult, string firstStepText, string secondStepText)
        {
            _useCasePage.EnterUseCaseTitle(useCaseTitle);
            _useCasePage.EnterUseCaseDescription(useCaseDescription);
            _useCasePage.EnterUseCaseExpectedResult(useCaseExpectedResult);
            _useCasePage.EnterFirstStep(firstStepText);
            _useCasePage.AddNewStep();
            _useCasePage.EnterSecondStep(secondStepText);
            _useCasePage.SubmitUseCase();

            return this;
        }

        public UseCasePageHelper DeleteUseCase()
        {
            _useCasePage.ClickOnTrashIconToRemoveSelectedUseCase()
                        .ClickOnDeleteButtonToConfirmDeletion();

            return this;
        }
    }
}
