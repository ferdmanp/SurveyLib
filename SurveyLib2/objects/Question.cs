using SurveyLib2.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyLib2.objects
{
    public class Question : SurveyObjectBase,IParentable
    {
        #region --Vars--
        
        #endregion

        #region --Props--
        public SurveyObjectCollection<Answer> Answers { get; set; }
        #endregion


        public Question(string title, int id):base(title,id){
            Answers = new SurveyObjectCollection<Answer>();
        }

        #region --IParentable--
        public void AddChild(SurveyObjectBase item)
        {
            var child = item as Answer;
            if (item != null)
            {
                Answers.Add((Answer)item);
            }
        } 
        #endregion
    }
}
