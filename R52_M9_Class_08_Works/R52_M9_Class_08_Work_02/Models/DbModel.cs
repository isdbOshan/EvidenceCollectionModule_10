using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace R52_M9_Class_08_Work_02.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required, StringLength(50)]
        public string EmployeeName { get; set; } = default!;
        [Required, Column(TypeName = "date")]
        public DateTime JoinDate { get; set; } = DateTime.Today;
        [Required, Column(TypeName = "money")]
        public decimal BasicSalary { get; set; }
    }
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
