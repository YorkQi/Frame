using System.Linq;

namespace Frame.Mysql.CommandHelper
{
    public  class CommandHelper
    {
        public static string InsertStr(Table table)
        {
            string sqlStr = "";
            if (table != null)
            {
                sqlStr = $@"INSERT INTO {table.TableName}({string.Join(',', table.Fields.Select(t => t.Name))})
                VALUE ({string.Join(',', table.Fields.Select(t => t.Value))});";
            }
            return sqlStr;
        }

        public static string UpdateStr(Table table)
        {
            string sqlStr = "";
            if (table != null)
            {
                sqlStr = $@"UPDATE {table.TableName} SET 
                {string.Join(',', table.Fields.Select(t => new { Field = $"{t.Name}={t.Value}" }))} 
                WHERE Id=@Id;";
            }
            return sqlStr;
        }
    }
}
