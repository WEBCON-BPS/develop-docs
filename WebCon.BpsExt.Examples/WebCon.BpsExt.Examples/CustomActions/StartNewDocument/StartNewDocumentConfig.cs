using System.Collections.Generic;
using WebCon.WorkFlow.SDK.Common;
using WebCon.WorkFlow.SDK.ConfigAttributes;

namespace WebCon.BpsExt.Examples.CustomActions.StartNewDocument
{
    public class StartNewDocumentConfig : PluginConfiguration
    {
        [ConfigEditableText("Workflow Id", Description = "Id of the workflow in which the new docuemnt is to be started", IsRequired = true)]
        public int WorkflowId { get; set; }

        [ConfigEditableText("Document type Id", IsRequired = true)]
        public int TypeId { get; set; }

        [ConfigEditableText("Start path Id", IsRequired = true)]
        public int StartPathId { get; set; }

        [ConfigEditableGrid("Fields to set", Description = "Id of the field and the value to be written to it")]
        public List<FieldValue> FieldsValues { get; set; }
    }


    public class FieldValue
    {
        [ConfigEditableGridColumnFormFieldID("Field", IsRequired = true)]
        public int FieldId { get; set; }

        [ConfigEditableGridColumn("Value", IsRequired = true)]
        public string Value { get; set; }
    }
}