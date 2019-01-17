using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBootstart01.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSalary { get; set; }
        public string SalaryGrade { get; set; }
    }
}