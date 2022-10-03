using AyrlyneAppLibrary.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrlyneAppLibrary.DataAccess
{
    public class MySQLStateData : IStateData
    {
        private readonly MySqlConnection _connection;
        public MySQLStateData(IDbConnection conn)
        {
            _connection = conn.connection;
        }

        public async Task<List<StateModel>> GetStatesAsync()
        {
            return (List<StateModel>)await _connection.QueryAsync<StateModel>(
                "Call GetStates()",
                new List<StateModel>());
        }

        public List<StateModel> GetStates()
        {
            return (List<StateModel>) _connection.Query<StateModel>(
                "Call GetStates()", new());
        }
    }


}
