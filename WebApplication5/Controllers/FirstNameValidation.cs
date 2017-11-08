using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Controllers
{
    public class FirstNameValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value==null)
            {
                return new ValidationResult("请输入开始名称");
            }
            else
            {
                if (!value.ToString().Contains("@"))
                {
                    return new ValidationResult("First Name必须包含@");
                }
            }
            return ValidationResult.Success;
        }
    }
}