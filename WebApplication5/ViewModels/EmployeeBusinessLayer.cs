using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models;
using WebApplication5.Data_Access_Layer;

namespace WebApplication5.ViewModels
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
            //List<Employee> employees = new List<Employee>();

            //Employee emp = new Employee();
            //emp.FirstName = "Johnson";
            //emp.LastName = "Fernandes";
            //emp.Salary = 14000;
            //employees.Add(emp);

            //emp = new Employee();
            //emp.FirstName = "Michael";
            //emp.LastName = "Jackson";
            //emp.Salary = 16000;
            //employees.Add(emp);

            //emp = new Employee();
            //emp.FirstName = "Robert";
            //emp.LastName = "Pattinson";
            //emp.Salary = 200000;
            //employees.Add(emp);

            //return employees;
        }
        public void SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            //return e;
        }
        public bool IsValidUser(UserDetails u)
        {
            if (u.UserName=="Admin"&&u.Password=="123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}