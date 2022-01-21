using System.Collections.Generic;

namespace Frame.Mysql.CommandHelper
{
    public class Table
    {
        public string TableName { get; set; }

        public IEnumerable<Field> Fields { get; set; }
    }
}
