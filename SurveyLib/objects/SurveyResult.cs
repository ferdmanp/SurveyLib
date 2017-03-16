using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyLib.objects
{
    public class SurveyResult : interfaces.ICRUDable
    {

        SurveyUser user;
        DateTime dateSurveyStart;
        DateTime dateSurveyEnd;

        public int Remove()
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }
    }
}
