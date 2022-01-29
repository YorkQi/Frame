namespace Frame.Mysql.CommandExtension.Filters
{
    public enum FuzzyType
    {
        Left,
        Right,
        All
    }

    /// <summary>
    /// 模糊过滤
    /// </summary>
    public class FuzzyFilter : Filter
    {
        public FuzzyFilter(string field, object value, FuzzyType type = FuzzyType.Right) : base(field)
        {
            Value = value;
            Type = type;
        }
        public object Value { get; }
        public FuzzyType Type { get; }
    }
}
