using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBootstart01.Models;
using WebBootstart01.ViewModels;

namespace WebBootstart01.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeListViewModel empListModel = new EmployeeListViewModel();
            //实例化员工信息业务层
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            var listEmp = empBL.GetEmployees();
            empListModel.Employees = getEmpVmList(listEmp);


            //获取将处理过的数据列表
            
            // 获取问候语
            empListModel.Greeting = getGreeting();
            //获取用户名
            empListModel.UserName = getUserName();           
            //将数据送往视图
            return View(empListModel);

        }

        public ActionResult Search(string searchString)
        {
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            var queryResult = ebl.Search(searchString);
            EmployeeListViewModel empListModel = new EmployeeListViewModel();
            empListModel.Employees = getEmpVmList(queryResult.ToList());
            empListModel.Greeting = getGreeting();
            empListModel.UserName = getUserName();
            return View("index", empListModel);
        }



        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }
        public ActionResult Save(Employee emp)
        {
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            ebl.Add(emp);
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            ebl.DeleteId(id);
            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult CreateEmployee(Employee emp)
        {
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            ebl.Add(emp);
            return RedirectToAction("index");
        }
        public ActionResult UpdateEmployee(int id)
        {
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            Employee emp = ebl.Query(id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(Employee emp)
        {
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            ebl.UpdateEmp(emp);
            return RedirectToAction("index");
        }



        [NonAction]
        List<EmployeeViewModel> getEmpVmList(List<Employee>listEmp)
        {

            ////实例化员工信息业务层
            //EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            ////员工原始数据列表，获取来自业务层类的数据
            //var listEmp = empBL.GetEmployees();
            ////员工原始数据加工后的视图数据列表，当前状态是空的
            //var listEmpVm = new List<EmployeeViewModel>();


            var listEmpVm = new List<EmployeeViewModel>();

            //通过循环遍历员工原始数据数组，将数据一个一个的转换，并加入listEmpVm
            foreach (var item in listEmp)
            {
                EmployeeViewModel empVmObj = new EmployeeViewModel();
                empVmObj.EmployeeId = item.Id;
                empVmObj.EmployeeName = item.Name;
                empVmObj.EmployeeSalary = item.Salary.ToString("C");
                if (item.Salary > 10000)
                {
                    empVmObj.SalaryGrade = "土豪";
                }
                else
                {
                    empVmObj.SalaryGrade = "屌丝";
                }
                listEmpVm.Add(empVmObj);
            }

            return listEmpVm;

        }
        string getGreeting()
        {
            string greeting;
            //获取当前时间
            DateTime dt = DateTime.Now;
            //获取当前小时数
            int hour = dt.Hour;
            //根据小时数判断需要返回哪个视图，<12 返回myview 否则返回 yourview
            if (hour < 12)
            {
                greeting = "早上好";
            }
            else
            {
                greeting = "下午好";
            }


            return greeting;
        }
        [NonAction]
        string getUserName()
        {
            return "用户";
        }



    }
}