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
    public class MySQLUserData : IUserData
    {
        private readonly MySqlConnection _connection;
        public MySQLUserData(IDbConnection conn)
        {
            _connection = conn.connection;
        }

        public async Task<UserModel> returnIfUserExistsAsync(string email)
        {
            var temp = await _connection.QueryAsync(
                "Call ReturnUserIfEmailExists(@tempEmail)",
                new
                {
                    @tempEmail = email
                });
            if (temp != null)
            {
                var tempItem = temp.FirstOrDefault();
                UserModel model = new UserModel();
                model.UserID = tempItem.UserID;
                model.Fname = tempItem.Fname;
                model.Lname = tempItem.Lname;
                model.Email = tempItem.Email;
                model.HomeAirportID = tempItem.HomeAirportID;
                model.UserAirlineID = tempItem?.UserAirlineID;
                model.isAdmin = ((tempItem?.isAdmin)%2 == 0 ? true : false);
                return model;
            }
            else
            {
                return new();
            }
        }

        public UserModel returnIfUserExists(string email)
        {
            var temp =  _connection.Query<UserModel>(
                "Call ReturnUserIfEmailExists(@tempEmail)",
                new
                {
                    @tempEmail = email
                });
            if(temp != null && temp.Count() != 0)
            {
                return (UserModel)temp;
            }
            else
            {
                return new();
            }
        }

        public async Task<UserModel> updateDBAsync(UserModel model)
        {
            UserModel tempUser = await this.returnIfUserExistsAsync(model.Email);
            if(tempUser.Email == null)
            {
                var temp = _connection.QueryAsync<UserModel>(
                "Call CreateAndReturnUser(@tempFname, @tempLname, @tempEmail, @tempAirportID, @tempIsAdmin)",
                new
                {
                    @tempFname = model.Fname,
                    @tempLname = model.Lname,
                    @tempEmail = model.Email,
                    @tempHomeAirportID = model.HomeAirportID,
                    @tempIsAdmin = 1
                });
                tempUser = new UserModel();
                //tempUser.Email = temp.Result.
                return tempUser;
            }
            else
            {
                return tempUser;
            }
        }

        public UserModel updateDB(UserModel model)
        {
            UserModel tempUser = this.returnIfUserExists(model.Email);
            if (tempUser.UserID == 0)
            {
                var temp = _connection.Query<UserModel>(
                "Call CreateAndReturnUser(@tempFname, @tempLname, @tempEmail, @tempHomeAirportID, @tempIsAdmin)",
                new
                {
                    @tempFname = model.Fname,
                    @tempLname = model.Lname,
                    @tempEmail = model.Email,
                    @tempHomeAirportID = model.HomeAirportID,
                    @tempIsAdmin = false
                });
                return (UserModel)temp;
            }
            else
            {
                return tempUser;
            }
        }
    }
}
