using DataService.Interfaces;

namespace DataService.Services
{
    public class DbService : IDbService
    {
        private readonly IQueryService _queryService;

        public DbService(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<T> GetAsync<T>(string sqlCommand, object? param)
        {
            return await _queryService.QuerySingleAsync<T>(sqlCommand, param);
        }

        public async Task<IEnumerable<T>> ListAsync<T>(string sqlCommand, object? param)
        {
            return await _queryService.QueryAsync<T>(sqlCommand, param);
        }

        public async Task<int> CreateAsync(string sqlCommand, object? param)
        {
            return await _queryService.ExecuteAsync(sqlCommand, param);
        }

        public async Task<int> UpdateAsync(string sqlCommand, object? param)
        {
            return await _queryService.ExecuteAsync(sqlCommand, param);
        }

        public async Task<int> DeleteAsync(string sqlCommand, object? param)
        {
            return await _queryService.ExecuteAsync(sqlCommand, param);
        }
    }
}