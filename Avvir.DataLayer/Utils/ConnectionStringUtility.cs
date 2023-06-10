using Avvir.DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avvir.DataLayer.Utils
{
    public class ConnectionStringUtility
    {
        //public static string GetSqlConnectionString(string fileName)
        //{
        //    var csBuilder = new EntityConnectionStringBuilder();

        //    csBuilder.Provider = "System.Data.SqlServer";
        //    csBuilder.ProviderConnectionString = string.Format("Data Source={0};", fileName);

        //    csBuilder.Metadata = string.Format("res://{0}/YourEdmxFileName.csdl|res://{0}/YourEdmxFileName.ssdl|res://{0}/YourEdmxFileName.msl",
        //        typeof(AvvirModel).Assembly.FullName);

        //    return csBuilder.ToString();
        //}

        public static string GetSqlConnectionString(string serverName, string databaseName)
        {
            SqlConnectionStringBuilder providerCs = new SqlConnectionStringBuilder();

            providerCs.DataSource = serverName;
            providerCs.InitialCatalog = databaseName;
            providerCs.IntegratedSecurity = false;
            providerCs.UserID = "Eugene";
            providerCs.Password = "Gesha73";

            var csBuilder = new EntityConnectionStringBuilder();

            csBuilder.Provider = "System.Data.SqlClient";
            csBuilder.ProviderConnectionString = providerCs.ToString();

            csBuilder.Metadata = string.Format("res://{0}/AvvirModel.csdl|res://{0}/AvvirModel.ssdl|res://{0}/AvvirModel.msl",
                typeof(AvvirModel).Assembly.FullName);

            return csBuilder.ToString();
        }
    }
}
