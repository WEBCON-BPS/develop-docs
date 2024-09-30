using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using WebCon.WorkFlow.SDK.ActionPlugins;
using WebCon.WorkFlow.SDK.ActionPlugins.Model;
using WebCon.WorkFlow.SDK.Tools.Data;

namespace WebCon.BpsExt.Examples.CustomActions.SetItemList
{
    public class SetItemList : CustomAction<SetItemListConfig>
    {
        StringBuilder _logger = new StringBuilder();

        public override async Task RunAsync(RunCustomActionParams args)
        {
            try
            {
                var dt = await GetDataAsync(args.Context);
                await InsertIntoItemListAsync(dt, args.Context);
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


        private async Task<DataTable> GetDataAsync(ActionContextInfo context)
        {
            var sqlHelper = new SqlExecutionHelper(context);
            _logger.AppendLine("Executing sql query");
            var dt = await sqlHelper.GetDataTableForSqlCommandAsync(Configuration.SqlQuery);
            if (dt.Columns.Count == 3)
                return dt;

            throw new Exception("Sql query must return a table with exactly 3 columns");
        }

        private async Task InsertIntoItemListAsync(DataTable dt, ActionContextInfo context)
        {
            var itemList = context.CurrentDocument.ItemsLists.GetByID(Configuration.ItemListConfig.ItemListId);
            _logger.AppendLine("Inserting rows into item list");
            foreach (DataRow row in dt.Rows)
            {
                var listRow = await itemList.Rows.AddNewRowAsync();
                await listRow.SetCellValueAsync(Configuration.ItemListConfig.FirstColumnId, row[0]);
                await listRow.SetCellValueAsync(Configuration.ItemListConfig.SecondColumnId, row[1]);
                await listRow.SetCellValueAsync(Configuration.ItemListConfig.ThirdColumnId, row[2]);
            }
        }
    }
}