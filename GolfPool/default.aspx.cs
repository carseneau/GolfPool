using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading;

namespace GolfPool
{
    public partial class _default : System.Web.UI.Page
    {
        Tournament t;
        bool started = false;

        protected void Page_Load(object sender, EventArgs e)
        {
             Response.Write("Pageload " + System.DateTime.Now);
             if (started == false)
             {


                 t = new Tournament("http://www.pgatour.com/tournaments/r016/results.html", MapPath("/FirefoxPortable/") + "FirefoxPortable.exe", MapPath("/FirefoxPortable/App/DefaultData/profile/"));
                 Thread tournthread = new Thread(new ThreadStart(t.getTournamentResults));
                 tournthread.IsBackground = true;
             }
                          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (t.istournamentresultsdone == true)
            {
                GridView1.DataSource = t.tournamentresults;
            }
            else
            {
                Response.Write("not done");
            }



        }
    }
}