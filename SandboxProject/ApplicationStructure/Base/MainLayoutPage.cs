using OpenQA.Selenium;
using Sandbox_project.ApplicationStructure.PartialPages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox_project.ApplicationStructure.Base
{
    public abstract class MainLayoutPage : PageObject
    {
        protected MainLayoutPage(IWebDriver driver) : base(driver)
        {
        }

        public MainNavigation MainNavigation => new MainNavigation(Driver);

    }
}
