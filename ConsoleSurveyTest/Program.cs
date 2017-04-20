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
using System.Collections.Generic;
using System.Linq;

namespace ConsoleSurveyTest
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

            SurveyUser user = new SurveyUser("admin", "0000", UserRole.User | UserRole.Admin);

            SurveyCollection collection = new SurveyCollection(
                    user
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

            RunSurvey(collection, survey2.Id ,user);


            Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}

        private static void RunSurvey(SurveyCollection collection, int surveyId, SurveyUser user)
        {

            
            SurveyEngine engine = new SurveyEngine(collection);
            engine.StartSurvey(surveyId, user);
            Question currentQuestion = engine.CurrentQuestion;
            
            do
            {
                Console.WriteLine(currentQuestion.Title);
                foreach (var answer in currentQuestion.Answers)
                {
                    Console.WriteLine($"___{answer.Id}) {answer.Title}");
                }

                Console.WriteLine($"Enter your selection");
                string[] result = Console.ReadLine().Split(',');
                List<Answer> selection = new List<Answer>();
                for (int i = 0; i < result.Length; i++)
                {
                    int id=Int32.Parse(result[i]);
                    if (currentQuestion.Answers.Max(x => x.Id) >= id)
                    {
                        selection.Add(currentQuestion.Answers[id]);
                    }
                }

                engine.Answer(selection);
                
                currentQuestion = engine.NextQuestion();
            } while (currentQuestion!=null);

            Console.WriteLine($"Your score is {engine.Result.Score} from {engine.Result.MaxScore}");
        }
    }

    public static class Extensions
    {
        public static bool IsEqual(this List<int> src, List<int> comp)
        {
            bool result = false;

            result = (src.Count == comp.Count && !src.Except(comp).Any());
                            
            return result;
        }
    }
}