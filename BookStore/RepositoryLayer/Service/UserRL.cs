using DatabaseLayer;
using Experimental.System.Messaging;
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
    public class UserRL : IUserRL
    {
        string connetionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public void addUser(UserModel usermodel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connetionString))
                {
                    SqlCommand command = new SqlCommand("AddUser", con);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FullName", usermodel.FullName);
                    command.Parameters.AddWithValue("@EmailId", usermodel.EmailId);
                    command.Parameters.AddWithValue("@Password", usermodel.Password);
                    command.Parameters.AddWithValue("@MobileNumber", usermodel.MobileNumber);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string userLogin(LoginModel loginModel )
        {
            try
            {

                using (SqlConnection con = new SqlConnection(connetionString))
                {
                    UserModel usermodel = new UserModel();
                    SqlCommand command = new SqlCommand("userLogin", con);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@EmailId", loginModel.EmailId);
                    command.Parameters.AddWithValue("@Password", loginModel.Password);
                    con.Open();

                    SqlDataReader rdr = command.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        
                        int UserId = 0;
                        while (rdr.Read())
                        {
                            UserId = Convert.ToInt32(rdr["id"]);
                        }
                      
                        string token = GenerateJWTToken(loginModel.EmailId, UserId);
                        
                        return token;
                    }
                    else
                    {
                        return null;
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private static string GenerateJWTToken(string email, int UserId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role , "User"),
                    new Claim("email", email),
                    new Claim("userId", UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool forgotPassword(string emailid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connetionString))
                {
                    UserModel usermodel = new UserModel();
                    SqlCommand command = new SqlCommand("ForgotPassword", con);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@EmailId", emailid);
                    con.Open();
                    var result = command.ExecuteNonQuery();
                    MessageQueue queue;
                    //ADD MESSAGE TO QUEUE
                    if (MessageQueue.Exists(@".\Private$\BookStoreQueue"))
                    {
                        queue = new MessageQueue(@".\Private$\BookStoreQueue");
                    }
                    else
                    {
                        queue = MessageQueue.Create(@".\Private$\BookStoreQueue");
                    }
                    Message MyMessage = new Message();
                    MyMessage.Formatter = new BinaryMessageFormatter();
                    MyMessage.Body = GenerateJWTToken(emailid, usermodel.UserId);
                    MyMessage.Label = "Forget Password Email";
                    queue.Send(MyMessage);
                    Message msg = queue.Receive();
                    msg.Formatter = new BinaryMessageFormatter();
                    EmailService.SendMail(emailid, msg.Body.ToString());

                    queue.ReceiveCompleted += new ReceiveCompletedEventHandler(msmqQueue_ReceiveCompleted);
                    queue.BeginReceive();
                    queue.Close();
                    con.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void msmqQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                MessageQueue queue = (MessageQueue)sender;
                Message msg = queue.EndReceive(e.AsyncResult);
                EmailService.SendMail(e.Message.ToString(), GenerateToken(e.Message.ToString()));
                queue.BeginReceive();
            }
            catch (MessageQueueException ex)
            {
                if (ex.MessageQueueErrorCode == MessageQueueErrorCode.AccessDenied)
                {
                    Console.WriteLine("Access is denied. " + "Queue might be a system queue.");
                }
                // Handle other sources of MessageQueueException.
            }
        }
        private static string GenerateToken(string email)
        {
            if (email == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("email", email)
                }),
                Expires = DateTime.UtcNow.AddHours(20),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        //Reset Password
        public void resetPassword(string EmailId, string Password)
        {
             try
              {
                using (SqlConnection con = new SqlConnection(connetionString))
                {
                    UserModel usermodel = new UserModel();
                        SqlCommand command = new SqlCommand("ResetPassword", con);
                        command.CommandType = CommandType.StoredProcedure;

                      command.Parameters.AddWithValue("@EmailId", EmailId);
                      command.Parameters.AddWithValue("@Password", Password);
                      con.Open();
                      command.ExecuteNonQuery();
                      con.Close();
                }
              }
              catch (Exception e)
              {
                  throw e;
              }
        }
    }
}
