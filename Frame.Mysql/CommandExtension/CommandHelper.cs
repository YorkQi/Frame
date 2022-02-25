using Dapper;
using System;
using System.Collections.Generic;

namespace Frame.Mysql.CommandExtension
{
    public class CommandHelper
    {
        /// <summary>
        /// 检索命令
        /// </summary>
        /// <param name="table"></param>
        /// <param name="DbContext.Query"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public SqlCommand TranslateQueryCommand(string table, FieldCollection fields, FilterCollection filters, SortCollection sorts, int? count)
        {
            if (string.IsNullOrEmpty(table))
            {
                throw new ArgumentNullException(nameof(table));
            }
            if (fields == null || fields.Count == 0)
            {
                throw new ArgumentNullException(nameof(fields));
            }

            DynamicParameters param = new DynamicParameters();
            List<string> fieldList = new List<string>();
            List<string> filterList = new List<string>();
            List<string> sortList = new List<string>();

            foreach (Field field in fields)
            {
                fieldList.Add($"`{field.Name}`");
            }

            if (filters != null)
            {
                foreach (Filter filter in filters)
                {
                    SqlCommand filterCommand = filter.ToSqlCommand();
                    if (filterCommand != null)
                    {
                        filterList.Add(filterCommand.SqlString);
                        param.AddDynamicParams(filterCommand.Parameters);
                    }
                }
            }

            if (sorts != null)
            {
                foreach (Sort sort in sorts)
                {
                    sortList.Add($"`{sort.Field}` {(sort.ASC ? "ASC" : "DESC")}");
                }
            }

            string filedsStr = fieldList.Count > 0 ? string.Join(',', fieldList) : "*";
            string filtersStr = filterList.Count > 0 ? $" WHERE {string.Join(" AND ", filterList)}" : "";
            string sortsStr = sortList.Count > 0 ? $" ORDER BY {string.Join(',', sortList)}" : "";
            string countStr = count.HasValue ? $" LIMIT {count.Value}" : "";

            string strSql = $"SELECT {filedsStr} FROM `{table}`{filtersStr}{sortsStr}{countStr};";
            return new SqlCommand(strSql, param);
        }

        /// <summary>
        /// 插入命令
        /// </summary>
        /// <param name="table"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public SqlCommand TranslateInsertCommand(string table, FieldCollection fields)
        {
            if (string.IsNullOrEmpty(table))
            {
                throw new ArgumentNullException(nameof(table));
            }
            if (fields == null || fields.Count == 0)
            {
                throw new ArgumentNullException(nameof(fields));
            }

            DynamicParameters param = new DynamicParameters();
            List<string> fieldList = new List<string>();
            List<string> valueList = new List<string>();
            foreach (Field field in fields)
            {
                fieldList.Add($"`{field.Name}`");
                valueList.Add($"@{field.Name}");
                param.Add(field.Name, field.Value);
            }

            string fieldsStr = string.Join(',', fieldList);
            string valuesStr = string.Join(',', valueList);

            string strSql = $"INSERT INTO `{table}`({fieldsStr}) VALUES ({valuesStr});SELECT @@IDENTITY;";
            return new SqlCommand(strSql, param);
        }

        /// <summary>
        /// 更新命令
        /// </summary>
        /// <param name="table"></param>
        /// <param name="fields"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public SqlCommand TranslateUpdateCommand(string table, FieldCollection fields, FilterCollection filters)
        {
            if (string.IsNullOrEmpty(table))
            {
                throw new ArgumentNullException(nameof(table));
            }
            if (fields == null || fields.Count == 0)
            {
                throw new ArgumentNullException(nameof(fields));
            }

            DynamicParameters param = new DynamicParameters();
            List<string> updateList = new List<string>();
            List<string> filterList = new List<string>();
            foreach (Field field in fields)
            {
                updateList.Add($"`{field.Name}`=@{field.Name}");
                param.Add(field.Name, field.Value);
            }
            if (filters != null)
            {
                foreach (Filter filter in filters)
                {
                    SqlCommand filterCommand = filter.ToSqlCommand();
                    if (filterCommand != null)
                    {
                        filterList.Add(filterCommand.SqlString);
                        param.AddDynamicParams(filterCommand.Parameters);
                    }
                }
            }
            string updateStr = string.Join(',', updateList);
            string filterStr = filterList.Count > 0 ? $" WHERE {string.Join(" AND ", filterList)}" : "";
            string strSql = $@"UPDATE `{table}` SET {updateStr}{filterStr};";
            return new SqlCommand(strSql, param);
        }

        /// <summary>
        /// 删除命令
        /// </summary>
        /// <param name="table"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public SqlCommand TranslateDeleteCommand(string table, FilterCollection filters)
        {
            if (string.IsNullOrEmpty(table))
            {
                throw new ArgumentNullException(nameof(table));
            }
            if (filters == null || filters.Count == 0)
            {
                throw new ArgumentNullException(nameof(filters));
            }

            DynamicParameters param = new DynamicParameters();
            List<string> filterList = new List<string>();
            foreach (Filter filter in filters)
            {
                SqlCommand filterCommand = filter.ToSqlCommand();
                if (filterCommand != null)
                {
                    filterList.Add(filterCommand.SqlString);
                    param.AddDynamicParams(filterCommand.Parameters);
                }
            }

            string filterStr = filterList.Count > 0 ? $" WHERE {string.Join(" AND ", filterList)}" : "";
            string strSql = $"DELETE FROM `{table}`{filterStr};";
            return new SqlCommand(strSql, param);
        }
    }
}
