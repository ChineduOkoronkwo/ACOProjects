using System.Data;
using DataService.Interfaces;
using DataService.Services;
using DbConnectionFactory;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace DbServiceAcceptanceTest.Utilities
{
    public class DbServiceFactory
    {
        public IDbService GetDbService(string databaseName, DbType dbType)
        {
            var dbConnection = dbType switch
            {
                DbType.Pgsql => GetPgSqlConnection(databaseName),
                _ => throw new Exception("Unimplemented dbType"),
            };
            return new DbService(new QueryService(dbConnection));
        }

        private IDbConnection GetPgSqlConnection(string databaseName)
        {
            var connectionString = $"Server=localhost; Port=5432; User Id=testuser; Password=secret; Database={databaseName}";
            var connFactory = new NpgsqlConnectionFactory();
            return connFactory.GetDbConnection(connectionString);
        }
    }

    public enum DbType
    {
        [Description("Unknow Database Type")]
        Unknown = 0,
        [Description("Postgresql")]
        Pgsql,
        [Description("Microsoft Sql Server")]
        Mssql
    }

    public enum SoccerPredictionTable
    {
        Unknow = 0,
        Country = 1
    }
}