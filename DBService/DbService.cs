using DBService.interfaces;

namespace DBService
{
    public class DbService<T> : IDbService<T>
    {

        private readonly IQueryService _queryService;

        public DbService(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<int> CreateAsync(string sqlCommand, object? parm)
        {
            return await _queryService.ExecuteAsync(sqlCommand, parm);
        }

        public async Task<int> DeleteAsync(string sqlCommand, object? parm)
        {
            return await _queryService.ExecuteAsync(sqlCommand, parm);
        }

        public async Task<int> UpdateAsync(string sqlCommand, object? parm)
        {
            return await _queryService.ExecuteAsync(sqlCommand, parm);
        }

        public async Task<T> GetAsync(string sqlCommand, object? parm)
        {
            return await _queryService.QuerySingleAsync<T>(sqlCommand, parm);
        }

        public async Task<IEnumerable<T>> ListAsync(string sqlCommand, object? parm)
        {
            return await _queryService.QueryAsync<T>(sqlCommand, parm);
        }
    }
}