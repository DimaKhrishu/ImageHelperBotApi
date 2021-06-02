using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Metadata;
using ConvertApiDotNet;
using System.Net.Http;
using ConvertApiDotNet.Model;

namespace ImageHelperBot.Clients
{
    public class JpgToPdf
    {
        public static string url;
      
     
        public async Task<String> ConvertPdf(string url)
        {
            var sourceFile = new Uri(url);

            
            var convertApi = new ConvertApi(Constants.apiKey2);
           

            var result = await convertApi.ConvertAsync("jpg", "pdf",new ConvertApiFileParam(sourceFile));
            
            var saveInfo = result.Files[0].Url;
            var r = saveInfo.AbsoluteUri;
            return r;
            

        }

        
    }
}
