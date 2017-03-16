/*
 * Created by SharpDevelop.
 * User: SD
 * Date: 16.03.2017
 * Time: 9:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyLib.objects
{
	/// <summary>
	/// Description of Question.
	/// </summary>
	public class QuestionBase:interfaces.ICRUDable
	{
		private QuestionBase()
		{
		}


        #region --Constructor--
        public QuestionBase(int id, string text, IList<AnswerBase> answersList)
        {
            if (String.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException("text");
            this.answers = answersList ?? new List<AnswerBase>();
            this.Id = id;
            this.Text = text;
        }

        public QuestionBase(int id, string text) : this(id, text, null) { }
        #endregion

        public int AddAnswer(AnswerBase answer)
        {
            this.answers.Add(answer);
            return answer.Id;
        }

        public void AddAnswersList(List<AnswerBase> answerList)
        {
            answers = answerList;
        }

        public AnswerBase GetAnswerById(int answerId)
        {
            return (from ans in answers
                    where ans.Id == answerId
                    select ans).FirstOrDefault();

        }

        public void RemoveAnswerById(int answerId)
        {
            var answer = GetAnswerById(answerId);
            if (answer != null)
            {
                int pos = answers.IndexOf(answer);
                answers.RemoveAt(pos);
            }
        }

        public List<AnswerBase> GetAnswers()
        {            
            return (List<AnswerBase>)answers;
        }

        #region --Properties--

        

        //public List<AnswerBase> Answers
        //{
        //    get { return (List<AnswerBase>)answers; }
        //    set { answers = value; }
        //}


        #endregion

        private IList<AnswerBase> answers;
		
		public string Text { get; set; }
		
		public int Id { get; set; }		

		#region ICRUDable implementation

		public virtual int Save()
		{
			throw new NotImplementedException();
		}

		public virtual int Remove()
		{
			throw new NotImplementedException();
		}
		

		

		#endregion
	}
}
