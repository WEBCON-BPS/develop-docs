using WebCon.WorkFlow.SDK.Common;
using WebCon.WorkFlow.SDK.ConfigAttributes;

namespace WebCon.BpsExt.Examples.CustomActions.CopyAttachment
{
    public class CopyAttachmentConfig : PluginConfiguration
    {
        [ConfigEditableText("SQL query for attachment", Description = "SQL query returning the Id of the attachment to be copied", Multiline = true, TagEvaluationMode = EvaluationMode.SQL)]
        public string AttachmentIdQuery { get; set; }

        [ConfigEditableText("Sql query for target document", Description = "SQL query returning the Id of the document to which the attachment is to be added", Multiline = true, TagEvaluationMode = EvaluationMode.SQL)]
        public string DocumentIdQuery { get; set; }
    }
}