using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyLib2.objects
{
    public class SurveyEngine
    {
        #region --VARS--
        SurveyCollection surveyCollection;
        SurveyResult surveyResult;
        #endregion

        #region --PROPS--

        #endregion

        #region --CTOR--
        public SurveyEngine(SurveyCollection surveys)
        {
            surveyCollection = surveys;
        }
        #endregion

        #region --METHODS--
        public void StartSurvey(Survey survey)
        {
            this.surveyResult= new  SurveyResult(survey);
        }

        public Question Next()
        {
            //TODO Add Logic here
            throw new NotImplementedException();
        }
        #endregion
    }
}
