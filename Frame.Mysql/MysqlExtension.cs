using System;
using System.Data;

namespace Frame.Mysql
{
    public class MysqlExtension
    {
        public  IDbConnection? _dbConnection { get; private set; }
        public IServiceProvider _service { get; private set; }

        private readonly IMysqlBuilder _sqlBuilder;
        public MysqlExtension(IMysqlBuilder sqlBuilder)
        {
            _sqlBuilder = sqlBuilder;
        }

        public  void GetRepository()
        {
            _dbConnection = _sqlBuilder.GetDbConnection();
        }

    }
}
