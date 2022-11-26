using AyrlyneAppLibrary.Models;

namespace AyrlyneAppLibrary.DataAccess
{
    public interface IRegionData
    {
        List<RegionModel> GetRegions();
        Task<List<RegionModel>> GetRegionsAsync();
    }
}