﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTools
{
    public static class Hash256
    {
        public static string HashOfUserPassword(string password)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(password));

                foreach (Byte b in result)
                {
                    Sb.Append(b.ToString("x2"));
                }
            }

            return Sb.ToString();
        }
    }
}
