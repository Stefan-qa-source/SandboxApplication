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

namespace SandboxProject.ApplicationStructure.Pages
{
    public class SenioritiesPage : PageObject
    {
        WebDriverWait wait;
        public SenioritiesPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public SenioritiesPage ClickOnCreateSeniorityButton()
        {
            var technologyButton = Driver.FindElement(By.XPath(SenioritiesPageConstants.CreateSeniorityButton));
            technologyButton.Click();
            return this;
        }

        public SenioritiesPage EnterSeniorityTitle(string text)
        {
            var technologyField = Driver.FindElement(By.Name(SenioritiesPageConstants.SeniorityTitleField));
            technologyField.Clear();
            technologyField.SendKeys(text);
            return this;
        }

        public SenioritiesPage SubmitSeniority()
        {
            var submitButton = Driver.FindElement(By.XPath(SenioritiesPageConstants.SubmitButton));
            submitButton.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'Seniorities')]")));

            return this;

        }

        public SenioritiesPage ClickOnSeniorityFromTheList(int seniorityRow)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']/a[" + seniorityRow + "]")));
            
            var element = Driver.FindElement(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']/a[" + seniorityRow + "]"));
            element.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SenioritiesPageConstants.RemoveButton)));

            return this;
        }

        public SenioritiesPage ClickOnTrashIconToRemoveSelectedSeniority()
        {
            var trashIcon = Driver.FindElement(By.XPath(SenioritiesPageConstants.RemoveButton));
            trashIcon.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SenioritiesPageConstants.ConfirmDeletionButton))); //   

            return this;
        }
        public SenioritiesPage ClickOnSubmitButton()
        {
            var submitButton = Driver.FindElement(By.XPath(SenioritiesPageConstants.SubmitButton));
            submitButton.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class= 'invalid-feedback']"))); //   

            return this;

            //div[@class= 'invalid-feedback']
        }

        public SenioritiesPage ClickOnDeleteButtonToConfirmDeletion()
        {
            var trashIcon = Driver.FindElement(By.XPath(SenioritiesPageConstants.ConfirmDeletionButton));
            trashIcon.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SenioritiesPageConstants.CreateSeniorityButton))); //   

            return this;
        }

        public SenioritiesPage ClickOnLeftArrowToRevertOnSenioritiessSection()
        {
            var trashIcon = Driver.FindElement(By.XPath("//a[@href= '/seniorities']"));
            trashIcon.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'Seniorities')]"))); //   

            return this;


        }
            private string GetTableCellText(string xpathLocation)
        {
            return Driver.FindElement(By.XPath(xpathLocation)).Text.Trim();
        }

        public string GetTitleOfSeniority(int seniorityRoww)
        {
            return GetTableCellText("//div[@class= 'card-profile shadow ml-1 mr-1']/a[" + seniorityRoww + "]");
        }

        public int SenioritiesCount
        {
            get
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                var element = Driver.FindElements(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']//a[contains(@href, '/seniorities')]"));
                return element.Count;

            }
        }

        public bool CheckIfValidationMessageIsDisplayed()
        {
            var validationMessage = Driver.FindElement(By.XPath("//div[@class= 'invalid-feedback']"));
            return validationMessage.Displayed;
        }

        public string GetValidationMessageForSameNameSeniority()
        {
            return GetTableCellText("//div[@class= 'invalid-feedback']");
        }

    }
}
