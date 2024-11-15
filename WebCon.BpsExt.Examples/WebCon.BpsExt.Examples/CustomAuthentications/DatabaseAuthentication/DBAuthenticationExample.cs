using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using WebCon.WorkFlow.SDK.AutenticationPlugins;

namespace WebCon.BpsExt.Examples.CustomAuthentications.DatabaseAuthentication
{
    public class DBAuthenticationExample : CustomDatabaseAuthentication<DBAuthenticationExampleConfig>
    {
        public override Task<string> CreateConnectionStringAsync()
        {
            var builder = new SqlConnectionStringBuilder(Configuration.ConnectionString);
            builder.Password = "new@1Password";
            builder.Authentication = SqlAuthenticationMethod.ActiveDirectoryPassword;
            return Task.FromResult(builder.ConnectionString);
        }
    }
}