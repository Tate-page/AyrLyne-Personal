using AyrlyneAppLibrary.Models;

namespace AyrlyneAppLibrary.DataAccess
{
    public interface IAirportData
    {
        List<AirportModel> GetAirports();
        Task<List<AirportModel>> GetAirportsAsync();
    }
}