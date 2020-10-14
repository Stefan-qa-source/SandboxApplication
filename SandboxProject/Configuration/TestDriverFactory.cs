using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox_project.Configuration
{
    public class TestDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return new WebDriverFactory().Create(
                new LocalDriverConfiguration(
                    TestConfiguration.Browser,
                    TestConfiguration.UseDriverDirectory,
                    TestConfiguration.DriverDirectoryEnvironmentVariableName,
                    TestConfiguration.DownloadFolderPath));
        }
    }
}
