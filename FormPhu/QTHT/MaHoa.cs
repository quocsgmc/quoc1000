using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace QLHTDT.FormPhu.QTHT
{
    class MaHoa
    {
        //public static string Rot13(string input)
        //{
        //    StringBuilder result = new StringBuilder();
        //    Regex regex = new Regex("[A-Za-z]");
        //    foreach (char c in input)
        //    {
        //        if (regex.IsMatch(c.ToString()))
        //        {
        //            int charCode = ((c & 223) - 52) % 26 + (c & 32) + 65;
        //            result.Append((char)charCode);
        //        }
        //        else
        //        {
        //            result.Append(c);
        //        }
        //    }
        //    return result.ToString();
        //}
        public static string Rot13(string input)
        {
            byte[] toEncryptArray = Convert.FromBase64String(input);
            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();

            //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes("sgmc"));
            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
            //Assigning the Security key to the TripleDES Service Provider.
            objTripleDESCryptoService.Key = securityKeyArray;
            //Mode of the Crypto service is Electronic Code Book.
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            //Padding Mode is PKCS7 if there is any extra byte is added.
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();
            //Transform the bytes array to resultArray
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            objTripleDESCryptoService.Clear();

            //Convert and return the decrypted data/byte into string format.
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
