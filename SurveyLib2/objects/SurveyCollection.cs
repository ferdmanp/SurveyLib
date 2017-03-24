using SurveyLib2.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyLib2.objects
{
    public class SurveyCollection:IParentable
    {
        #region --VARS--
        SurveyUser currentUser;
        bool canView = true;
        bool canAdd = false;

        #endregion

        #region --PROPS--
        public SurveyObjectCollection<Survey> Surveys { get; set; }
        #endregion

        #region --CTOR--
        private SurveyCollection(){}

        public SurveyCollection(SurveyUser user)
        {
            currentUser = user;
            if (user.Role.HasFlag(UserRole.Admin))
                canAdd = true;
            Surveys = new SurveyObjectCollection<Survey>();
        }
        #endregion

        #region --METHODS--
        /// <summary>
        /// Add object to parent item
        /// </summary>
        /// <remarks>
        /// Doesn't check Id !!!!
        /// </remarks>
        /// <typeparam name="T">SurveyObjectBase</typeparam>
        /// <param name="item">Item to add</param>
        /// <param name="parent">Container item</param>
        /// <returns></returns>
        public T Add<T>(SurveyObjectBase item, IParentable parent) where T : SurveyObjectBase
        {
                     
            parent.AddChild(item);
            return (T)item;
        }

        public T Add<T>(string title, IParentable parent) where T : SurveyObjectBase
        {
            int id = 0;
            object instance = new object();

            if (typeof(T) == typeof(Survey))
            {
                id = Surveys.GetLastId()+1;
                instance = Activator.CreateInstance(typeof(Survey), new object[] { id, title }) as Survey;                
                parent.AddChild((Survey)instance);
            }
            else
                if (typeof(T) == typeof(Question))
            {
                var p = parent as Survey;
                if (p != null)
                {
                    id = p.Questions.GetLastId()+1;
                    instance = (Question)Activator.CreateInstance(typeof(Question), new object[] { id, title });
                    parent.AddChild((Question)instance);
                }
            }
            else
            {
                var p = parent as Question;
                if (p != null)
                {
                    id = p.Answers.GetLastId()+1;
                    instance = (Answer)Activator.CreateInstance(typeof(Answer), new object[] { id, title });
                    parent.AddChild((Answer)instance);
                }
            }

            return (T)instance;
        }

        public void AddChild(SurveyObjectBase item)
        {
                Surveys.Add((Survey)item);
                item.Parent = this;
            ((Survey)item).UserCreator = currentUser;     
            
        }

        public SurveyObjectBase AddChild(string title)
        {
            var id = Surveys.GetLastId() + 1;
            Survey survey = new Survey(title, id,currentUser);
            this.AddChild(survey);
            return survey;
        }

        void CheckIfCanAdd()
        {
            if (!canAdd)
                throw new Exception($"User {currentUser.Name} does not have admin privileges!");
        }
        #endregion
    }
}
