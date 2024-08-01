namespace CMDL.Data
{
    public class QueryParameter
    {
        public QueryParameter(string key, object value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; }
        public object Value { get; }
    }
}
