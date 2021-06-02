using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Drawing.Printing;
using OpenQA.Selenium.Remote;
using Ubiety.Dns.Core;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ImageHelperBot.Clients
{
    public class BackgroundRemove
    {
        
        public static string url;
        private HttpClient _client;
        private MultipartFormDataContent formData;
      

        public BackgroundRemove()
        {
             _client = new HttpClient();
            formData = new MultipartFormDataContent();
        }
        public async Task<Stream> RemoveBg(string url)
        {
            formData.Headers.Add("X-Api-Key", Constants.apiKey);
            formData.Add(new StringContent(url), "image_url");
            
            formData.Add(new StringContent("auto"), "size");
            var response = await _client.PostAsync("https://api.remove.bg/v1.0/removebg", formData);
            var result = await response.Content.ReadAsStreamAsync();

            if (response.IsSuccessStatusCode)
            {
                
                return result;
            }
            else
            {
                return null;
            }

        }
    }

    
    
}
