using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Test
        public string GetString()
        {
            return "Hello world is old now. It's time for wassup bro;)";
        }
        [Authorize]
        public ActionResult Index()
        {
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            employeeListViewModel.UserName = User.Identity.Name;
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();
            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                if (emp.Salary.HasValue)
                {
                    empViewModel.Salary = emp.Salary.Value.ToString("c");
                }
                else
                {
                    empViewModel.Salary = "";
                }

                if (emp.Salary>15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);//List的add方法
            }
            employeeListViewModel.Employees = empViewModels;
            //employeeListViewModel.UserName = "Admin";
            return View("Index", employeeListViewModel);
            //return View("MyView");
            //Employee emp = new Employee();
            //emp.FirstName = "Sukesh";
            //emp.LastName = "Marla";
            //emp.Salary = 10000;

            //EmployeeViewModel vmEmp = new EmployeeViewModel();
            //vmEmp.EmployeeName = emp.FirstName + " " + emp.LastName;
            //vmEmp.Salary = emp.Salary.ToString("c");
            //if (emp.Salary>15000)
            //{
            //    vmEmp.SalaryColor = "yellow";
            //}
            //else
            //{
            //    vmEmp.SalaryColor = "green";
            //}
            //vmEmp.UserName = "Admin";
            //return View("MyView", vmEmp);
            
            //return View("MyView", emp);
            //ViewData["Employee"] = emp;
            //ViewBag.Employee = emp;
            //return View("MyView");
        }

        public ActionResult AddNew()
        {
            //return View("CreateEmployee");
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }

        public ActionResult SaveEmployee(Employee e,string BtnSubmit)
        {
            if (BtnSubmit == "Save Employee")
            {
                if (ModelState.IsValid)
                {
                    //return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
                    EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                    empBal.SaveEmployee(e);
                    return RedirectToAction("Index");
                }
                else
                {
                    //return View("CreateEmployee");
                    //验证失败时填充值
                    CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                    vm.FirstName = e.FirstName;
                    vm.LastName = e.LastName;
                    if (e.Salary.HasValue)
                    {
                        vm.Salary = e.Salary.ToString();
                    }
                    else
                    {
                        vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                    }
                    return View("CreateEmployee", vm);

                }

            }
            else
            {
                if (BtnSubmit == "Cancel")
                {
                    //return View("Index");
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content(BtnSubmit);
                    //return new EmptyResult();
                }
            }

            //if (BtnSubmit=="Save Employee")
            //{
            //    return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
            //}
            //else
            //{
            //    if (BtnSubmit=="Cancel")
            //    {
            //        //return View("Index");
            //        return RedirectToAction("Index");
            //    }
            //    else
            //    {
            //        return new EmptyResult();
            //    }
            //}

            //string FirstName = e.Salary.ToString();
            //return e.FirstName + "|" + e.LastName + "|" + e.Salary;

        }
    }
}