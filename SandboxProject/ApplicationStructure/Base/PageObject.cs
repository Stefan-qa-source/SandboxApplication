using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox_project.ApplicationStructure.Base
{
    public abstract class PageObject
    {
        public IWebDriver Driver { get; }

        protected PageObject(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
