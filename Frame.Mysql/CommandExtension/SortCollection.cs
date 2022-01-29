using System.Collections;
using System.Collections.Generic;

namespace Frame.Mysql.CommandExtension
{
    public class SortCollection : IEnumerable<Sort>
    {
        private ArrayList _innerList;

        public SortCollection()
        {
            _innerList = new ArrayList();
        }

        public int Count => _innerList.Count;

        public void Add(Sort sort)
        {
            _innerList.Add(sort);
        }

        public void Add(params Sort[] sorts)
        {
            _innerList.AddRange(sorts);
        }

        public IEnumerator<Sort> GetEnumerator()
        {
            IEnumerator iterator = _innerList.GetEnumerator();
            while (iterator.MoveNext())
            {
                yield return (Sort)iterator.Current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }
    }
}
