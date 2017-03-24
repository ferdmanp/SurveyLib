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

            var survey= (Survey)collection.AddChild("Survey 1");
            var question= (Question)survey.AddChild("Question 1");
            question.AddChild("Asnwer 1");
            question.AddChild("Answer 2");
            ((Answer)question.AddChild("Answer 3")).IsCorrect = true;
            question = (Question)survey.AddChild("Question 2");
            question.AddChild("Answer 21");
            question.AddChild("Answer 22");
            ((Answer)question.AddChild("Answer 23")).IsCorrect = true;

            survey.PrintSurveyData(Console.WriteLine);


            var survey2 = (Survey)collection.AddChild("Survey2");
            //survey2.Questions[1]=new Question()


            Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}