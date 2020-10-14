using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sandbox_project.ApplicationStructure.Base;
using SandboxProject.ApplicationStructure.Constants;
using System;

namespace SandboxProject.ApplicationStructure.Pages
{
    public class TechnologiesPage : PageObject
    {
        WebDriverWait wait;
        public TechnologiesPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public TechnologiesPage ClickOnCreateTechnologyButton()
        {
            var technologyButton = Driver.FindElement(By.XPath(TechnologiesPageConstants.CreateTechnologyButton));
            technologyButton.Click();
            return this;
        }

        public TechnologiesPage EnterTechnologyTitle(string text)
        {
            var technologyField = Driver.FindElement(By.Name(TechnologiesPageConstants.TechnologyTitleField));
            technologyField.Clear();
            technologyField.SendKeys(text);
            return this;
        }

        public TechnologiesPage SubmitTechnology()
        {
            var submitButton = Driver.FindElement(By.XPath(TechnologiesPageConstants.SubmitButton));
            submitButton.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'Technologies')]")));

            return this;

        }

        public TechnologiesPage ClickOnTechnologyFromTheList(int technologyRow)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']/a[" + technologyRow + "]")));

            var element = Driver.FindElement(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']/a[" + technologyRow + "]"));
            element.Click();

            //var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(TechnologiesPageConstants.RemoveButton)));

            return this;
        }

        public TechnologiesPage ClickOnTrashIconToRemoveSelectedTechnology()
        {
            var trashIcon = Driver.FindElement(By.XPath(TechnologiesPageConstants.RemoveButton));
            trashIcon.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(TechnologiesPageConstants.ConfirmDeletionButton))); //   

            return this;
        }

        public TechnologiesPage ClickOnDeleteButtonToConfirmDeletion()
        {
            var trashIcon = Driver.FindElement(By.XPath(TechnologiesPageConstants.ConfirmDeletionButton));
            trashIcon.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(TechnologiesPageConstants.CreateTechnologyButton))); //   

            return this;
        }

        public TechnologiesPage ClickOnSubmitButton()
        {
            var submitButton = Driver.FindElement(By.XPath(TechnologiesPageConstants.SubmitButton));
            submitButton.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class= 'invalid-feedback']"))); //

            return this;
        }

        private string GetTableCellText(string xpathLocation)
        {
            return Driver.FindElement(By.XPath(xpathLocation)).Text.Trim();
        }

        public string GetTitleOfTechnology(int technologyRow)
        {
            return GetTableCellText("//div[@class= 'card-profile shadow ml-1 mr-1']/a["+technologyRow+"]");
        }

        public bool CheckIfTitleOfTechnologyIsDisplayed(int technologyRow, string title)
        {
            var element = Driver.FindElement(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']/a[" + technologyRow + "]")).Text;

            if(element != title)
            {
                return false;
            }
            return true;
        }

        public int TechnologiesCount
        {
            get
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                var element = Driver.FindElements(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']//a[contains(@href, '/technologies')]"));
                return element.Count;

            }
        }
    }
}
