using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyLib2.objects
{
    [Serializable]
    public class SurveyResult
    {
        #region --VARS--
        //Survey survey;
        private Survey survey;
        Tuple<Question, List<Answer>, List<Answer>> answerRow;
        List<Tuple<Question, List<Answer>, List<Answer>>> answersSet;
        double surveyTotalScore;
        double surveyMaxScore;
        SurveyUser user;
        #endregion

        #region --PROPS--
        

        public Survey Survey
        {
            get { return survey; }
            set { survey = value; }
        }

        public Question LastAnsweredQuestion { get; set; }

        public double Score
        {
            get { return surveyTotalScore; }
        }

        public double MaxScore
        {
            get {
                double score = 0;
                foreach (var question in survey.Questions)
                {
                    foreach (var ans in question.CorrectAnswers)
                    {
                        score += ans.AnswerScore;
                    }
                }
                return score;
                                     
            }
        }

        #endregion

        #region --CTOR--
        public SurveyResult(Survey survey, SurveyUser user)
        {
            this.survey = survey;
            this.user = user;
            answersSet = new List<Tuple<Question, List<Answer>, List<Answer>>>();
            surveyTotalScore = 0.0;
            LastAnsweredQuestion = survey.Questions[1];
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
            LastAnsweredQuestion = question;
        }

        public void AddAnswer(Question question, Answer givenAnswer)
        {
            AddAnswer(question, new List<Answer> { givenAnswer });
        }
        #endregion
    }
}
