using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class MySQLRegionData : IRegionData
    {
        private readonly MySqlConnection _connection;
        public MySQLRegionData(IDbConnection conn)
        {
            _connection = conn.connection;
        }

        public async Task<List<RegionModel>> GetRegionsAsync()
        {
            return (List<RegionModel>)await _connection.QueryAsync<RegionModel>(
                "Call GetRegions()",
                new());
        }

        public List<RegionModel> GetRegions()
        {
            return (List<RegionModel>)_connection.Query<RegionModel>(
                "Call GetRegions()",
                new());
        }
    }
}
