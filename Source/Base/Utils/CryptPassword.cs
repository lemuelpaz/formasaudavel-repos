﻿using System.Security.Cryptography;
using System.Text;

namespace API.Source.Base.Utils
{
    public static class CryptPassword
    {
        public static string GerarHash(this string content)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(content);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}
