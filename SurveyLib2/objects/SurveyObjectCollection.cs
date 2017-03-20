using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyLib2.objects
{
    public class SurveyObjectCollection<T> where T:SurveyObjectBase
    {
        #region --VARS--

        private List<T> objects;

        #endregion

        #region --INDEXERS--
        public T this[int id]
        {
            get
            {
                return objects
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
            }            
        }

        #endregion

        #region --CTOR--
        public SurveyObjectCollection()
        {
            this.objects = new List<T>();
        }

        public SurveyObjectCollection(List<T> objects)
        {
            this.objects.AddRange(objects);
        }
        #endregion

        #region --METHODS--
        public void Add(T item)
        {
            objects.Add(item);
        }

        public void Delete(int id)
        {
            int pos = objects.IndexOf(this[id]);
            if (pos >-1)
            {
                objects.RemoveAt(pos);
            }
        }

        public void Delete(T item)
        {
            objects.Remove(item);
        }

        public void Clear()
        {
            objects.Clear();
        }

        public int GetLastId()
        {
            return objects
                   .Max(x => x.Id);            
        }
        #endregion



    }
}
