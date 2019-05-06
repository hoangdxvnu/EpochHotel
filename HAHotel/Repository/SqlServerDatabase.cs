using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using HAHotel.Repository.Common;

namespace HAHotel.Repository
{
    public class SqlServerDatabase: IDatabase
    {
        #region attribute
        private SqlConnection _con;
        private SqlCommand _cmd;
        private SqlDataAdapter _adapter;

        public static string ConnectionString = string.Empty;
        public static int ConnectDbTimeOut = 300;

        //private readonly SQLConfigSingleton _singletonSqlConfig;
        #endregion atribute

        #region Constructor

        public SqlServerDatabase(SqlServerConfig serverConfig)
        {
            ConnectionString = serverConfig.ConnectionString;
            ConnectDbTimeOut = Convert.ToInt32(serverConfig.Timeout);
        }
        #endregion Constructor

        #region Methods
        public void ExecuteNonQuery(string query, SqlServerParameter parameter, ExecuteTypeEnum type)
        {

            using (_con = new SqlConnection(ConnectionString))
            {
                _con.Open();
                _cmd = new SqlCommand
                {
                    Connection = _con,
                    CommandType = type == ExecuteTypeEnum.StoredProcedure
                        ? CommandType.StoredProcedure
                        : CommandType.Text,
                    CommandText = query,
                    CommandTimeout = ConnectDbTimeOut
                };

                if (parameter != null)
                    _cmd.Parameters.AddRange(parameter.ToArray());

                _cmd.ExecuteNonQuery();
                _con.Dispose();

                if (_con.State == ConnectionState.Open)
                    _con.Close();
            }
        }

        public DataTable ExecuteToTable(string query, SqlServerParameter parameter, ExecuteTypeEnum type)
        {
            using (_con = new SqlConnection(ConnectionString))
            {
                _con.Open();
                _cmd = new SqlCommand
                {
                    Connection = _con
                };
                _cmd.Parameters.Clear();
                _cmd.CommandType = type == ExecuteTypeEnum.StoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
                _cmd.CommandText = query;
                _cmd.CommandTimeout = ConnectDbTimeOut;

                if (parameter != null)
                    _cmd.Parameters.AddRange(parameter.ToArray());

                _adapter = new SqlDataAdapter(_cmd);
                DataTable tbl = new DataTable();
                _adapter.Fill(tbl);
                _adapter.Dispose();

                if (_con.State == ConnectionState.Open)
                    _con.Close();

                return tbl;
            }
        }

        public T ExecuteScalarFunction<T>(string query, SqlServerParameter parameter, ExecuteTypeEnum type)
        {
            using (_con = new SqlConnection(ConnectionString))
            {
                _cmd = new SqlCommand
                {
                    Connection = _con
                };
                _cmd.Parameters.Clear();
                _cmd.CommandType = type == ExecuteTypeEnum.StoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
                _cmd.CommandText = query;
                _cmd.CommandTimeout = ConnectDbTimeOut;

                if (parameter != null)
                    _cmd.Parameters.AddRange(parameter.ToArray());
                SqlParameter returnValue = _cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Text);
                returnValue.Direction = ParameterDirection.ReturnValue;

                _con.Open();
                _cmd.ExecuteNonQuery();
                if (_con.State == ConnectionState.Open)
                    _con.Close();

                return (T)returnValue.Value;
            }
        }

        public DataSet ExecuteToDataset(string query, SqlServerParameter parameter, ExecuteTypeEnum type)
        {
            using (_con = new SqlConnection(ConnectionString))
            {
                _con.Open();
                _cmd = new SqlCommand
                {
                    Connection = _con
                };
                _cmd.Parameters.Clear();
                _cmd.CommandType = type == ExecuteTypeEnum.StoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
                _cmd.CommandText = query;
                _cmd.CommandTimeout = ConnectDbTimeOut;

                if (parameter != null)
                    _cmd.Parameters.AddRange(parameter.ToArray());

                _adapter = new SqlDataAdapter(_cmd);
                DataSet dts = new DataSet();
                _adapter.Fill(dts);
                _adapter.Dispose();

                if (_con.State == ConnectionState.Open)
                    _con.Close();

                return dts;
            }
        }


        public T ExecuteScalar<T>(string query, SqlServerParameter parameter, ExecuteTypeEnum type)
        {
            using (_con = new SqlConnection(ConnectionString))
            {
                _con.Open();
                _cmd = new SqlCommand
                {
                    Connection = _con,
                    CommandType = type == ExecuteTypeEnum.StoredProcedure
                        ? CommandType.StoredProcedure
                        : CommandType.Text,
                    CommandText = query,
                    CommandTimeout = ConnectDbTimeOut
                };

                if (parameter != null)
                    _cmd.Parameters.AddRange(parameter.ToArray());

                object obj = _cmd.ExecuteScalar();
                _con.Close();

                return (T)obj;
            }
        }
        #endregion 
    }
}
