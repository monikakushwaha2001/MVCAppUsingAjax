using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;//For using LINQ to XML

namespace MVCAppUsingAjax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public string GetScore()
        {
            // Get the physical path of the file for the given virtual path
            string physicalPath = Server.MapPath("~/matches/Score.xml");

            //Loads the XML file into the application from the specified location
            var doc = XElement.Load(physicalPath);

            //Reads the value or content of "score" element from the xml file which is loaded
            string score = doc.Element("Score").Value;
            return score;
        }
    }
}