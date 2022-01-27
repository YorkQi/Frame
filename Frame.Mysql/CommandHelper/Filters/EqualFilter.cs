namespace Bucks.DataAccess.DbCommand.Filters
{
    /// <summary>
    /// 相等过滤
    /// </summary>
    public class EqualFilter : Filter
    {
        public EqualFilter(string field, object value)
            : base(field)
        {
            Value = value;
        }
        public object Value { get; }
    }
}
