using System;

namespace Bucks.DataAccess.DbCommand
{
    public class Sort
    {
        public Sort(string field, bool asc = true)
        {
            if (string.IsNullOrEmpty(field))
            {
                throw new ArgumentNullException(nameof(field));
            }
            Field = field;
            ASC = asc;
        }
        public string Field { get; set; }
        public bool ASC { get; set; }
    }
}
