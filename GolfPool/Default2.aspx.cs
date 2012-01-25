using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace GolfPool
{
    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=12a5e980-74a4-4c94-a480-9fd70124ef10.sqlserver.sequelizer.com;Database=db12a5e98074a44c94a4809fd70124ef10;User ID=dsscpeteldbsyyzj;Password=4SXf82Dtu5m6YCGKykANoz4SuZqo53EBjr2rLHdpnwTQ7Wt8HztVDphBWeThKpxA;");
            SqlCommand cmd = new SqlCommand("select RANK() OVER (ORDER BY SUM(winnings) DESC) as entrantrank, entrantname,SUM(winnings) as winnings from entrants left outer join picks on entrants.entrantid = picks.entrantid left outer join golfers on picks.golferid = golfers.golferid left outer join winnings on golfers.golferid = winnings.golferid group by entrantname order by winnings desc", conn);


            conn.Open();

            RadGrid1.DataSource = cmd.ExecuteReader();

            RadGrid1.DataBind();
            conn.Close();
        }
    }
}