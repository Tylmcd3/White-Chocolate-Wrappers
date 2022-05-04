using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace KIT206.DatabaseApp
{

    public abstract class PhotoUpload
    {
        private const string CLIENT_ID = "7abc688878dfc55";
        private const string CLIENT_SECRET = "cf29cd4982839879fe03e4d57f2ec7a6613dece8";
        private static string refresh_token = "31b732a968166f9a6511c4b366be7e015cd5a020";
        private static string access_token = "7213fa1c2aeee2bbb25f7e71915fbe845011b1cce";

        public static void GetNewAccessTokensAsync()
        {
            string url = "https://api.imgur.com/oauth2/token";
            var request = (HttpWebRequest)WebRequest.Create(url);

            var postData = "refresh_token=" + Uri.EscapeDataString(refresh_token);
            postData += "&client_id=" + Uri.EscapeDataString(CLIENT_ID);
            postData += "&client_secret=" + Uri.EscapeDataString(CLIENT_SECRET);
            postData += "&grant_type=" + Uri.EscapeDataString("refresh_token");
            var data = Encoding.ASCII.GetBytes(postData);

            using (var client = new HttpClient())
            {
                using (var multipartFormDataContent = new MultipartFormDataContent())
                {
                    var values = new[]
                    {
                        new KeyValuePair<string,string>("refresh_token", refresh_token),
                        new KeyValuePair<string,string>("client_id", CLIENT_ID),
                        new KeyValuePair<string,string>("client_secret", CLIENT_SECRET),
                        new KeyValuePair<string,string>("grant_type", "refresh_token")

                    };
                    foreach (var keyValuePair in values)
                    {
                        multipartFormDataContent.Add(new StringContent(keyValuePair.Value), String.Format("\"{0}\"", keyValuePair.Key));
                    }

                    string text = ExecuteAsync(url, multipartFormDataContent, client).Result;

                    string newString = text.Substring(2, text.Length - 2);

                    string removableChars = Regex.Escape("\"");
                    string pattern = "[" + removableChars + "]";

                    newString = Regex.Replace(newString, pattern, "");

                    Dictionary<string, string> responseDict = newString.Split(',').Select(value => value.Split(':')).ToDictionary(pair => pair[0], pair => pair[1]);

                    refresh_token = responseDict["refresh_token"];
                    access_token = responseDict["access_token"];
                }
            }
        }

        public static async Task<string> ExecuteAsync(string url, MultipartFormDataContent multipartFormDataContent, HttpClient client)
        {
            var result = client.PostAsync(url, multipartFormDataContent).Result;

            string text = await result.Content.ReadAsStringAsync();
            return text;
        }

        public static string UploadImage(string ImageDir, int id)
        {
            GetNewAccessTokensAsync();
            byte[] imageArray = File.ReadAllBytes(ImageDir);
            string base64Image = Convert.ToBase64String(imageArray);
            ByteArrayContent baContent = new ByteArrayContent(imageArray);
            string url = "https://api.imgur.com/3/upload";
            var request = (HttpWebRequest)WebRequest.Create(url);


            using (var client = new HttpClient())
            {
                using (var multipartFormDataContent = new MultipartFormDataContent())
                {
                    multipartFormDataContent.Add(baContent, String.Format("\"{0}\"", "image"), Path.GetFileName(ImageDir));

                    string text = ExecuteAsync(url, multipartFormDataContent, client).Result;


                    var values = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(text);
                    int a = 1 + 1;
                    var json = values["data"].GetRawText();
                    values = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(json);

                    return values["link"].GetRawText();
                }
            }
        }
    }
}