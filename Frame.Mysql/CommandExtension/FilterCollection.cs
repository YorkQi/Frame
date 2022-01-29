using System.Collections;
using System.Collections.Generic;

namespace Frame.Mysql.CommandExtension
{
    public class FilterCollection : IEnumerable<Filter>
    {
        private ArrayList _innerList;

        public FilterCollection()
        {
            _innerList = new ArrayList();
        }

        public int Count => _innerList.Count;

        public void Add(Filter filter)
        {
            _innerList.Add(filter);
        }

        public void Add(params Filter[] filters)
        {
            _innerList.AddRange(filters);
        }

        public IEnumerator<Filter> GetEnumerator()
        {
            IEnumerator iterator = _innerList.GetEnumerator();
            while (iterator.MoveNext())
            {
                yield return (Filter)iterator.Current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }
    }
}
