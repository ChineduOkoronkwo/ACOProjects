using System.Data;

namespace DbConnectionFactory.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetDbConnection(string connectionString);
    }
}