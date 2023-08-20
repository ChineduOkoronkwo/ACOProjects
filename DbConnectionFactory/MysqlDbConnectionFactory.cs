using System.Data;
using DbConnectionFactory.Interfaces;
using MySql.Data.MySqlClient;

namespace DbConnectionFactory
{
    public class MysqlDbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection GetDbConnection(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }
    }
}