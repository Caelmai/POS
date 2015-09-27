using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.DTO;

namespace Web.Models
{
    public class ClientListModel
    {
        public List<ClientDTO> Clients;

        public bool ShowSeller;
    }
}