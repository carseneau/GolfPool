using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace GolfPool
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                      

            foreach(string d in Directory.GetDirectories(MapPath("/")))
            {
                Response.Write("dirs: " + d + "<br>");
            }

            
        Tournament t = new Tournament("http://www.pgatour.com/tournaments/r016/results.html",MapPath("/FirefoxPortable/") + "FirefoxPortable.exe",MapPath("/FirefoxPortable/App/DefaultData/profile/"));

           GridView1.DataSource =  t.getTournamentResults();
          GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}