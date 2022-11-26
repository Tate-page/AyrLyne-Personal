using AyrlyneAppLibrary.Models;

namespace AyrlyneAppLibrary.DataAccess
{
    public interface IAirportConnectionData
    {
        void CreateAirportConnection(int temp1, int temp2);
        Task CreateAirportConnectionAsync(int temp1, int temp2);
        List<AirportConnectionModel> GetAllAirportConnections();
        Task<List<AirportConnectionModel>> GetAllAirportConnectionsAsync();
    }
}