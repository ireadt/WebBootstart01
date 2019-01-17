using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBootstart01.DAL;
using WebBootstart01.ViewModels;
using WebBootstart01.Common;

namespace WebBootstart01.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            var data = tianqi.GetWeatherByCityName("柳州");
            return View(data);
        }
        public JsonResult getweather(string city)
        {
            var data = tianqi.GetWeatherByCityName(city);
            var json = Json(data);
            return json;
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
    }
}