namespace DBService.interfaces
{
    public interface IDbService<T>
    {
        Task<T> GetAsync(string sqlCommand, object? parm);
        Task<IEnumerable<T>> ListAsync(string sqlCommand, object? parm);
        Task<int> CreateAsync(string sqlCommand, object? parm);
        Task<int> UpdateAsync(string sqlCommand, object? parm);
        Task<int> DeleteAsync(string sqlCommand, object? parm);
    }
}