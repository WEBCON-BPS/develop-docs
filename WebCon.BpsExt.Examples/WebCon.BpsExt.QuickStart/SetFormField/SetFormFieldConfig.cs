using WebCon.WorkFlow.SDK.Common;
using WebCon.WorkFlow.SDK.ConfigAttributes;

namespace WebCon.BpsExt.QuickStart.SetFormField
{
    public class SetFormFieldConfig : PluginConfiguration
    {
        [ConfigEditableFormFieldID("Field to set", IsRequired = true)]
        public int FieldId { get; set; }

        [ConfigEditableText("Value to set")]
        public string Value { get; set; }
    }
}