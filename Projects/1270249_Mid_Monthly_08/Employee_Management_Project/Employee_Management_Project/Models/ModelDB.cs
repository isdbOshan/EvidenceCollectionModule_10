using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Employee_Management_Project.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Required, StringLength(50), Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Required, StringLength(50), Display(Name = "Branch Name")]
        public string BranchName { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "Joining Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime JoiningDate { get; set; }
        [Required, Display(Name = "Activity Status")]
        public bool ActivityStatus { get; set; }
        [Required, DataType(DataType.Currency), Display(Name = "Salary"), DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal Salary { get; set; }
        [Required, StringLength(20)]
        public string Phone { get; set; }
        [Required, StringLength(50), Display(Name = "Employee Photo")]
        public string Picture { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();
        public virtual ICollection<Position> Positions { get; set; }=new List<Position>();
        public virtual ICollection<Team> Teams { get; set; }= new List<Team>();
    }
    public class Experience
    {
        public int ExperienceID { get; set; }
        [Required, ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        [Required, Display(Name = "Designation"), StringLength(40)]
        public string Designation { get; set; }
        [Required, Display(Name = "Company Name"), StringLength(40)]
        public string CompanyName { get; set; }
        [Required]
        public int ExperienceYear { get; set; }
        public virtual Employee Employee { get; set; }
    }
    public class Position
    {
        public int PositionID { get; set; }
        [Required, DataType(DataType.Currency), Display(Name = "Daily Rate"), DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal DailyRate { get; set; }
        [Required, Display(Name = "Working Days Per Month")]
        public int WorkingDaysPerMonth { get; set; }
        [Required, ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
    }
    public class Team
    {
        public int TeamID { get; set; }
        [Required, StringLength(50), Display(Name = "Department")]
        public string Department { get; set; }
        [Required, StringLength(50), Display(Name = "Team Name")]
        public string TeamName { get; set; }
        [Required, StringLength(50), Display(Name = "Team Leader")]
        public string TeamLeader { get; set; }
        [Required, ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
    }
    public class EmployeeExperienceDbContext : DbContext
    {
        public EmployeeExperienceDbContext() : base("EmployeeExperienceDbContext"){}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}