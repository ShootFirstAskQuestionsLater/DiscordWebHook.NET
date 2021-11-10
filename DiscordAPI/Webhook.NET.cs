using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace DiscordWebhook.NET
{
    public class Webhookdotnet
    {
        public static void SendMessage()
        {
            if (!Exists()) {
                var Data = $"{{\"username\":\"{Settings.Username}\",\"content\":\"{Settings.Message}\",\"avatar_url\":\"{Settings.ProfilePicture}\"}}";
                var Client = (HttpWebRequest)WebRequest.Create(Settings.WebHookURL);
                Client.ContentLength = Data.Length;
                Client.ContentType = "application/json";
                Client.Method = "POST";
                using (var Stream = Client.GetRequestStream())
                    Stream.Write(Encoding.UTF8.GetBytes(Data), 0, Data.Length);
                Client.GetResponse(); //Credits to Laxion for some of this part
            }
        }
        public async Task DeleteWebHookAsync() {
            using (var Client = new HttpClient())
            {
                await Client.DeleteAsync(Settings.WebHookURL);
            }
        }
        public static bool Exists() {
            if (!(Settings.WebHookURL == null)) {
                try
                {
                    var httpClient = new HttpClient().GetAsync(Settings.WebHookURL);
                    return true;
                }
                catch (Exception) {
                    return false;
                }
            }
            return false;
        }
    }
}