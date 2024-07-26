using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVCWebAppCodeFirst.Models;

namespace MVCWebAppCodeFirst
{
    public class EmployeeDBContext :DbContext
    {
        public EmployeeDBContext()
            : base("name=EmpdbContextconnection")
        {

        }
        public DbSet<Employee> employees { get; set; }
    }
}