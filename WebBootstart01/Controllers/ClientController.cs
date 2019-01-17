using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBootstart01.Models;

namespace WebBootstart01.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            //string greeting;
            //Employee emp = new Employee();
            //emp.Client = "小马";
            //emp.From = "白金会员";
            //ViewBag.ctKey = emp;
            //int h = 0;
            //h = DateTime.Now.Hour;
            //if (h < 12)
            //{
                //greeting = "上午好";
            //}
            //else
            //{
                //greeting = "下午好";
            //}
            //ViewBag.greeting = greeting;
            return View();
        }
    }
}