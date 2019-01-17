using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebBootstart01.DataAccessLayer;

namespace WebBootstart01.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee>GetEmployees()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
        }

        public void Add(Employee emp)
        {
            using (var a = new SalesERPDAL())
            {
                a.Employees.Add(emp);
                a.SaveChanges();
            }
        }
        public void DeleteId(int id)
        {
            using (var a = new SalesERPDAL())
            {
                Employee emp = a.Employees.Find(id);
                  a.Entry(emp).State = EntityState.Deleted;
                a.SaveChanges();
            }
        }
        public Employee Query(int id)
        {
            using (var a = new SalesERPDAL())
            {
                Employee emp = a.Employees.Find(id);
                return emp;
            }
        }
        public void UpdateEmp(Employee emp)
        {
            using (var a = new SalesERPDAL())
            {
                a.Entry(emp).State = EntityState.Modified;
                a.SaveChanges();
               
            }
        }

        public List<Employee>Search(string name)
        {
            using (var a = new SalesERPDAL())
            {
                var query = a.Employees.Where(e => e.Name.Contains(name));
                return query.ToList();
            }
        }

    }

   
}