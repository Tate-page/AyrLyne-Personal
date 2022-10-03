using MySql.Data.MySqlClient;

namespace AyrlyneAppLibrary.DataAccess
{
    public interface IDbConnection
    {
        MySqlConnection connection { get; }
        string DbName { get; }
    }
}