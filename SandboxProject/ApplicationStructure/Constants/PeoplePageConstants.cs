using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxProject.ApplicationStructure.Constants
{
    public class PeoplePageConstants
    {
        public static readonly string CreatePersonButton = "//a[@href= '/create-person']/span";
        public static readonly string FullNameField = "people_name";
        public static readonly string SelectTechnology = "//input[@placeholder= 'Select technologies']";
        public static readonly string SelectSeniority = "//input[@placeholder= 'Select seniority']";
        public static readonly string SelectTeam = "//input[@placeholder= 'Select team']";
        public static readonly string SubmitButton = "//button[@type= 'submit']";
        public static readonly string RemoveButton = "//button[@aria-label= 'delete-button']";
        public static readonly string ConfirmDeletionButton = "//button[@class= 'btn btn-lg btn-danger ']";

    }
}
