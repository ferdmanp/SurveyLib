/*
 * Created by SharpDevelop.
 * User: SD
 * Date: 16.03.2017
 * Time: 9:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SurveyLib.interfaces
{
	/// <summary>
	/// Description of ICRUDable.
	/// </summary>
	internal interface ICRUDable
	{
		int Save();
		
		int Remove();		
				
		
	}
}
