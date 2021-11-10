using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordWebhook;
using DiscordWebhook.NET;

namespace DiscordAPI
{
    class Example
    {
        public static void test() {
            Settings.ProfilePicture = new Uri("https://c.tenor.com/6-uK_RL-54YAAAAC/devious-lick-diabolical.gif");
            Settings.Message = "Hello, World!";
            Settings.Username = "Test";
            Settings.WebHookURL = new Uri("webhook link");
            DiscordWebhookdotNET.Webhookdotnet.SendMessage();
            DiscordWebhookdotNET.Webhookdotnet.DeleteWebHookAsync();
        }     
    }
}
