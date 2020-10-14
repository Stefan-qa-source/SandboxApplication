using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SandboxProject.ApplicationStructure.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SandboxProject.ApplicationStructure.Helpers
{
    class SeniorityPageHelper : SenioritiesPage
    {
        private UseCasePage _useCasePage;
        private TechnologiesPage _technologyPage;
        private SenioritiesPage _seniorityPage;
        WebDriverWait wait;
        public SeniorityPageHelper(IWebDriver driver) : base(driver)
        {
            _seniorityPage = new SenioritiesPage(Driver);
            _useCasePage = new UseCasePage(Driver);
            _technologyPage = new TechnologiesPage(Driver);
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public SeniorityPageHelper CreateSeniority()
        {
            string seniorityTitle = "test seniority";

            _seniorityPage.ClickOnCreateSeniorityButton()
                            .EnterSeniorityTitle(seniorityTitle)
                            .SubmitSeniority();

            return this;
        }

        public SeniorityPageHelper DeleteSeniority()
        {
            _seniorityPage.ClickOnSeniorityFromTheList(1)
                           .ClickOnTrashIconToRemoveSelectedSeniority()
                           .ClickOnDeleteButtonToConfirmDeletion();
            return this;
        }
    }
}
