namespace Bucks.DataAccess.DbCommand
{
    public interface ISqlCommandTranslator
    {
        /// <summary>
        /// 检索命令
        /// </summary>
        /// <param name="table"></param>
        /// <param name="fields"></param>
        /// <param name="filters"></param>
        /// <param name="sorts"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        SqlCommand TranslateQueryCommand(string table, FieldCollection fields, FilterCollection filters = null, SortCollection sorts = null, int? count = null);

        /// <summary>
        /// 插入命令
        /// </summary>
        /// <param name="table"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        SqlCommand TranslateInsertCommand(string table, FieldCollection fields);

        /// <summary>
        /// 更新命令
        /// </summary>
        /// <param name="table"></param>
        /// <param name="fields"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        SqlCommand TranslateUpdateCommand(string table, FieldCollection fields, FilterCollection filters = null);

        /// <summary>
        /// 删除命令
        /// </summary>
        /// <param name="table"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        SqlCommand TranslateDeleteCommand(string table, FilterCollection filters);
    }
}
