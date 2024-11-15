using WebCon.WorkFlow.SDK.Common;
using WebCon.WorkFlow.SDK.ConfigAttributes;

namespace WebCon.BpsExt.Examples.CustomAuthentications.RestAuthentication
{
    public class RestAuthenticationExampleConfig : PluginConfiguration
    {
        [ConfigEditableText("Api Key")]
        public string ApiKey { get; set; }
    }
}