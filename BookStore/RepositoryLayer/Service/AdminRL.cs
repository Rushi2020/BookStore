using DatabaseLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Service
{
    public class AdminRL : IAdminRL
    {
         IConfiguration configuration;
        string connetionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public AdminRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public ResAdminLogin AdminLogin(AdminModel adminModel)
        {
            ResAdminLogin resAdminLogin = new ResAdminLogin();
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Admin_Login", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmailId", adminModel.EmailId);
                    cmd.Parameters.AddWithValue("@Password", adminModel.Password);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            resAdminLogin.AdminId = Convert.ToInt32(rdr["AdminId"] == DBNull.Value ? default : rdr["AdminId"]);
                            resAdminLogin.FullName = Convert.ToString(rdr["FullName"] == DBNull.Value ? default : rdr["FullName"]);
                            resAdminLogin.EmailId = Convert.ToString(rdr["EmailId"] == DBNull.Value ? default : rdr["EmailId"]);
                            resAdminLogin.MobileNumber = Convert.ToInt64(rdr["MobileNumber"] == DBNull.Value ? default : rdr["MobileNumber"]);
                            resAdminLogin.Address = Convert.ToString(rdr["Address"] == DBNull.Value ? default : rdr["Address"]);
                            var password = Convert.ToString(rdr["Password"] == DBNull.Value ? default : rdr["Password"]);

                            if (password == adminModel.Password)
                            {
                                resAdminLogin.Token = GenerateSecurityToken(resAdminLogin.EmailId, resAdminLogin.AdminId);
                                return resAdminLogin;

                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                    else
                        return null;
                    con.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return default;
        }

        public string GenerateSecurityToken(string emailID, long adminId)
        {
            var SecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN"));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Role , "Admin"),
                new Claim(ClaimTypes.Email, emailID),
                new Claim("AdminId", adminId.ToString())
            };
            var token = new JwtSecurityToken(
                this.configuration["Jwt:Issuer"],
                this.configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
