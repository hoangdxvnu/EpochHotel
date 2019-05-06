using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HAHotel.Repository.Common
{
    public class SqlServerParameter
    {
        private readonly List<SqlParameter> _parameter;

        public SqlServerParameter()
        {
            _parameter = new List<SqlParameter>();
        }

        public void Add_Parameter(string parameter, object value)
        {
            _parameter.Add(new SqlParameter(parameter, value));
        }

        public SqlParameter[] ToArray()
        {
            return _parameter.ToArray();
        }

        public List<SqlParameter> GetListParam()
        {
            return _parameter;
        }
    }
}
