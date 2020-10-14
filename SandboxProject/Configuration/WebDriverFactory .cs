using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox_project.Configuration
{
    public class WebDriverFactory
    {
        private IWebDriver _driver;

        
        // This method will create a local driver, as it takes the LocalDriver configuration object

        public IWebDriver Create(LocalDriverConfiguration configuration)
        {
            // A simple switch statement to determine which driver/service to create:
            switch (configuration.Browser.ToLower())
            {
                case "chrome":
                    _driver = CreateChromeDriver(configuration);
                    break;

                case "internet explorer":
                    _driver = CreateInternetExplorerDriver(configuration);
                    break;

                case "firefox":
                    _driver = CreateFirefoxDriver(configuration);
                    break;

                case "edge":
                    _driver = CreateEdgeDriver(configuration);
                    break;

                // If a string isn't matched, it will default to IE Driver:
                default:
                    _driver = CreateInternetExplorerDriver(configuration);
                    break;
            }

            //Return the driver instance to the calling class.
            return _driver;
        }

        private IWebDriver CreateChromeDriver(LocalDriverConfiguration configuration)
        {
            IWebDriver webDriver;
            ChromeOptions options = CreateChromeOptions(configuration);
            if (configuration.UseDriverDirectory)
            {
                webDriver = new ChromeDriver(
                    Environment.GetEnvironmentVariable(configuration.DriverDirectoryEnvironmentVariableName),
                    options);
            }
            else
            {
                webDriver = new ChromeDriver();
            }
            return webDriver;
        }

        private ChromeOptions CreateChromeOptions(LocalDriverConfiguration configuration)
        {
            string downloadFolderPath = configuration.DownloadFolderPath;

            var options = new ChromeOptions();



            options.AddArgument("--headless"); // this can be used for running tests in headless mode
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage"); // Write shared memory files into /tmp instead of /dev/shm. 


            options.AcceptInsecureCertificates = true;


            options.AddUserProfilePreference("download.default_directory", downloadFolderPath);
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("disable-popup-blocking", "true");

            return options;
        }

        private IWebDriver CreateFirefoxDriver(LocalDriverConfiguration configuration)
        {
            IWebDriver webDriver;
            var optionsFirefox = new FirefoxOptions();
            if (configuration.UseDriverDirectory)
            {
                webDriver = new FirefoxDriver(Environment.GetEnvironmentVariable(configuration.DriverDirectoryEnvironmentVariableName), optionsFirefox);
            }
            else
            {
                webDriver = new FirefoxDriver(optionsFirefox);
            }
            return webDriver;
        }

        private IWebDriver CreateInternetExplorerDriver(LocalDriverConfiguration configuration)
        {
            IWebDriver webDriver;
            var optionsExplorer = new InternetExplorerOptions { EnableNativeEvents = false, EnsureCleanSession = true };
            if (configuration.UseDriverDirectory)
            {
                webDriver = new InternetExplorerDriver(Environment.GetEnvironmentVariable(configuration.DriverDirectoryEnvironmentVariableName), optionsExplorer);
            }
            else
            {
                webDriver = new InternetExplorerDriver(optionsExplorer);
            }
            return webDriver;
        }

        private IWebDriver CreateEdgeDriver(LocalDriverConfiguration configuration)
        {
            IWebDriver webDriver;
            if (configuration.UseDriverDirectory)
            {
                webDriver = new EdgeDriver(Environment.GetEnvironmentVariable(configuration.DriverDirectoryEnvironmentVariableName));
            }
            else
            {
                webDriver = new EdgeDriver();
            }
            return webDriver;
        }

    }
}
