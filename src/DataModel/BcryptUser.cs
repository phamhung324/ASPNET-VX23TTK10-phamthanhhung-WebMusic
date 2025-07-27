using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MusicViet.DataModel
{
    public class BcryptUser
    {
        public static string EncryptMd5(string data)
        {
            MD5CryptoServiceProvider myMD5 = new MD5CryptoServiceProvider();
            byte[] b = System.Text.Encoding.UTF8.GetBytes(data);
            b = myMD5.ComputeHash(b);

            StringBuilder s = new StringBuilder();
            foreach (byte p in b)
            {
                s.Append(p.ToString("x").ToLower());
            }
            return s.ToString();
        }
    }
}