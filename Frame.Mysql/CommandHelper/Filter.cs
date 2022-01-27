using System;

namespace Bucks.DataAccess.DbCommand
{
    public abstract class Filter
    {
        public Filter(string field)
        {
            if (string.IsNullOrEmpty(field))
            {
                throw new ArgumentNullException(nameof(field));
            }
            Field = field;
        }
        public virtual string Field { get; private set; }
    }
}
