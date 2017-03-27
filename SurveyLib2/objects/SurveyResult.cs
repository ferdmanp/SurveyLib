using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyLib2.objects
{
    public class SurveyResult
    {
        #region --VARS--
        Survey survey;
        Tuple<Question, List<Answer>, List<Answer>> answerRow;
        List<Tuple<Question, List<Answer>, List<Answer>>> answersSet;
        double surveyTotalScore;
        public Question lastQuestion;
        #endregion

        #region --PROPS--

        #endregion

        #region --CTOR--
        public SurveyResult(Survey survey)
        {
            this.survey = survey;
            answersSet = new List<Tuple<Question, List<Answer>, List<Answer>>>();
            surveyTotalScore = 0.0;
            lastQuestion = survey.Questions[1];
        }

        private SurveyResult()
        {

        }
        #endregion

        #region --METHODS--
        public void AddAnswer(Question question, List<Answer> givenAnswer)
        {
            answerRow = new Tuple<Question, List<Answer>, List<Answer>>(
                    question,
                    givenAnswer,
                    question.CorrectAnswers
                );
            answersSet.Add(answerRow);

            var answeredScore = (from given in givenAnswer
                            join correct in question.CorrectAnswers on given.Id equals correct.Id into answrs
                            from ans in answrs.DefaultIfEmpty(new Answer(string.Empty, -1) { AnswerScore = 0 })
                            select new { score = ans.AnswerScore }).Sum(x => x.score);
                         ;
            surveyTotalScore += answeredScore;
            lastQuestion = question;
        }

        public void AddAnswer(Question question, Answer givenAnswer)
        {
            AddAnswer(question, new List<Answer> { givenAnswer });
        }
        #endregion
    }
}
