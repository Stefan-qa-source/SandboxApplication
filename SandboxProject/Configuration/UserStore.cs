using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Sandbox_project.Configuration
{
    public static class UserStore
    {

        public static ApplicationUser StandardUser { get; set; }



        public static string UserStefan = "Stefan";


        static UserStore()
        {
            var reader = new AppSettingsReader();


            var stefan = (string)reader.GetValue("User.StandardUser." + UserStefan, typeof(string));
            StandardUser = new ApplicationUser(stefan.Split(':')[0], stefan.Split(':')[1]);

        }


        public static ApplicationUser GetStandardUserByName(string name)
        {
            var reader = new AppSettingsReader();

            var user = (string)reader.GetValue("User.StandardUser." + name, typeof(string));
            return new ApplicationUser(user.Split(':')[0], user.Split(':')[1]); ;
        }
    }
}
