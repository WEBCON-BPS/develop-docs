using WebCon.WorkFlow.SDK.Common;
using WebCon.WorkFlow.SDK.ConfigAttributes;

namespace WebCon.BpsExt.Examples.CustomAuthentications.DatabaseAuthentication
{
    public class DBAuthenticationExampleConfig : PluginConfiguration
    {
        [ConfigEditableText("Connection string")]
        public string ConnectionString { get; set; }
    }
}