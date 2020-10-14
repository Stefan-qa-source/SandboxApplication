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
    class TechnologyPageHelper : TechnologiesPage
    {
        private UseCasePage _useCasePage;
        private TechnologiesPage _technologyPage;
        WebDriverWait wait;
        public TechnologyPageHelper(IWebDriver driver) : base(driver)
        {
            _useCasePage = new UseCasePage(Driver);
            _technologyPage = new TechnologiesPage(Driver);
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public TechnologyPageHelper CreateTechnology()
        {
            string technologyTitle = "test technology";

            _technologyPage.ClickOnCreateTechnologyButton()
                            .EnterTechnologyTitle(technologyTitle)
                            .SubmitTechnology();

            return this;
        }

        public TechnologyPageHelper DeleteTechnology()
        {
            _technologyPage.ClickOnTechnologyFromTheList(1)
                           .ClickOnTrashIconToRemoveSelectedTechnology()
                           .ClickOnDeleteButtonToConfirmDeletion();
            return this;
        }
    }
}
