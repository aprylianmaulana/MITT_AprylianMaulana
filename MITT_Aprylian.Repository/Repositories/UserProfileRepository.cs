using Dapper;
using Microsoft.Extensions.Configuration;
using MITT_Aprylian.Domain.Models;
using MITT_Aprylian.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace MITT_Aprylian.Repository.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IConfiguration _config;
        public UserProfileRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IDbConnection Connect
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("dbConnection"));
            }
        }
        public async Task<IEnumerable<UserProfileModel>> RegisterUser(UserProfileModel userProfileModel)
        {
            string userName = userProfileModel.UserName;
            string name = userProfileModel.Name;
            string address = userProfileModel.Address;
            DateTime bod = userProfileModel.Bod;
            string email = userProfileModel.Email;
            using (IDbConnection connection = Connect)
            {
                connection.Open();
                var sql = $"exec RegisterUserProfile @Username = '{userName}', @Name = '{name}', @Address = '{address}', @Bod = '{bod}', @Email = '{email}'";
                var result = await connection.QueryAsync<UserProfileModel>(sql);
                return result;
            }
        }

        public async Task<IEnumerable<UserProfileModel>> UpdateUserProfile(UserProfileModel userProfileModel)
        {
            string userName = userProfileModel.UserName;
            string name = userProfileModel.Name;
            string address = userProfileModel.Address;
            DateTime bod = userProfileModel.Bod;
            string email = userProfileModel.Email;
            using (IDbConnection connection = Connect)
            {
                connection.Open();
                var sql = $"exec UpdateUserProfile @Username = '{userName}',  @Name = '{name}', @Address = '{address}', @Bod = '{bod}', @Email = '{email}'";
                var result = await connection.QueryAsync<UserProfileModel>(sql);
                return result;
            }
        }
    }
}
