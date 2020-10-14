using OpenQA.Selenium;
using Sandbox_project.ApplicationStructure.Helpers;
using Sandbox_project.ApplicationStructure.Pages;
using Sandbox_project.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox_project.Scenarios
{
    public class BaseScenario : IDisposable
    {
        protected IWebDriver Driver;
        protected LoginHelper LoginHelper { get; }

        public BaseScenario()
        {

            Driver = new TestDriverFactory().CreateDriver();
            Driver.Navigate().GoToUrl(TestConfiguration.ApplicationUrl);
            Driver.Manage().Window.Maximize();

            LoginHelper = new LoginHelper(new LoginPage(Driver));


        }

        public void Dispose()
        {
            Driver?.Close();
            Driver?.Dispose();
        }
    }
}
