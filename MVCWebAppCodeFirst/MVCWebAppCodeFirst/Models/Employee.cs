using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCWebAppCodeFirst.Models
{
    [Table("EmployeeTable")]
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeSalary { get; set; }
        public string City { get; set; }
      
    }
}