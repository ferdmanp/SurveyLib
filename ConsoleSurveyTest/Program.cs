/*
 * Created by SharpDevelop.
 * User: SD
 * Date: 16.03.2017
 * Time: 9:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SurveyLib.classes;

namespace ConsoleSurveyTest
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

            // TODO: Implement Functionality Here

            SurveyBuilder builder = new SurveyBuilder();
            builder.CreateSurvey("Test", new SurveyLib.objects.SurveyUser());
            var question=builder.AddQuestion("Question 1");
            builder.AddAnswer(question, "Answer1", true);
            builder.AddAnswer(question, "Answer2", false);
            builder.AddAnswer(question, "Answer3", false);
            builder.AddAnswer(question, "Answer4", false);
            question = builder.AddQuestion("Question 2");
            builder.AddAnswer(question, "Answer 11", false);
            builder.AddAnswer(question, "Answer 12", false);
            builder.AddAnswer(question, "Answer 13", true);
            builder.AddAnswer(question, "Answer 14", false);
            builder.PrintResult(Console.WriteLine);

            Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}