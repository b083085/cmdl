using System.Collections.Generic;
using System.Linq;

namespace CMDL.Data
{
    public class DataQuery
    {
        public string Query { get; set; }
        public IList<QueryParameter> Parameters { get; }

        public DataQuery()
        {
            Parameters = new List<QueryParameter>();
        }

        public void AddParameter(string key, object value)
        {
            Parameters.Add(new QueryParameter(key, value));
        }

        public bool HasParameters => Parameters.Any();
    }
}
