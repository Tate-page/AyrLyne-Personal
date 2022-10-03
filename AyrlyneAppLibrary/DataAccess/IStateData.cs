using AyrlyneAppLibrary.Models;

namespace AyrlyneAppLibrary.DataAccess
{
    public interface IStateData
    {
        Task<List<StateModel>> GetStatesAsync();
        List<StateModel> GetStates();
    }
}