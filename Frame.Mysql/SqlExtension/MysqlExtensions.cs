namespace Frame.Mysql.SqlExtension
{
    public static class MysqlExtensions
    {
        public static string GetStatement(string tableName)
        {
            return $@"SELECT * FROM {tableName} WHERE Id=@Id;";
        }

        public static string InsertStatement(string tableName)
        {
            return $@"INSERT INTO  * FROM {tableName} WHERE Id=@Id;";
        }
    }
}
