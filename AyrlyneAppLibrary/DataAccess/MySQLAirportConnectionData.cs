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
    public class MySQLAirportConnectionData : IAirportConnectionData
    {
        private readonly MySqlConnection _connection;

        public MySQLAirportConnectionData(IDbConnection conn)
        {
            _connection = conn.connection;
        }

        //get all airport connections
        public async Task<List<AirportConnectionModel>> GetAllAirportConnectionsAsync()
        {
            return (List<AirportConnectionModel>)await _connection.QueryAsync<AirportConnectionModel>(
                "Call GetAirportConnections()",
                new());
        }

        public List<AirportConnectionModel> GetAllAirportConnections()
        {
            return (List<AirportConnectionModel>)_connection.Query<AirportConnectionModel>(
                "Call GetAirports()",
                new());
        }

        public List<AirportConnectionModel> GetAllAirportConnectionsAndAirportModels()
        {
            return (List<AirportConnectionModel>)_connection.Query<AirportConnectionModel>(
                "Call GetAirports()",
                new());
        }

        //create AirportConnection
        public async Task CreateAirportConnectionAsync(int temp1, int temp2)
        {
            await _connection.ExecuteAsync(
                "CALL CreateAirportConnection(@tempAirportID1, @tempAirportID2)",
                new
                {
                    @tempAirportID1 = temp1,
                    @tempAirportID2 = temp2
                });
        }

        public void CreateAirportConnection(int temp1, int temp2)
        {
            _connection.Execute(
                "CALL CreateAirportConnection(@tempAirportID1, @tempAirportID2)",
                new
                {
                    @tempAirportID1 = temp1,
                    @tempAirportID2 = temp2
                });
        }

        //get all airport connections by AirportID1
        //get airportConnectionByID
    }
}
