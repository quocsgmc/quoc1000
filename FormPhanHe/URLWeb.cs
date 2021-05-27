using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QLHTDT.FormPhanHe
{

    class URLWeb
    {
        //public static string URL = "http://42.116.21.5:3003/";
        public static string URL = "https://sxd.sgmcvietnam.vn/";
        public static string UserFTP = "anlth";
        public static string PassFTP = "Abc!12345678";
        public void LayURL(string URL)
        {
            FileStream fs = new FileStream(QLHTDT.Properties.Settings.Default.PathData, FileMode.Open);
            StreamReader read = new StreamReader(fs);
            URL = read.ReadLine();
            read.Close();
        }
    }
}
