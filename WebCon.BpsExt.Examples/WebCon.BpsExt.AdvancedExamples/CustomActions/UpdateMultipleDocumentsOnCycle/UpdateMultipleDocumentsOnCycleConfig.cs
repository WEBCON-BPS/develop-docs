using WebCon.WorkFlow.SDK.Common;
using WebCon.WorkFlow.SDK.ConfigAttributes;

namespace WebCon.BpsExt.AdvancedExamples.CustomActions.UpdateMultipleDocumentsOnCycle
{
    public class UpdateMultipleDocumentsOnCycleConfig : PluginConfiguration
    {
        [ConfigEditableText("Sql query", Description = @"Sql query returning two columns: ""WfdId"" with id of document and ""Value"" with the value of the attribute value to be inserted", Multiline =true, TagEvaluationMode = EvaluationMode.SQL)]
        public string SqlQuery { get; set; }

        [ConfigEditableFormFieldID("Field", "Field into which the value returned from the SQL query is to be inserted")]
        public int FieldId { get; set; }
    }
}