using Dapper;

namespace Bucks.DataAccess.DbCommand
{
    public class SqlCommand
    {
        public SqlCommand(string strSql, DynamicParameters param = null)
        {
            SqlString = strSql;
            Parameters = param;
        }

        public virtual string SqlString { set; get; }
        public virtual DynamicParameters Parameters { set; get; }
    }
}
