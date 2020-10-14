using OpenQA.Selenium;
using Sandbox_project.ApplicationStructure.Base;
using Sandbox_project.ApplicationStructure.Constants;
using Sandbox_project.ApplicationStructure.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox_project.ApplicationStructure.PartialPages
{
    public class MainNavigation : PageObject
    {
        public MainNavigation(IWebDriver driver) : base(driver)
        {
        }

            public DashboardPage NavigateToDashboardPage()
            {
                Driver.FindElement(By.XPath(MainNavigationConstants.SandboxTab)).Click();

                return new DashboardPage(Driver);
            }
         
        
    }
}
