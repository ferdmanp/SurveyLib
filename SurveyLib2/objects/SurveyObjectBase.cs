﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyLib2.objects
{
    public class SurveyObjectBase
    {

        public SurveyObjectBase(string title, int id)
        {
            this.Title = title;
            this.Id = id;
        }

        
        public virtual string Title { get; set; }

        public virtual int Id { get; set; }

        public virtual SurveyObjectBase Parent { get; set; }        

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}";
        }
    }
}