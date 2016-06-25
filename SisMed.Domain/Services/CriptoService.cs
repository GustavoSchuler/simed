using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Domain.Services
{
    public class CriptoService
    {
        public static string Sha1(string senha)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(senha);

            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            return BitConverter.ToString(sha1.ComputeHash(bytes)).Replace("-", "");
        }
    }
}
