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
using Telerik.Web.UI;
namespace GolfPool
{
    public partial class _default : System.Web.UI.Page
    {

        RadGrid rg;
        

        protected void Page_Load(object sender, EventArgs e)
        {

            rg = new RadGrid();
            rg.Visible = true;

            if (System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName == "craig-THINK")
            {
           SqlConnection conn = new SqlConnection("Server=12a5e980-74a4-4c94-a480-9fd70124ef10.sqlserver.sequelizer.com;Database=db12a5e98074a44c94a4809fd70124ef10;User ID=dsscpeteldbsyyzj;Password=4SXf82Dtu5m6YCGKykANoz4SuZqo53EBjr2rLHdpnwTQ7Wt8HztVDphBWeThKpxA;");
           SqlCommand cmd = new SqlCommand("select entrantname,SUM(winnings) as winnings from entrants "
           + "left outer join picks on entrants.entrantid = picks.entrantid "
           + "left outer join golfers on picks.golferid = golfers.golferid "
           + "left outer join winnings on golfers.golferid = winnings.golferid "
           + "group by entrantname "
           + "order by winnings desc",conn);

           
                conn.Open();
                
                RadGrid1.DataSource = cmd.ExecuteReader();
                
           RadGrid1.DataBind();
           conn.Close();

          
                cmd.CommandText = "select entrantname,golfername,tournamentname,winnings from entrants "
+ "left outer join picks on entrants.entrantid = picks.entrantid "
+ "left outer join golfers on picks.golferid = golfers.golferid "
+ "left outer join winnings on golfers.golferid = winnings.golferid "
+ "left outer join tournaments on winnings.tournamentid = tournaments.tournamentid "
+ "order by entrantname,winnings desc,golfername";
                conn.Open();
               // GridView2.DataSource = cmd.ExecuteReader();
               // GridView2.DataBind();
                conn.Close();
            }

            else
            {
                var uriString = ConfigurationManager.AppSettings["SQLSERVER_URI"];
                var uri = new Uri(uriString);
                var connectionString = new SqlConnectionStringBuilder
                {
                    DataSource = uri.Host,
                    InitialCatalog = uri.AbsolutePath.Trim('/'),
                    UserID = uri.UserInfo.Split(':').First(),
                    Password = uri.UserInfo.Split(':').Last(),

                }.ConnectionString;

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("select entrantname,SUM(winnings) as winnings from entrants "
+ "left outer join picks on entrants.entrantid = picks.entrantid "
+ "left outer join golfers on picks.golferid = golfers.golferid "
+ "left outer join winnings on golfers.golferid = winnings.golferid "
+ "group by entrantname "
+ "order by winnings desc",conn);


                conn.Open();

                RadGrid1.DataSource = cmd.ExecuteReader();

                RadGrid1.DataBind();
                conn.Close();


                cmd.CommandText = "select entrantname,golfername,tournamentname,winnings from entrants "
+ "left outer join picks on entrants.entrantid = picks.entrantid "
+ "left outer join golfers on picks.golferid = golfers.golferid "
+ "left outer join winnings on golfers.golferid = winnings.golferid "
+ "left outer join tournaments on winnings.tournamentid = tournaments.tournamentid "
+ "order by entrantname,winnings desc,golfername";
                conn.Open();
              //  GridView2.DataSource = cmd.ExecuteReader();
              //  GridView2.DataBind();
                conn.Close();
            }             
        }

     
    }
}