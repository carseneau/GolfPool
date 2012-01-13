using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GolfPool
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Tournament t = new Tournament("C:\\Users\\craig\\Documents\\Visual Studio 2010\\Libraries\\Selenium", "http://www.pgatour.com/tournaments/r016/results.html");
            DataTable dt = new DataTable("tresults");
            dt = t.getTournamentResults();
           

        }

        protected void btnUpdateAllTournaments_Click(object sender, EventArgs e)
        {

        }


        
    }
}