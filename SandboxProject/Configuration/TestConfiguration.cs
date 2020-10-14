using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Sandbox_project.Configuration
{
    public static class TestConfiguration
    {
        public static string Browser { get; set; }

        public static bool UseDriverDirectory { get; set; }

        public static string DriverDirectoryEnvironmentVariableName { get; set; }

        public static string ApplicationUrl { get; set; }

        public static string DownloadFolderPath { get; set; }

        static TestConfiguration()
        {
            var reader = new AppSettingsReader();

            Browser = (string)reader.GetValue("Browser", typeof(string));
            UseDriverDirectory = (bool)reader.GetValue("Browser.UseDriverDirectory", typeof(bool));
            DriverDirectoryEnvironmentVariableName = (string)reader.GetValue("Browser.DriverDirectoryEnvironmentVariableName", typeof(string));
            ApplicationUrl = (string)reader.GetValue("ApplicationUrl", typeof(string));
            DownloadFolderPath = (string)reader.GetValue("DownloadFolderPath", typeof(string));
        }
    }
}