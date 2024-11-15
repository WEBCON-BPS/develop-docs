using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebCon.WorkFlow.SDK.AutenticationPlugins;
using WebCon.WorkFlow.SDK.AutenticationPlugins.Model;

namespace WebCon.BpsExt.Examples.CustomAuthentications.RestAuthentication
{
    public class RestAuthenticationExample : CustomRESTAuthentication<RestAuthenticationExampleConfig>
    {
        public override Task<HttpClient> CreateAuthenticatedClientAsync(CustomRestAuthenticationParams customAuthenticationParams)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("ApiKey", Configuration.ApiKey);
            return Task.FromResult(client);
        }
    }
}