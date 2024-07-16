using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebCon.WorkFlow.SDK.Common.Model;
using WebCon.WorkFlow.SDK.DataSourcePlugins;
using WebCon.WorkFlow.SDK.DataSourcePlugins.Model;

namespace WebCon.BpsExt.QuickStart.CustomDataSourceExample
{
    public class CustomDataSourceExample : CustomDataSource<CustomDataSourceExampleConfig>
    {
        public override Task<List<DataSourceColumn>> GetColumnsAsync()
        {
            return Task.FromResult(new List<DataSourceColumn>() {
                new DataSourceColumn("ID"),
                new DataSourceColumn("Name"),
                new DataSourceColumn("Surname"),
                new DataSourceColumn("Address")
            });
        }

        public override async Task<DataTable> GetDataAsync(SearchConditions searchConditions)
        {
            var dt = await GetDataAsync();
            return dt;
        }

        private async Task<DataTable> GetDataAsync()
        {
            var dt = await CreateTableAsync();
            AddRowsToTable(dt);
            return dt;         
        }

        private void AddRowsToTable(DataTable dt)
        {
            foreach (var user in users)
            {
                var row = dt.NewRow();
                row["ID"] = user.Id;
                row["Name"] = user.Name;
                row["Surname"] = user.Surname;
                row["Address"] = user.Address;
                dt.Rows.Add(row);
            }
        }
           

        private async Task<DataTable> CreateTableAsync()
        {
            var dt = new DataTable();
            foreach (var column in await GetColumnsAsync())
                dt.Columns.Add(column.Name);

            return dt;
        }

        private List<(int Id, string Name, string Surname, string Address)> users = new List<(int Id, string Name, string Surname, string Address)>()
        {
             (1, "John", "Smith", "Address1"),
             (2, "Jan", "Kowalski", "Address2"),
             (3, "Hans", "Schmidt", "Address3"),
        };
    }
}