using System;
using System.Text;
using System.Threading.Tasks;
using WebCon.WorkFlow.SDK.ActionPlugins;
using WebCon.WorkFlow.SDK.ActionPlugins.Model;
using WebCon.WorkFlow.SDK.Common.Model;
using WebCon.WorkFlow.SDK.Documents;
using WebCon.WorkFlow.SDK.Documents.Model.Attachments;
using WebCon.WorkFlow.SDK.Tools.Data;

namespace WebCon.BpsExt.Examples.CustomActions.CopyAttachment
{
    public class CopyAttachment : CustomAction<CopyAttachmentConfig>
    {
        StringBuilder _logger = new StringBuilder();
        public override async Task RunAsync(RunCustomActionParams args)
        {
            try
            {
                var attachmentId = await GetExistingAttachmentId(args.Context);
                var targetDocumentId = await GetTargetDocumentId(args.Context);
                await AddAttachmentToDocument(attachmentId, targetDocumentId, args.Context);
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

        private async Task AddAttachmentToDocument(int attachmentId, int targetDocumentId, BaseContext context)
        {
            var attachmentManager = new DocumentAttachmentsManager(context);
            var existingAttachment = await attachmentManager.GetAttachmentAsync(attachmentId);
            var addAttachmentParams = new AddAttachmentParams()
            {
                Attachment = existingAttachment,
                DocumentId = targetDocumentId,
            };
            await attachmentManager.AddAttachmentAsync(addAttachmentParams);
        }

        private async Task<int> GetExistingAttachmentId(BaseContext context)
        {
            _logger.AppendLine("Getting attachment id");
            return await ExecuteQueryAsync(Configuration.AttachmentIdQuery, context);
        }

        private async Task<int> GetTargetDocumentId(BaseContext context)
        {
            _logger.AppendLine("Getting target document id");
            return await ExecuteQueryAsync(Configuration.DocumentIdQuery, context);
        }

        private async Task<int> ExecuteQueryAsync(string query, BaseContext context)
        {
            var sqlHelper = new SqlExecutionHelper(context);
            _logger.AppendLine($"Executing query {query}");
            var result = await sqlHelper.ExecSqlCommandScalarAsync(query);

            if(result != null && Int32.TryParse(result.ToString(), out var id))
                return id;

            throw new Exception($"Value returned from query is not valid. Value: {result}");
        }
    }
}