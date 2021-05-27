using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace QLHTDT.FormPhu.QTHT
{
    class GetMD5
    {
        public static string Connectdatabase = "";
        public GetMD5(string chuoi)
        {
            Connectdatabase = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(chuoi);
            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                Connectdatabase += b.ToString("X2");
            }
        }
    }
}
