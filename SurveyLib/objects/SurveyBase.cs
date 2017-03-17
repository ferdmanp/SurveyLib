/*
 * Created by SharpDevelop.
 * User: SD
 * Date: 16.03.2017
 * Time: 9:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using SurveyLib.interfaces;
using System.Linq;


namespace SurveyLib.objects
{

    

	/// <summary>
	/// Description of Survey.
	/// </summary>
	public class SurveyBase :interfaces.ICRUDable
	{
		
		#region --Constructor--
		
		public SurveyBase(string title, IList<QuestionBase> questions)
		{
			if (questions == null)
				questions= new List<QuestionBase>();
			this.questions = questions;
			this.Title=(String.IsNullOrEmpty(title)?@"No title":title);
		}
		
		public SurveyBase(string title):this(title,null){}
		
		public SurveyBase():this(String.Empty,null) {}
		
		#endregion
		
		#region --Props--
		
		public String Title { get; set; }

        #endregion
		
		#region --Vars--
		
		private IList<QuestionBase> questions;
		
		#endregion
		
		#region --Methods--
		
		public int AddQuestion(QuestionBase question)
		{
			this.questions.Add(question);
			return question.Id;
		}
		
		public void AddQuestionsList(IList<QuestionBase> questionLIst)
		{
			this.questions=questionLIst;
				
		}
		
		public void RemoveQuestionById(int questionId)
		{
			QuestionBase question=GetQuestionById(questionId);
			if(question!=null)
			{
				int pos=questions.IndexOf(question);
				this.questions.RemoveAt(pos);
			}
		}
		
		public QuestionBase GetQuestionById(int questionId)
		{
			QuestionBase result= (from question in questions
								 where question.Id==questionId
								 select question).FirstOrDefault();
				
			return result;
		}
		
		public IList<QuestionBase> GetQuestions()
		{
			return this.questions;
		}
				
		#endregion

		#region ICRUDable implementation

		public virtual int Save(){
			throw new NotImplementedException();
		}
		

		public virtual int Remove(){
			throw new NotImplementedException();
		}


        #endregion

        public override string ToString()
        {
            return Title;
        }

        public string GetPrintable()
        {
            string message=$"=========={Title}==========="
                           +Environment.NewLine 
                ;

            foreach (var question in questions)
            {
                message += $"   {question.Id}) {question.Text}"
                            +Environment.NewLine;
                foreach (var answer in question.GetAnswers())
                {
                    message += $"        {answer.Id} {answer.Text} {Environment.NewLine}";                    
                }
            }

            return message;
        }
    }
}
