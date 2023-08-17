using System.Data;
using DBService.interfaces;
using Npgsql;

namespace DBService
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection CreateConnection(string connectionString)
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}