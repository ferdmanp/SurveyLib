using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SurveyLib.objects;

namespace SurveyLib.classes
{
    public delegate void PrintMethodDelegate(string message);

    public class SurveyBuilder
    {

        #region --Vars--
        private SurveyBase survey;
        private int lastQuestionId;
        #endregion

        public SurveyBuilder()
        {
            lastQuestionId = 1;
        }

        public void CreateSurvey(string surveyTitle, SurveyUser userCreator)
        {
            survey = new SurveyBase(surveyTitle);
            
        }

        public QuestionBase AddQuestion(string questionText)
        {
            if (survey == null) throw new ArgumentException("Survey not inited! Call method CreateSurvey first!");

            QuestionBase question = new QuestionBase(lastQuestionId++, questionText);
            survey.AddQuestion(question);
            return question;           
        }

        public AnswerBase AddAnswer(QuestionBase question, string answerText, bool isCorrect)
        {
            int maxAnswerId = 0;            
            if (question.GetAnswers().Count > 0)
            {
                maxAnswerId = question.GetAnswers().Max(x => x.Id);
            }
            var answer = new AnswerBase(maxAnswerId + 1, answerText, isCorrect);
            question.AddAnswer(answer);
            return answer;
        }

        public SurveyBase GetResult()
        {
            return survey;
        }

        public void PrintResult(PrintMethodDelegate printMethod)
        {
            printMethod(survey.GetPrintable());
        }
    }
}
