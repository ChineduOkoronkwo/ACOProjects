using System.Data;
using DBService.interfaces;
using Npgsql;
using Dapper;

namespace DBService
{
    public class QueryService : IQueryService
    {

        private readonly IDbConnection _dbConnection;

        public QueryService(string connectionString)
        {
            _dbConnection = new NpgsqlConnection(connectionString);
        }

        public async Task<int> ExecuteAsync(string sqlCommand, object? parm)
        {
            return await _dbConnection.ExecuteAsync(sqlCommand, parm);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sqlCommand, object? parm)
        {
            return await _dbConnection.QueryAsync<T>(sqlCommand, parm);
        }

        async Task<T> IQueryService.QuerySingleAsync<T>(string sqlCommand, object? parm)
        {
            return await _dbConnection.QuerySingleAsync<T>(sqlCommand, parm);
        }
    }
}