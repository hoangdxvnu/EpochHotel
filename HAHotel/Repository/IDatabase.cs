using System.Data;
using HAHotel.Repository.Common;

namespace HAHotel.Repository
{
    public interface IDatabase
    {
        void ExecuteNonQuery(string query, SqlServerParameter parameter, ExecuteTypeEnum type);

        DataTable ExecuteToTable(string query, SqlServerParameter parameter, ExecuteTypeEnum type);

        DataSet ExecuteToDataset(string query, SqlServerParameter parameter, ExecuteTypeEnum type);

        T ExecuteScalar<T>(string query, SqlServerParameter parameter, ExecuteTypeEnum type);

        T ExecuteScalarFunction<T>(string query, SqlServerParameter parameter, ExecuteTypeEnum type);
    }
}
