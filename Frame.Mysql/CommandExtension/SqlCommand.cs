using Dapper;

namespace Frame.Mysql.CommandExtension
{
    public class SqlCommand
    {
        public SqlCommand(string strSql, DynamicParameters param)
        {
            SqlString = strSql;
            Parameters = param;
        }

        public virtual string SqlString { set; get; }
        public virtual DynamicParameters Parameters { set; get; }
    }
}
