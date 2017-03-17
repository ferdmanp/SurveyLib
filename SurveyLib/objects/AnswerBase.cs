/*
 * Created by SharpDevelop.
 * User: SD
 * Date: 16.03.2017
 * Time: 9:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SurveyLib.objects
{
	/// <summary>
	/// Description of Answer.
	/// </summary>
	public class AnswerBase:interfaces.ICRUDable
	{
        #region --Constructor--

        public AnswerBase()
        {

        }

        public AnswerBase(int id, string text, bool isCorrect = false)
        {
            this.Id = id;
            if (String.IsNullOrWhiteSpace(text))
                throw new ArgumentException("text show not be empty!");
            this.Text = text;
            this.IsCorrect = isCorrect;
        }

        #endregion




        public bool IsCorrect {get;set;}
		
		public int Id { get; set; }
		
		public string Text {get;set;}

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
