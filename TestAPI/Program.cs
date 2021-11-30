using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using Xceed.Wpf.Toolkit;

namespace TestAPI
{
    public class Program
    {
        static void Main(string[] args)
        {
            string response = MakeRequest();
            File.WriteAllText(@"C:\TestApi\json.txt", response);
            //Root usersSearch = JsonConvert.DeserializeObject<Root>(response);
            //MessageBox.Show(usersSearch.name[0].ToString(), "result");
        }
        public static string MakeRequest()
        {
            string responseBody = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://jsonplaceholder.typicode.com/users"); //какие параметры
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader r = new StreamReader(s))
                {
                    responseBody = r.ReadToEnd();
                }
            }
            return responseBody;
        }
        public static string MakeRequestPost()
        {
            string responseBody = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://jsonplaceholder.typicode.com/users"); //какие параметры
            request.Method = "POST";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (Stream st = request.GetRequestStream())
            {
                using (StreamWriter wr = new StreamWriter(st))
                {
                    wr.Write("Hello!");
                }
            }
            return responseBody;
        }

        public static string MakeRequestPost2()
        {
            string responseBody = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://jsonplaceholder.typicode.com/users"); //какие параметры
            request.Method = "POST";

            byte[] byteArr = Encoding.ASCII.GetBytes("");
            request.GetRequestStream().Write(byteArr, 0, byteArr.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader r = new StreamReader(s))
                {
                    responseBody = r.ReadToEnd();
                }
            }
            return responseBody;
        }
    }
}
