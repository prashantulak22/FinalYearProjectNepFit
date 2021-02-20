using System.Data;
using Microsoft.Data.SqlClient;

namespace NepFit.Repository
{
    public class SqlServerConnectionProvider : ISqlServerConnectionProvider
    {
        private readonly string _connectionString;

        public SqlServerConnectionProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}