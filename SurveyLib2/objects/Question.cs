﻿using SurveyLib2.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyLib2.objects
{
    public class Question : SurveyObjectBase,IParentable
    {
        #region --Vars--
        
        #endregion

        #region --Props--
        public SurveyObjectCollection<Answer> Answers { get; set; }
        public List<Answer> CorrectAnswers
        {
            get
            {
                return Answers
                    .Where(x => x.IsCorrect)
                    .ToList();
            }            
        }

        public List<int> CorrectAnswersIds
        {
            get
            {
                return (from ans in Answers
                        where ans.IsCorrect
                        select ans.Id).ToList();
            }
        }

        public bool CanHaveMultipleAnswers()
        {
            return CorrectAnswers.Count > 1;
        }
        
        #endregion


        public Question(string title, int id):base(title,id){
            Answers = new SurveyObjectCollection<Answer>();
        }

        public Question(int id):this("No title",id)
        {

        }

        #region --IParentable--
        public void AddChild(SurveyObjectBase item)
        {
            var child = item as Answer;
            if (item != null)
            {
                Answers.Add((Answer)item);
                item.Parent = this;
            }
            else
                throw new Exception($"Item with type {item.GetType().Name} cannot be child of type Question");
        }

        public SurveyObjectBase AddChild(string title)
        {
            var id = Answers.GetLastId() + 1;
            Answer answer = new Answer(title, id);
            this.AddChild(answer);
            return answer;
        }
        #endregion
    }
}
