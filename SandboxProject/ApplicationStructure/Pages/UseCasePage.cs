using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sandbox_project.ApplicationStructure.Base;
using SandboxProject.ApplicationStructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxProject.ApplicationStructure.Pages
{
    public class UseCasePage : PageObject
    {
        WebDriverWait wait;
        public UseCasePage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public UseCasePage ClickOnCreateUseCaseButton()
        {
            var createUseCaseButton = Driver.FindElement(By.XPath(UseCasesPageConstants.CreateUseCaseButton));
            createUseCaseButton.Click();
            return this;
        }

        public UseCasePage EnterUseCaseTitle(string title)
        {
            var useCaseTitleField = Driver.FindElement(By.Name(UseCasesPageConstants.UseCaseTitleField));
            useCaseTitleField.Clear();
            useCaseTitleField.SendKeys(title);
            return this;
        }

        public UseCasePage EnterUseCaseDescription(string description)
        {
            var useCaseDescriptionField = Driver.FindElement(By.Name(UseCasesPageConstants.UseCaseDescriptionField));
            useCaseDescriptionField.Clear();
            useCaseDescriptionField.SendKeys(description);
            return this;
        }

        public UseCasePage EnterUseCaseExpectedResult(string expectedResult)
        {
            var useCaseExpectedResultField = Driver.FindElement(By.Name(UseCasesPageConstants.UseCaseExpectedResultField));
            useCaseExpectedResultField.Clear();
            useCaseExpectedResultField.SendKeys(expectedResult);
            return this;
        }

        public UseCasePage EnterFirstStep(string text)
        {
            var firstStepField = Driver.FindElement(By.Name(UseCasesPageConstants.UseCaseFirstStepField));
            firstStepField.Clear();
            firstStepField.SendKeys(text);
            return this;
        }

        public UseCasePage AddNewStep()
        {
            var addStepButton = Driver.FindElement(By.XPath(UseCasesPageConstants.AddStepButton));
            addStepButton.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name(UseCasesPageConstants.UseCaseSecondStepField)));

            return this;
        }

        public UseCasePage EnterSecondStep(string text)
        {
            var secondStepField = Driver.FindElement(By.Name(UseCasesPageConstants.UseCaseSecondStepField));
            secondStepField.Clear();
            secondStepField.SendKeys(text);
            return this;
        }

        public UseCasePage SubmitUseCase()
        {
            var submitButton = Driver.FindElement(By.XPath(UseCasesPageConstants.SubmitButton));
            submitButton.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(UseCasesPageConstants.ListOfCreatedUseCases))); // lista kreiranih itema


            return this;
        }

        public UseCasePage ClickOnTrashIconToRemoveSelectedUseCase()
        {
            var trashIcon = Driver.FindElement(By.XPath(UseCasesPageConstants.RemoveButton));
            trashIcon.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(UseCasesPageConstants.ConfirmDeletionButton))); //   

            return this;
        }

        public UseCasePage ClickOnDeleteButtonToConfirmDeletion()
        {
            var trashIcon = Driver.FindElement(By.XPath(UseCasesPageConstants.ConfirmDeletionButton));
            trashIcon.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(UseCasesPageConstants.CreateUseCaseButton))); //   

            return this;
        }

        public UseCasePage ClickOnUseCaseFromTheList(int useCaseRow)
        {
            var element = Driver.FindElement(By.XPath("//div[@class= 'list-group mt-5']/a["+useCaseRow+"]"));
            element.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(UseCasesPageConstants.RemoveButton))); 


            return this;
        }

        private string GetTableCellText(string xpathLocation)
        {
            return Driver.FindElement(By.XPath(xpathLocation)).Text.Trim();
        }

        public string GetTitleOfUseCase(int useCaseRow)
        {
            return GetTableCellText(UseCasesPageConstants.ListOfCreatedUseCases + "/a["+useCaseRow+"]");
        }

        

        public int UseCasesCount
        {
            get
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                var element = Driver.FindElements(By.XPath("//a[contains(@href, '/use-cases/')]"));
                return element.Count;

            }
        }

        public int GetNumberOfCharactersForUseCaseTitleField()
        {
            var element = Driver.FindElement(By.Name(UseCasesPageConstants.UseCaseTitleField)).GetAttribute("value");
           return element.Length;
        }

        public int GetNumberOfCharactersForUseDescriptionField()
        {
            var element = Driver.FindElement(By.Name(UseCasesPageConstants.UseCaseDescriptionField)).Text;
            return element.Length;
        }

        public int GetNumberOfCharactersForUseCaseExpectedResultField()
        {
            var element = Driver.FindElement(By.Name(UseCasesPageConstants.UseCaseExpectedResultField)).GetAttribute("value");
            return element.Length;
        }

        public int GetNumberOfCharactersForUseCaseFirstStepField()
        {
            var element = Driver.FindElement(By.Name(UseCasesPageConstants.UseCaseFirstStepField)).GetAttribute("value");
            return element.Length;
        }
        public int GetNumberOfCharactersForUseCaseSecondStepField()
        {
            var element = Driver.FindElement(By.Name(UseCasesPageConstants.UseCaseSecondStepField)).GetAttribute("value");
            return element.Length;
        }

    }
}
