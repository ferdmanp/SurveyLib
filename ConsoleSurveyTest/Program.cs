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
                    new SurveyUser("admin", "0000", UserRole.User | UserRole.Admin)
                );

            var survey = (Survey)collection.AddChild("Survey 1");
            var question = (Question)survey.AddChild("Question 1");
            question.AddChild("Asnwer 1");
            question.AddChild("Answer 2");
            ((Answer)question.AddChild("Answer 3")).IsCorrect = true;
            question = (Question)survey.AddChild("Question 2");
            question.AddChild("Answer 21");
            question.AddChild("Answer 22");
            ((Answer)question.AddChild("Answer 23")).IsCorrect = true;

            //survey.PrintSurveyData(Console.WriteLine);

            Random rndCorrect = new Random();
            Random rndScrore = new Random();

            var survey2 = (Survey)collection.AddChild("Survey2");
            //survey2.Questions.Add(1, "Question 2.1");
            //survey2.Questions.Add(2, "Question 2.2");
            //survey2.Questions.Add(3, "Question 2.3");
            //survey2.Questions.Add(4, "Question 2.4");
            //survey2.Questions.Add(5, "Question 2.5");
            //survey2.Questions[1].Answers.Add(1,"Ans")
            for (int i = 1; i <= 10; i++)
            {
                string title = $"Question 2.{i}";
                survey2.Questions.Add(i, title);
                for (int j = 1; j <= 5; j++)
                {
                    survey2.Questions[i].Answers.Add(j, $"Answer 2.{i}.{j}");                    
                }

                int randNum = rndCorrect.Next(1, 5);
                int range = 10;
                survey2.Questions[i].Answers[randNum].IsCorrect = true;                
                
                survey2.Questions[i].Answers[randNum].AnswerScore = rndScrore.NextDouble() * range;
            }

            //survey2.PrintSurveyData(Console.WriteLine);
            foreach (Survey item in collection.Surveys)
            {
                item.PrintSurveyData(Console.WriteLine);
            }



            Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}