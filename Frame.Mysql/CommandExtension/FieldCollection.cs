using System.Collections;
using System.Collections.Generic;

namespace Frame.Mysql.CommandExtension
{
    public class FieldCollection : IEnumerable<Field>
    {
        private ArrayList _innerList;

        public FieldCollection()
        {
            _innerList = new ArrayList();
        }

        public int Count => _innerList.Count;

        public void Add(Field field)
        {
            _innerList.Add(field);
        }

        public void Add(params Field[] fields)
        {
            _innerList.AddRange(fields);
        }

        public IEnumerator<Field> GetEnumerator()
        {
            IEnumerator iterator = _innerList.GetEnumerator();
            while (iterator.MoveNext())
            {
                yield return (Field)iterator.Current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }
    }
}
