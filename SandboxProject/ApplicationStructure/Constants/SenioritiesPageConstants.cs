using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxProject.ApplicationStructure.Constants
{
    public class SenioritiesPageConstants
    {
        public static readonly string CreateSeniorityButton = "//a[@href= '/create-seniority']/span";
        public static readonly string SeniorityTitleField = "seniority_title";
        public static readonly string SubmitButton = "//button[@type= 'submit']";
        public static readonly string RemoveButton = "//button[@aria-label= 'delete-button']";
        public static readonly string ConfirmDeletionButton = "//button[@class= 'btn btn-lg btn-danger ']";

    }
}
