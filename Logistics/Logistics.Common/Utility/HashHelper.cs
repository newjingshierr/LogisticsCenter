using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Common
{
    public class HashHelper
    {
        public static byte[] ComputeHash(string pwd)
        {
            SHA1 sha = SHA1.Create();
            byte[] bytePassword = sha.ComputeHash(Encoding.Unicode.GetBytes(pwd));
            return bytePassword;
        }
    }
}
