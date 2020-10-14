using Sandbox_project.ApplicationStructure.Pages;
using Sandbox_project.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox_project.ApplicationStructure.Helpers
{
    public class LoginHelper
    {
        private readonly LoginPage _loginPage;

        public LoginHelper(LoginPage loginPage)
        {
            _loginPage = loginPage;
        }

        

        public HomePage LoginAsStandardUser(string name = null)
        {
            string password = null;
            string username = null;

            if (name == null)
            {
                username = UserStore.StandardUser.Username;
                password = UserStore.StandardUser.Password;
            }
            else
            {
                var user = UserStore.GetStandardUserByName(name);
                username = user.Username;
                password = user.Password;
            }
            return _loginPage.Login(username, password);
        }
    }
}
