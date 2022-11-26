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
    public class MySQLAirportData : IAirportData
    {
        private readonly MySqlConnection _connection;
        public MySQLAirportData(IDbConnection conn)
        {
            _connection = conn.connection;
        }

        public async Task<List<AirportModel>> GetAirportsAsync()
        {
            return (List<AirportModel>)await _connection.QueryAsync<AirportModel>(
                "Call GetAirports()",
                new());
        }

        public List<AirportModel> GetAirports()
        {
            return (List<AirportModel>)_connection.Query<AirportModel>(
                "Call GetAirports()",
                new());
        }

        public AirportModel GetAirportByID(int id)
        {
            return (AirportModel)_connection.Query<AirportModel>(
                "Call GetAirportByID(@temp)",
                new {
                    temp = id
                });
        }
    }
}
