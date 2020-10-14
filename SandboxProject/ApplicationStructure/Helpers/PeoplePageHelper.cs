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
    class PeoplePageHelper : PeoplePage
    {
        private PeoplePage _peoplePage;
        WebDriverWait wait;
        public PeoplePageHelper(IWebDriver driver) : base(driver)
        {
            _peoplePage = new PeoplePage(Driver);
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public PeoplePageHelper CreatePerson()
        {
            string personFullName = "Darko Darkovic";

            _peoplePage.ClickOnCreatePersonButton()
              .EnterPersonFullName(personFullName)
              .SelectTechnology()
              .SelectSeniority()
              .SelectTeam()
              .SubmitPerson();

            return this;
        }

        public PeoplePageHelper DeletePerson()
        {
            _peoplePage.ClickOnPersonFromTheList(1)
               .ClickOnTrashIconToRemoveSelectedPerson()
               .ClickOnDeleteButtonToConfirmDeletion();

            return this;
        }
    }
}
