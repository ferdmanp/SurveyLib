using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyLib2.objects
{
    
    public enum UserRole { Admin, User};

    public class SurveyUser
    {
        #region --VARS--

        #endregion

        #region --PROPS--
        public string Name { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        #endregion

        #region --CTOR--
        public SurveyUser(string name, string password, UserRole userRole)
        {
            Name = name;
            Password = password;
            Role = userRole;
        }
        #endregion

        #region --METHODS--

        #endregion
    }
}
