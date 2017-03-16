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
	public abstract class AnswerBase:interfaces.ICRUDable
	{
		public AnswerBase()
		{
		}
		
		public bool IsCorrect {get;set;}
		
		public int Id { get; set; }
		
		public string Text {get;set;}

		#region ICRUDable implementation

		public int Save()
		{
			throw new NotImplementedException();
		}

		public int Remove()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
