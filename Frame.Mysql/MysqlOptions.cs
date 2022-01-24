using System.Collections.Generic;

namespace Frame.Mysql
{
    public class MysqlOptions
    {
        public List<string>? QueryConnectionString { get; set; }

        public List<string>? CommandConnectionString { get; set; }
    }
}
