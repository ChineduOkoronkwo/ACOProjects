namespace DataService.Interfaces
{
    public interface IDbService
    {
        Task<T> GetAsync<T>(string sqlCommand, object? param);
        Task<IEnumerable<T>> ListAsync<T>(string sqlCommand, object? param);
        Task<int> CreateAsync(string sqlCommand, object? param);
        Task<int> UpdateAsync(string sqlCommand, object? param);
        Task<int> DeleteAsync(string sqlCommand, object? param);
    }
}