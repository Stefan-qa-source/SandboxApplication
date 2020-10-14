using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox_project.Configuration
{
    public class ApplicationUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public ApplicationUser(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
