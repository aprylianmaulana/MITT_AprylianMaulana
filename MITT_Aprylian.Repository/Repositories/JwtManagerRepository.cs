using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MITT_Aprylian.Domain.Models;
using MITT_Aprylian.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MITT_Aprylian.Repository.Repositories
{
    public class JwtManagerRepository : IJwtManagerRepository
    {
        private readonly IConfiguration _config;
        public JwtManagerRepository(IConfiguration configuration)
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

        public TokenData Authenticate(UserModel users)
        {
            using(IDbConnection connection = Connect)
            {
                connection.Open();
                var sql = $"Select * from Users where username = '{users.UserName}'";
                var result = connection.QueryFirstOrDefault<UserModel>(sql);
                if (result == null || (result.UserName != users.UserName && result.Password != users.Password))
                {
                    return null;
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_config["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, users.UserName)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new TokenData { Token = tokenHandler.WriteToken(token) };
            }
        }
    }
}
