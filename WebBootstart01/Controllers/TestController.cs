using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBootstart01.Models;

namespace WebBootstart01.Controllers
{
    public class TestController : Controller
    {
        public string GetString()
        {
            return "你好，MVC";
        }
        public Customer GetCustomer()
        {
            Customer c = new Customer();
            c.CustomerName = "小马";
            c.Address = "mmmmmmm";
            return c;
        }
        public ActionResult GetView()
        {
            string greeting;
            int h = 0;
            h = DateTime.Now.Hour;
            if (h<12)
            {
                greeting = "上午好";
            }
            else
            {
                greeting = "下午好";
            }
            ViewBag.greeting = greeting;
            //ViewData["greeting"] = greeting;
            Employee emp = new Employee();
            emp.Name = "李四";
            emp.Salary = 20000;
            ViewBag.EmpKey = emp;
            //ViewData["EmpKey"] = emp;
            return View("MyView");
        }
    }
}