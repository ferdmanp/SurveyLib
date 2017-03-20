using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyLib2.interfaces
{
    public interface IParentable
    {
        void AddChild(objects.SurveyObjectBase item);
    }
}
