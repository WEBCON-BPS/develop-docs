using WebCon.WorkFlow.SDK.Common;
using WebCon.WorkFlow.SDK.ConfigAttributes;

namespace WebCon.BPS.HelloWorld.SDK
{
    public class WebServiceCallActionConfig : PluginConfiguration
    {
        // Configurable properties - properties that can be 
        // configured in BPS Desinger Studio in the action configuration form
        [ConfigEditableText(
            DisplayName = "WebserviceURL",
            Description = "URL of vacation webservice",
            IsRequired = true)]
        public string WebServiceUrl { get; set; }               // URL to Vacation webservice
    }
}