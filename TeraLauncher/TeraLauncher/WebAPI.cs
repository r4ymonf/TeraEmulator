using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace TeraLauncher
{
    public class WebAPI
    {
        public static bool isLoggedIn = false;
        public double coins = 0;

        public UserData user;

        public string webApiUrl = "http://localhost/tera/webapi.php";

        public static T _login_Callback<T>(string url, string lg, string ps) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                try
                {
                    url = string.Format("{0}?action=login" +
                        "&username={1}" +
                        "&password={2}",
                        url, lg, ps);
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

        public static T _register_Callback<T>(string url, string lg, string ps, string rps, string em) where T : new()
        {
            using( var w = new WebClient())
            {
                var json_data = string.Empty;
                try
                {
                    url = string.Format("{0}?action=register"+
                        "&username={1}"+
                        "&password={2}"+
                        "&rpassword={3}"+
                        "&email={4}",
                        url, lg, ps, rps, em );
                    json_data = w.DownloadString(url);
                }
                catch(Exception){ }
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
    }
}
