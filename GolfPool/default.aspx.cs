using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;
namespace GolfPool
{
    public partial class _default : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName == "craig-THINK")
            {
           SqlConnection conn = new SqlConnection("Server=12a5e980-74a4-4c94-a480-9fd70124ef10.sqlserver.sequelizer.com;Database=db12a5e98074a44c94a4809fd70124ef10;User ID=dsscpeteldbsyyzj;Password=4SXf82Dtu5m6YCGKykANoz4SuZqo53EBjr2rLHdpnwTQ7Wt8HztVDphBWeThKpxA;");

            }

            else
            {
                var uriString = ConfigurationManager.AppSettings["SQLSERVER_URI"];
                var uri = new Uri(uriString);
                var conn = new SqlConnectionStringBuilder
                {
                    DataSource = uri.Host,
                    InitialCatalog = uri.AbsolutePath.Trim('/'),
                    UserID = uri.UserInfo.Split(':').First(),
                    Password = uri.UserInfo.Split(':').Last(),

                }.ConnectionString;
            }             
        }

     
    }
}