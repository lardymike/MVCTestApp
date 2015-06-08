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
          ViewBag.Message = "Charting some data.";

          var jsonproxy = JsonProxyClient.CreateJsonProxy("http://ramorak.com/demo/assess.json");
          ChartData resultdata = jsonproxy.ParsedData;

          return View(resultdata);
        }
    }
}