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
		
		public QuestionBase(int id, string text, IEnumerable<AnswerBase> answersList)
		{
			if (String.IsNullOrWhiteSpace(text))
				throw new ArgumentNullException("text");
			this.answers=answersList??new List<AnswerBase>();			
			this.Id = id;
			this.Text = text;			
		}
		
		public QuestionBase(int id, string text):this(id,text,null){}
		
		
		
		private IEnumerable<AnswerBase> answers;
		
		public String Text { get; set; }
		
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
