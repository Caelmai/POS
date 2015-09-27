using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApp.DataManagers
{
    public class DataManager
    {

        protected Lazy<string> ConnectionString = new Lazy<string>(() => ConfigurationManager.ConnectionStrings["MDF"].ConnectionString);

    }
}