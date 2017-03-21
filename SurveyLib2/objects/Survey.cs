using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyLib2.interfaces;

namespace SurveyLib2.objects
{
    public class Survey:SurveyObjectBase, IParentable
    {
        #region --VARS--

        #endregion

        #region --PROPS--
        public SurveyObjectCollection<Question> Questions { get; set;}

       
        #endregion

        #region --CTOR--
        public Survey(string title, int id):base(title,id)
        {
            Questions = new SurveyObjectCollection<Question>();
        }

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

        public void AddChild(string title)
        {
            var id = Questions.GetLastId()+1;
            Question question = new Question(title, id);
            this.AddChild(question);
        }

        //public SurveyObjectCollection<SurveyObjectBase> GetChildren()
        //{
        //    return (SurveyObjectCollection<SurveyObjectBase>)Questions;
        //}
        #endregion


    }
}
