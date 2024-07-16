using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCon.WorkFlow.SDK.ActionPlugins;
using WebCon.WorkFlow.SDK.ActionPlugins.Model;
using WebCon.WorkFlow.SDK.Documents;
using WebCon.WorkFlow.SDK.Documents.Model;
using WebCon.WorkFlow.SDK.Tools.Data;

namespace WebCon.BpsExt.AdvancedExamples.CustomActions.UpdateMultipleDocumentsOnCycle
{
    public class UpdateMultipleDocumentsOnCycle : CustomAction<UpdateMultipleDocumentsOnCycleConfig>
    {
        public override ActionTriggers AvailableActionTriggers => ActionTriggers.Recurrent;
        StringBuilder _logger = new StringBuilder();

        public override async Task RunWithoutDocumentContextAsync(RunCustomActionWithoutContextParams args)
        {        
            try
            {
                var updateData = await GetUpdateDataAsync(args.Context);
                await UpdateDocumentsAsync(updateData, args.Context);
            }
            catch (Exception ex)
            {
                args.HasErrors = true;
                args.Message = ex.Message;
                _logger.AppendLine(ex.ToString());
            }
            finally
            {
                args.LogMessage = _logger.ToString();
                args.Context.PluginLogger.AppendInfo(_logger.ToString());
            }
        }

        private async Task UpdateDocumentsAsync(List<UpdateData> updateData, ActionWithoutDocumentContext context)
        {
            _logger.AppendLine("Updating documents");
            var documentsManager = new DocumentsManager(context);
            foreach (var data in updateData)
            {
                var doc = await documentsManager.GetDocumentByIdAsync(data.DocumentId, true);
                doc.SetFieldValue(Configuration.FieldId, data.Value);
                await documentsManager.UpdateDocumentAsync(new UpdateDocumentParams(doc) { SkipPermissionsCheck = true });
            }
        }

        private async Task<List<UpdateData>> GetUpdateDataAsync(ActionWithoutDocumentContext context)
        {
            _logger.AppendLine("Executing sql query");
            var sqlHelper = new SqlExecutionHelper(context);
            var dt = await sqlHelper.GetDataTableForSqlCommandAsync(Configuration.SqlQuery);
            return dt.Rows.Cast<DataRow>()
                .Select(x => new UpdateData(){
                   DocumentId = x.Field<int>("WfdId"),
                   Value = x.Field<object>("Value") }).ToList();
        }
    }


    public class UpdateData
    {
        public int DocumentId { get; set; }
        public object Value { get; set; }
    }
}