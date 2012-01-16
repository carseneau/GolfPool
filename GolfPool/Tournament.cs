using System;

using System.Collections.Generic;

using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpenQA.Selenium;
namespace GolfPool
{
    public class Tournament
    {
        IWebDriver driver;
        string url;
        DataTable tournamentresults;

        public Tournament(string tournamenturl,string firefoxpath,string firefoxprofilepath)
        {
                     
            OpenQA.Selenium.Firefox.FirefoxBinary binary = new OpenQA.Selenium.Firefox.FirefoxBinary(firefoxpath);
            OpenQA.Selenium.Firefox.FirefoxProfile profile = new OpenQA.Selenium.Firefox.FirefoxProfile(firefoxprofilepath);
            driver = new OpenQA.Selenium.Firefox.FirefoxDriver(binary,profile);
            tournamentresults = new DataTable("tournamentresults");
            tournamentresults.Columns.Add("Golfer",typeof(string));
            tournamentresults.Columns.Add("Prize", typeof(string));
            url = tournamenturl;
        }
                
        public DataTable getTournamentResults()
        {
            int i = 1;
            int j = 1;
            driver.Navigate().GoToUrl(url);
            int mindex;

            mindex = driver.FindElements(By.ClassName("tourTournTblHead"))[2].FindElements(By.TagName("td")).Count + 4;
       


                
            foreach (IWebElement f in driver.FindElements(By.ClassName("tourTableData")))
            {
                tournamentresults.Rows.Add(f.FindElements(By.TagName("td"))[0].Text, f.FindElements(By.TagName("td"))[mindex - 1].Text.Replace("$","").Replace(",",""));

                i++;
            }

            foreach (IWebElement f in driver.FindElements(By.ClassName("tourTableDataAlt")))
            {
                tournamentresults.Rows.Add(f.FindElements(By.TagName("td"))[0].Text, f.FindElements(By.TagName("td"))[mindex - 1].Text.Replace("$", "").Replace(",", ""));
                i++;
            }
            driver.Close();
            return tournamentresults;
        }

        
        public DataTable getAllTournamentResults()
        {
            driver.Navigate().GoToUrl("http://www.pgatour.com/r/schedule/");
            List<string> tournaments = new List<string>();

            foreach (IWebElement e in driver.FindElements(By.ClassName("tourSchArrowFront")))
            {
                tournaments.Add(e.GetAttribute("href") + "results.html");
            }

            foreach (String t in tournaments)
            {
                driver.Navigate().GoToUrl(t);
                foreach (IWebElement f in driver.FindElements(By.ClassName("tourTableData")))
                {
                    //TODO
                }
                foreach (IWebElement f in driver.FindElements(By.ClassName("tourTableDataAlt")))
                {
                   //TODO
                }
                driver.Close();
            }
            return tournamentresults;
        }
    }
}