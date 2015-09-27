using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApp.DTO;

namespace WebApp.DataManagers
{
    public class ClientDataManager : DataManager
    {
        private ClientDataManager()
        {
        }

        private static Lazy<ClientDataManager> _instance = new Lazy<ClientDataManager>(() => new ClientDataManager());
        public static ClientDataManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public static string FILTER_BY_USER = " where Email = @seller";

        public static string GET_CLIENTS = "select * from ClientList";


        private List<ClientDTO> GetClients(string user, bool filter)
        {
            var resp = new List<ClientDTO>();

            string command = GET_CLIENTS;

            string connectionString = ConnectionString.Value;

            using (var connection = new SqlConnection(connectionString))
            {
                if (filter)
                {
                    command += FILTER_BY_USER;
                }

                var cmd = new SqlCommand(command);
                cmd.Connection = connection;
                
                if (filter)
                {
                    cmd.Parameters.AddWithValue("@seller", user);
                }

                connection.Open();

                var data = cmd.ExecuteReader();

                if (!data.HasRows)
                {
                    return resp;
                }

                while (data.Read())
                {
                    ClientDTO dto = new ClientDTO();
                    dto.Classification = data.GetString(0);
                    dto.Name = data.GetString(1);
                    dto.Phone = data.GetString(2);
                    dto.Gender = data.GetString(3);
                    dto.City = data.GetString(4);
                    dto.Region = data.GetString(5);
                    dto.LastPurchase = data.GetDateTime(6).ToShortDateString();
                    dto.Seller = data.GetString(7);
                    resp.Add(dto);
                }
            }

            return resp;
        }

        public List<ClientDTO> GetClients(string user)
        {
            return GetClients(user, true);
        }
        public List<ClientDTO> GetAllClients()
        {
            return GetClients(null, false);
        }
    }
}