using System.Data;
using DbConnectionFactory.Interfaces;
using Microsoft.Data.SqlClient;

namespace DbConnectionFactory
{
    public class MssqlDbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection GetDbConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}