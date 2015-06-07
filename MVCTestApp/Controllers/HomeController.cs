using MVCTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTestApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Chart()
        {
            ViewBag.Message = "Your Chart page.";

            var jsonproxy = new JsonProxyClient();
            Results resultdata = jsonproxy.GetData("http://ramorak.com/demo/assess.json");

            return View(resultdata);
        }
    }
}