using System.Data;
using DbConnectionFactory.Interfaces;
using Npgsql;

namespace DbConnectionFactory
{
    public class NpgsqlConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection GetDbConnection(string connectionString)
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}