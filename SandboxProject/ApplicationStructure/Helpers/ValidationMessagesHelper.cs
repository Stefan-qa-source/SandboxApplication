using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sandbox_project.ApplicationStructure.Base;
using SandboxProject.ApplicationStructure.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxProject.ApplicationStructure.Helpers
{
    class ValidationMessagesHelper : PageObject
    {
        private UseCasePage _useCasePage;
        WebDriverWait wait;
        public ValidationMessagesHelper(IWebDriver driver) : base(driver)
        {
            _useCasePage = new UseCasePage(Driver);

            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }


        private string GetTableCellText(string xpathLocation)
        {
            return Driver.FindElement(By.XPath(xpathLocation)).Text.Trim();
        }

        public bool CheckIfValidationMessageIsDisplayed()
        {
            var validationMessage = Driver.FindElement(By.XPath("//div[@class= 'invalid-feedback']"));
            return validationMessage.Displayed;
        }

        public string GetValidationMessage()
        {
            return GetTableCellText("//div[@class= 'invalid-feedback']");
        }
    }
}
