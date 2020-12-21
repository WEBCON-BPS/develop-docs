using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebCon.BPS.Sample.RestAPI
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PatchAsync(this HttpClient httpClient, string requestPath, HttpContent content)
        {
            return httpClient.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), requestPath)
            {
                Content = content
            });
                
        }
    }
}
