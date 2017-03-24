/*
 * Created by SharpDevelop.
 * User: SD
 * Date: 16.03.2017
 * Time: 9:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SurveyLib2.objects;

namespace ConsoleSurveyTest
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

            SurveyCollection collection = new SurveyCollection(
                    new SurveyUser("admin", "0000", UserRole.User | UserRole.User)
                );

            collection.AddChild("Survey 1");

                


            Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}