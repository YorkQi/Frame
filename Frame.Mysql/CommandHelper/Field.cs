using System;

namespace Bucks.DataAccess.DbCommand
{
    public class Field
    {
        public Field(string name, object value = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
            Value = value;
        }
        public string Name { set; get; }
        public object Value { set; get; }
    }
}
