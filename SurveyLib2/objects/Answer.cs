using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyLib2.objects
{
    public class Answer:SurveyObjectBase
    {
        public Answer(string title, int id):base(title,id)
        {
            IsCorrect = false;
            AnswerScore = 0.0;

        }

        public Answer(int id) : this("No title", id) { }
        

        public bool IsCorrect { get; set; }

        public double AnswerScore { get; set;}
    }
}
