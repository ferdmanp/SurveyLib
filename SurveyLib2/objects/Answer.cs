using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyLib2.objects
{
    public class Answer:SurveyObjectBase
    {
        public Answer(string title, int id):base(title,id){}

        public Answer(int id) : this("No title", id) { }
        

        public bool IsCorrect { get; set; }

        public float AnswerScore { get; set;}
    }
}
