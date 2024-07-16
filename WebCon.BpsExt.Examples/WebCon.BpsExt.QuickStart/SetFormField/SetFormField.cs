using System;
using System.Text;
using System.Threading.Tasks;
using WebCon.WorkFlow.SDK.ActionPlugins;
using WebCon.WorkFlow.SDK.ActionPlugins.Model;

namespace WebCon.BpsExt.QuickStart.SetFormField
{
    public class SetFormField : CustomAction<SetFormFieldConfig>
    {
        StringBuilder _logger = new StringBuilder();
        public override Task RunAsync(RunCustomActionParams args)
        {
            try
            {
                _logger.Append($"Getting field with id {Configuration.FieldId}");
                var field = args.Context.CurrentDocument.Fields.GetByID(Configuration.FieldId);

                _logger.Append($"Setting the {field.DisplayName} field with the value: {Configuration.Value}");
                field.SetValue(Configuration.Value);
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
            return Task.CompletedTask;
        }
    }
}