using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sandbox_project.ApplicationStructure.Base;
using Sandbox_project.ApplicationStructure.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sandbox_project.ApplicationStructure.Pages
{
    public class LoginPage : PageObject
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement Username => Driver.FindElement(By.Name(LoginPageConstants.EmailAddress));

        private IWebElement Password => Driver.FindElement(By.Name(LoginPageConstants.Password));

        private IWebElement SubmitButton => Driver.FindElement(By.XPath(LoginPageConstants.SubmitButton));

        public HomePage Login(string username = "", string password = "")
        {
            Username.SendKeys(username);
            Username.Click();
            Password.Clear();
            Password.SendKeys(password);

            SubmitButton.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[@class='card-text text-center pb-3']/small")));
            
            return new HomePage(Driver);
        }
    }
}
