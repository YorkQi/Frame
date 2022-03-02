namespace Frame.Mysql.DBContext
{
    public static class MysqlDBContextCommandHelper
    {
        #region 私有方法

        //private static SqlCommand BuildQuery<TEntity>(MysqlDBContext dbContext, long[] keys = null)
        //    where TEntity : IEntity
        //{
        //    IDataObjectContext context = DataObjectContextFactory.GetDataObjectContext<TEntity>();
        //    FieldCollection fields = new FieldCollection();
        //    FilterCollection filters = new FilterCollection();
        //    foreach (PropertyInfo property in context.PropertyInfos)
        //    {
        //        fields.Add(new Field(property.Name));
        //    }
        //    if (keys?.Length > 0)
        //    {
        //        filters.Add(new EqualFilter(context.PrimaryKeyName, keys));
        //    }
        //    SqlCommand command = dbContext.SqlCommandTranslator.TranslateQueryCommand(context.TableName, fields, filters: filters);
        //    return command;
        //}

        //private static SqlCommand BuildInsert<TEntity>(MysqlDBContext dbContext, TEntity dataObject)
        //    where TEntity : IEntity
        //{
        //    if (dataObject == null)
        //    {
        //        throw new ArgumentNullException(nameof(dataObject));
        //    }

        //    IDataObjectContext context = DataObjectContextFactory.GetDataObjectContext<TDataObject>();
        //    FieldCollection fields = new FieldCollection();
        //    foreach (PropertyInfo property in context.PropertyInfos)
        //    {
        //        if (property.Name != context.PrimaryKeyName)
        //        {
        //            fields.Add(new Field(property.Name, property.GetValue(dataObject)));
        //        }
        //    }
        //    SqlCommand command = dbContext.SqlCommandTranslator.TranslateInsertCommand(context.TableName, fields);
        //    return command;
        //}

        //private static SqlCommand BuildUpdate<TEntity>(MysqlDBContext dbContext, TEntity dataObject)
        //    where TEntity : IEntity
        //{
        //    IDataObjectContext context = DataObjectContextFactory.GetDataObjectContext<TDataObject>();
        //    FieldCollection fields = new FieldCollection();
        //    FilterCollection filters = new FilterCollection();
        //    foreach (PropertyInfo property in context.PropertyInfos)
        //    {
        //        object value = property.GetValue(dataObject);
        //        if (property.Name == context.PrimaryKeyName)
        //        {
        //            filters.Add(new EqualFilter(property.Name, value));
        //        }
        //        else
        //        {
        //            fields.Add(new Field(property.Name, value));
        //        }
        //    }
        //    SqlCommand command = dbContext.SqlCommandTranslator.TranslateUpdateCommand(context.TableName, fields, filters);
        //    return command;
        //}

        //private static SqlCommand BuildDelete<TEntity>(MysqlDBContext dbContext, long key)
        //    where TEntity : IEntity
        //{
        //    IDataObjectContext context = DataObjectContextFactory.GetDataObjectContext<TDataObject>();
        //    FilterCollection filters = new FilterCollection
        //    {
        //        new EqualFilter(context.PrimaryKeyName, key)
        //    };
        //    SqlCommand command = dbContext.SqlCommandTranslator.TranslateDeleteCommand(context.TableName, filters);
        //    return command;
        //}

        #endregion
    }
}
