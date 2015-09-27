using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApp.DTO;

namespace WebApp.DataManagers
{
    public class LoginDataManager : DataManager
    {
        private LoginDataManager()
        {
        }

        private static Lazy<LoginDataManager> _instance = new Lazy<LoginDataManager>(() => new LoginDataManager());
        public static LoginDataManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }


        public const string GET_USER = "select Email,Name,UserId,Password from [User] where email = @email";

        public LoginResponse CheckPassword(string email, string password)
        {
            LoginResponse response = new LoginResponse() { Success = false, UserNotFound = false, WrongPassword = false };

            var user = GetUserByEmail(email);

            if (user == null)
            {
                response.UserNotFound = true;
                return response;
            }

            if (user.Password != password)
            {
                response.WrongPassword = true;
                return response;
            }

            response.Success = true;

            return response;
        }



        public UserDTO GetUserByEmail(string email)
        {
            string connectionString = ConnectionString.Value;

            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(GET_USER);
                cmd.Connection = connection;

                cmd.Parameters.AddWithValue("@email", email);

                connection.Open();

                var resp = cmd.ExecuteReader();

                if (!resp.HasRows)
                {
                    return null;
                }

                resp.Read();

                UserDTO dto = new UserDTO();
                dto.Email = resp.GetString(0);
                dto.Name = resp.GetString(1);
                dto.UserId = resp.GetGuid(2);
                dto.Password = resp.GetString(3);

                return dto;
            }
        }

        public static void Test()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MDF"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(GET_USER);
                cmd.Connection = connection;

                cmd.Parameters.AddWithValue("@email", "admin@sellseverything.com");

                connection.Open();

                var resp = cmd.ExecuteReader();
            }
        }
    }

    public class LoginResponse
    {
        public LoginResponse()
        {
        }

        public bool Success { get; set; }
        public bool UserNotFound { get; set; }
        public bool WrongPassword { get; set; }
    }
}