using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUtils
{
    public class CryptoMaster
    {
        public static string Encrypt(string input)
        {
            using (var md = MD5.Create())
            {
                md.Initialize();
                var criptedData = md.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < criptedData.Length; i++)
                {
                    sBuilder.Append(criptedData[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}
