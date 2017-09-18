using System;
using SurveyLib2.interfaces;

namespace SurveyLib2.objects
{
    public class Survey:SurveyObjectBase, IParentable
    {
        #region --VARS--

        #endregion

        #region --PROPS--
        public SurveyObjectCollection<Question> Questions { get; set;}
        public SurveyUser UserCreator { get; set; }

       
        #endregion

        #region --CTOR--
        public Survey(string title, int id, SurveyUser creator):base(title,id)
        {
            Questions = new SurveyObjectCollection<Question>();
            UserCreator = creator;
        }

        public Survey(int id):this("No title",id,new SurveyUser("No name","nop",UserRole.Admin)){}

        #endregion

        #region --METHODS--

        #endregion

        #region --IParentable--
        public void AddChild(SurveyObjectBase item)
        {
            var child = item as Question;
            if (item != null)
            {
                Questions.Add((Question)item);
                item.Parent = this;
            }
            else
                throw new Exception($"Item with type {item.GetType().Name} cannot be child of type Survey");
            
        }

        public SurveyObjectBase AddChild(string title)
        {
            var id = Questions.GetLastId()+1;
            Question question = new Question(title, id);
            this.AddChild(question);
            return question;
        }


        #endregion

        public void PrintSurveyData(PrintMethod printMethod)
        {

            printMethod($"**************({this.Id})*{this.Title}*************");
            printMethod($"*             Author: {this.UserCreator.Name}     *");
            printMethod($"===================================================");

            foreach (var question in Questions)
            {
                printMethod($"   ({question.Id})...{question.Title}");
                foreach (var answer in question.Answers)
                {
                    printMethod($"      ({answer.Id})...{answer.Title}...{answer.IsCorrect.ToString()}....{answer.AnswerScore}");
                }
            }
        }
    }
}
