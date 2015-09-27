using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Models;
using WebApp.DataManagers;
using WebApp.DTO;

namespace Web.Controllers
{
    public class ClientListController : Controller
    {
        //
        // GET: /ClientList/

        private const string ADMIN = "admin@sellseverything.com";

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }

            string currentUser = User.Identity.Name;

            List<ClientDTO> clients = null;
            if (currentUser == ADMIN)
            {
                clients = ClientDataManager.Instance.GetAllClients();
            }
            else
            {
                clients = ClientDataManager.Instance.GetClients(currentUser);
            }

            ClientListModel model = new ClientListModel() { Clients = clients, ShowSeller = currentUser == ADMIN };

            return View(model);
        }
    }
}
