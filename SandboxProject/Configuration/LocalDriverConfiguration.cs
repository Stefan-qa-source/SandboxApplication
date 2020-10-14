using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox_project.Configuration
{
    public class LocalDriverConfiguration
    {
        public string Browser { get; }

        public bool UseDriverDirectory { get; }

        public string DriverDirectoryEnvironmentVariableName { get; }

        public string DownloadFolderPath { get; }

        public LocalDriverConfiguration(string browser, bool useDriverDirectory, string driverDirectoryEnvironmentVariableName, string downloadFolderPath)
        {
            Browser = browser;
            UseDriverDirectory = useDriverDirectory;
            DriverDirectoryEnvironmentVariableName = driverDirectoryEnvironmentVariableName;
            DownloadFolderPath = downloadFolderPath;
        }
    }
}
