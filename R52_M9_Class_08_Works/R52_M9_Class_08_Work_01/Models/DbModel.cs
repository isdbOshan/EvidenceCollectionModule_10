using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace R52_M9_Class_08_Work_01.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required, StringLength(50)]
        public string EmployeeName { get; set; }
        [Required, Column(TypeName ="date")]
        public DateTime JoinDate { get; set; }
        [Required, Column(TypeName ="money")]
        public decimal BasicSalary { get; set; }
    }
    public class EmployeeDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}