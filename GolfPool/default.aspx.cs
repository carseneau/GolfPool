using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GolfPool
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string path = System.Environment.GetEnvironmentVariable("PATH");
            Label1.Text = path;
          //  Tournament t = new Tournament("http://www.pgatour.com/tournaments/r016/results.html");

          // GridView1.DataSource =  t.getTournamentResults();
          //GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}