using ProjectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DataManagers;

namespace DBTest
{
    public class Program
    {
        static void Main(string[] args)
        {

            //LoginDataManager.Test();
            //var resp = CryptoMaster.Encrypt("admin123");
            var x = LoginDataManager.Instance.GetUserByEmail("admin@sellseverything.com");
        }
    }
}
