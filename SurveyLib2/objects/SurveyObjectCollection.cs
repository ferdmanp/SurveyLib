using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SurveyLib2.objects
{
    public class SurveyObjectCollection<T>
        : IEnumerable<T>
        where T : SurveyObjectBase
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
            set
            {
                T obj = this[id];
                if (obj == null)
                {
                    obj = (T)Activator.CreateInstance(typeof(T), new int[] { id });
                }
                obj = value;
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

        public void Add(string title)
        {
            int id = GetLastId() + 1;
            T obj = (T)Activator.CreateInstance(typeof(T), new object[] {  title,id });
            this.Add(obj);
        }

        public void Add(int id, string title)
        {
            T obj = (T)Activator.CreateInstance(typeof(T), new object[] { title, id });
            Add(obj);
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
            int maxid = 0;
            if(objects.Count>0)
            maxid=objects
                   .Max(x => x.Id);

            return maxid;
                   
        }

        public IEnumerator<T> GetEnumerator()
        {
            return objects.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return objects.GetEnumerator();
        }

        
        #endregion



    }
}
