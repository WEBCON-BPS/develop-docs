using System;
using System.Text;
using System.Threading.Tasks;
using WebCon.WorkFlow.SDK.ActionPlugins;
using WebCon.WorkFlow.SDK.ActionPlugins.Model;
using WebCon.WorkFlow.SDK.Documents;
using WebCon.WorkFlow.SDK.Documents.Model;

namespace WebCon.BpsExt.Examples.CustomActions.StartNewDocument
{
    public class StartNewDocument : CustomAction<StartNewDocumentConfig>
    {

        StringBuilder _logger = new StringBuilder();
        public override async Task RunAsync(RunCustomActionParams args)
        {
            try
            {
                var manager = new DocumentsManager(args.Context);
                var newDocument = await GetNewDocumentAsync(manager);
                await SetFieldsAsync(newDocument);
                await StartNewWorkFlowAsync(newDocument, manager);
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
                args.Context.PluginLogger.AppendDebug(_logger.ToString());
            }
        }

        private async Task StartNewWorkFlowAsync(NewDocumentData newDocument, DocumentsManager manager)
        {
            _logger.AppendLine("Starting new document");
            var startNewWorkFlowParams = new StartNewWorkFlowParams()
            {
                DocumentToStart = newDocument,
                PathID = Configuration.StartPathId
            };
            await manager.StartNewWorkFlowAsync(startNewWorkFlowParams);
        }

        private async Task SetFieldsAsync(NewDocumentData newDocument)
        {
            _logger.AppendLine("Setting fields on new document");
            foreach (var field in Configuration.FieldsValues)
                await newDocument.SetFieldValueAsync(field.FieldId, field.Value);          
        }

        private async Task<NewDocumentData> GetNewDocumentAsync(DocumentsManager manager)
        {
            _logger.AppendLine("Getting new document");
            var getNewDocuemntParms = new GetNewDocumentParams()
            {
                DocTypeID = Configuration.TypeId,
                WorkFlowID = Configuration.WorkflowId
            };
            return await manager.GetNewDocumentAsync(getNewDocuemntParms);
        }
    }
}