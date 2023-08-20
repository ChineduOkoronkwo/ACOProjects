using System.Data;
using Dapper;
using DataService.Interfaces;
using DbConnectionFactory.Interfaces;

namespace DataService.Services
{
    public class QueryService : IQueryService
    {

        private readonly IDbConnection _dbConnection;

        public QueryService(IDbConnectionFactory dbConnectionFactory, string connectionString)
        {
            _dbConnection = dbConnectionFactory.GetDbConnection(connectionString);
        }

        public QueryService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> ExecuteAsync(string sqlCommand, object? param)
        {
            return await _dbConnection.ExecuteAsync(sqlCommand, param);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sqlCommand, object? param)
        {
            return await _dbConnection.QueryAsync<T>(sqlCommand, param);
        }

        public async Task<T> QuerySingleAsync<T>(string sqlCommand, object? param)
        {
            return await _dbConnection.QuerySingleAsync<T>(sqlCommand, param);
        }
    }
}