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
        	System.Configuration.Configuration rootWebConfig =	System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
			System.Configuration.ConnectionStringSettings connString;
			
       

        protected void Page_Load(object sender, EventArgs e)
        {
             if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
			{
				connString =
					rootWebConfig.ConnectionStrings.ConnectionStrings["sequelizer"];
				if (connString != null)
					Console.WriteLine("sequelizer connection string = \"{0}\"",
						connString.ConnectionString);
				else
					Console.WriteLine("No sequelizer connection string");
			}

            SqlConnection conn = new SqlConnection(connString.ConnectionString);

          
           
           SqlCommand cmd = new SqlCommand("select entrantname,SUM(winnings) as winnings from entrants "
           + "left outer join picks on entrants.entrantid = picks.entrantid "
           + "left outer join golfers on picks.golferid = golfers.golferid "
           + "left outer join winnings on golfers.golferid = winnings.golferid "
           + "group by entrantname "
           + "order by winnings desc",conn);

           
                conn.Open();
                
                GridView1.DataSource = cmd.ExecuteReader();
                
           GridView1.DataBind();
           conn.Close();

          
                cmd.CommandText = "select entrantname,golfername,tournamentname,winnings from entrants "
+ "left outer join picks on entrants.entrantid = picks.entrantid "
+ "left outer join golfers on picks.golferid = golfers.golferid "
+ "left outer join winnings on golfers.golferid = winnings.golferid "
+ "left outer join tournaments on winnings.tournamentid = tournaments.tournamentid "
+ "order by entrantname,winnings desc,golfername";
                conn.Open();
                GridView2.DataSource = cmd.ExecuteReader();
                GridView2.DataBind();
                conn.Close();
         
        }

     
    }
}