using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxProject.ApplicationStructure.Constants
{
    public class TechnologiesPageConstants
    {
        public static readonly string CreateTechnologyButton = "//a[@href= '/create-technology']/span";
        public static readonly string TechnologyTitleField = "technology_title";
        public static readonly string SubmitButton = "//button[@type= 'submit']";
        public static readonly string RemoveButton = "//button[@aria-label= 'delete-button']";
        public static readonly string ConfirmDeletionButton = "//button[@class= 'btn btn-lg btn-danger ']";


    }
}
