namespace Bucks.DataAccess.DbCommand.Filters
{
    public class IntervalFilter : Filter
    {
        /// <summary>
        /// 区间过滤
        /// </summary>
        /// <param name="field"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public IntervalFilter(string field, object start, object end) : base(field)
        {
            Start = start;
            End = end;
        }

        public object Start { get; }
        public object End { get; }
    }
}
