using AyrlyneAppLibrary.Models;

namespace AyrlyneAppLibrary.DataAccess
{
    public interface IUserData
    {
        UserModel returnIfUserExists(string email);
        Task<UserModel> returnIfUserExistsAsync(string email);

        UserModel updateDB(UserModel model);
        Task<UserModel> updateDBAsync(UserModel model);
    }
}