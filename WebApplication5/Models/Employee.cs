using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebApplication5.Controllers;

namespace WebApplication5.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [FirstNameValidation]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="必填字段")]
        public string LastName { get; set; }
        public int? Salary { get; set; }
    }
}