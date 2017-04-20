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
        Question currentQuestion;
        int maxQuestionId;
        #endregion

        #region --PROPS--        

        public Question CurrentQuestion
        {
            get { return currentQuestion; }
            set { currentQuestion = value; }
        }

        public SurveyResult Result
        {
            get { return surveyResult; }
        }

        #endregion

        #region --CTOR--
        public SurveyEngine(SurveyCollection surveys)
        {
            surveyCollection = surveys;
        }
        #endregion

        #region --METHODS--
        public void StartSurvey(Survey survey, SurveyUser user)
        {
            this.surveyResult= new  SurveyResult(survey, user);
            currentQuestion = surveyResult.Survey.Questions[1];
            maxQuestionId = surveyResult.Survey.Questions.GetLastId();            
        }

        public void StartSurvey(int surveyId, SurveyUser user)
        {
            if (surveyId <= surveyCollection.Surveys.GetLastId())
            {
                Survey survey = surveyCollection.Surveys[surveyId];
                StartSurvey(survey, user);
            }
            else
            {
                throw new ArgumentOutOfRangeException("surveyId", $"Survey with id {surveyId} not found in collection");
            }

        }

        public Question NextQuestion()
        {
            CheckIfInited();
            if (!hasNextQuestion()) return null;
            currentQuestion = surveyResult.Survey.Questions[currentQuestion.Id + 1];
            return currentQuestion;

        }

        

        public void Answer(Answer answer)
        {
            CheckIfInited();
            surveyResult.AddAnswer(currentQuestion, answer);
        }

        public void Answer(List<Answer> answers)
        {
            CheckIfInited();
            surveyResult.AddAnswer(currentQuestion, answers);
        }

        private bool hasNextQuestion()
        {            
            return currentQuestion.Id < maxQuestionId ;
        }

        private void CheckIfInited()
        {
            if (surveyResult == null) throw new Exception($"Engine not initialized! Call StartSurvey method first");
        }
        #endregion
    }
}
