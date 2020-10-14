using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sandbox_project.ApplicationStructure.Base;
using SandboxProject.ApplicationStructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SandboxProject.ApplicationStructure.Pages
{
    public class PeoplePage : PageObject
    {
        WebDriverWait wait;
        public PeoplePage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public PeoplePage ClickOnCreatePersonButton()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(PeoplePageConstants.CreatePersonButton)));

            var personButton = Driver.FindElement(By.XPath(PeoplePageConstants.CreatePersonButton));
            personButton.Click();
            return this;
        }

        public PeoplePage EnterPersonFullName(string text)
        {
            var fullNameField = Driver.FindElement(By.Name(PeoplePageConstants.FullNameField));
            fullNameField.Clear();
            fullNameField.SendKeys(text);
            return this;
        }

        
        public PeoplePage SubmitPerson()
        {
            var submitButton = Driver.FindElement(By.XPath(PeoplePageConstants.SubmitButton));
            submitButton.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'People')]")));

            return this;

        }


        public PeoplePage SelectTechnology()
        {
            var technologiesDropDown = Driver.FindElement(By.XPath("//form/div[2]//div[@class= 'react-dropdown-select-dropdown-handle css-1jmeyq5-DropdownHandleComponent e1vudypg0']"));
            technologiesDropDown.Click();

            var choise = Driver.FindElement(By.XPath("//div[contains(@class, 'DropDown')]/span"));
            choise.Click();

            var technologiesDropDown2 = Driver.FindElement(By.XPath("//form/div[2]//div[contains(@class, 'select-dropdown-handle')]"));
            technologiesDropDown2.Click();                                                       

            return this;
        }

        public PeoplePage SelectSeniority()
        {
            var technologiesDropDown = Driver.FindElement(By.XPath("//form/div[3]//div[@class= 'react-dropdown-select-dropdown-handle css-1jmeyq5-DropdownHandleComponent e1vudypg0']"));
            technologiesDropDown.Click();

            var choise = Driver.FindElement(By.XPath("//div[contains(@class, 'DropDown')]/span"));
            choise.Click();

            return this;
        }

        public PeoplePage SelectTeam()
        {
            var technologiesDropDown = Driver.FindElement(By.XPath("//form/div[4]//div[@class= 'react-dropdown-select-dropdown-handle css-1jmeyq5-DropdownHandleComponent e1vudypg0']"));
            technologiesDropDown.Click();

            var choise = Driver.FindElement(By.XPath("//div[contains(@class, 'DropDown')]/span"));
            choise.Click();

            return this;
        }

        public string GetPersonFullName(int personRow)
        {
            var element = Driver.FindElement(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']/a[" + personRow + "]"));
            return element.Text;
        }

        public PeoplePage ClickOnPersonFromTheList(int personRow)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']/a[" + personRow + "]")));

            var element = Driver.FindElement(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']/a[" + personRow + "]"));
            element.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(PeoplePageConstants.RemoveButton)));

            return this;
        }

        public PeoplePage ClickOnTrashIconToRemoveSelectedPerson()
        {
            var trashIcon = Driver.FindElement(By.XPath(PeoplePageConstants.RemoveButton));
            trashIcon.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(PeoplePageConstants.ConfirmDeletionButton))); //   

            return this;
        }

        public PeoplePage ClickOnDeleteButtonToConfirmDeletion()
        {
            var trashIcon = Driver.FindElement(By.XPath(PeoplePageConstants.ConfirmDeletionButton));
            trashIcon.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(PeoplePageConstants.CreatePersonButton))); //   

            return this;
        }

        public int PeopleCount
        {
            get
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                var element = Driver.FindElements(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']//a[contains(@href, '/people')]"));
                return element.Count;

            }
        }
    }
}
