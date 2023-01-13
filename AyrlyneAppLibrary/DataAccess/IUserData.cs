using AyrlyneAppLibrary.Models;

namespace AyrlyneAppLibrary.DataAccess
{
    public interface IUserData
    {
        Task<bool> doesUserExistByEmailAsync(string email);

        bool doesUSerExistByEmail(string email);
        UserModel returnIfUserExists(string email);
        Task<UserModel> returnIfUserExistsAsync(string email);

        UserModel updateDB(UserModel model);
        Task<UserModel> updateDBAsync(UserModel model);

        UserModel createAndReturnUser(string Fname, string Lname, string Email, int AirportID);

        Task<UserModel> createAndReturnUserAsync(string Fname, string Lname, string Email, int AirportID);
    }
}