using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace EnglishTest.DownloadingToDB
{
    public static class HTML
    {
        public static string GetHTML(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "My application name";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default, true, 8192))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
