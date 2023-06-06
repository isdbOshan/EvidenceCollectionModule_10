using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace R52_M10_Class_04_Work_02.Models
{
        public enum Grade { G01=1, G03}
    public class Department
    {
        [Key]
        public int  DeapartmentId { get; set; }
        [Required, StringLength(50)]    
        public string DepartmentName { get; set; } = default!;
        public virtual ICollection<Employee> Employees { get; set; }= new List<Employee>();
    }
    public class Employee
    {
        [Key]
        public int EmployeId { get; set; }
        public string Employeename { get; set; } = default!;
        [Required,EnumDataType(typeof(Grade))]
        public Grade Grad { get; set; }
        public string Designation { get; set; } = default!;
        [Required,ForeignKey("Department")]
        public int DeapartmentId { get; set; }
        public virtual Department Department { get; set; }=default!;
    }
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
