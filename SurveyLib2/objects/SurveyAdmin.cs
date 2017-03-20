using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyLib2.objects
{
    public class SurveyAdmin
    {
        #region --VARS--
        SurveyUser currentUser;
        #endregion

        #region --PROPS--

        #endregion

        #region --CTOR--
        private SurveyAdmin(){}

        public SurveyAdmin(SurveyUser user)
        {
            if (!user.Role.HasFlag(UserRole.Admin))
                throw new Exception($"User {user.Name} has no admin privileges");
        }
        #endregion

        #region --METHODS--
        public void Add<T>(SurveyObjectBase parent) where T : SurveyObjectBase
        {

        }
        #endregion
    }
}
