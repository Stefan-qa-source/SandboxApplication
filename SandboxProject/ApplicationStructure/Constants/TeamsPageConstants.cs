using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxProject.ApplicationStructure.Constants
{
    public class TeamsPageConstants
    {
        public static readonly string SubmitButton = "//button[@type= 'submit']";
        public static readonly string  CreateTeamButton = "//a[@href= '/create-role']/span";
        public static readonly string RemoveButton = "//button[@aria-label= 'delete-button']";
        public static readonly string TeamTitleField = "role_name";
        public static readonly string ConfirmDeletionButton = "//button[@class= 'btn btn-lg btn-danger ']";
    }
}
