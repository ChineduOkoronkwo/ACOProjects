using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DBService.interfaces
{
    public interface IQueryService
    {
        Task<int> ExecuteAsync(string sqlCommand, object? parm);
        Task<IEnumerable<T>> QueryAsync<T>(string sqlCommand, object? parm);
        Task<T> QuerySingleAsync<T>(string sqlCommand, object? parm);
    }
}