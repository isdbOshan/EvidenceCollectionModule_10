using Employee_Management_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Employee_Management_Project.ViewModels
{
    public class EmployeeEditModel
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required, StringLength(50), Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Required, StringLength(50), Display(Name = "Branch Name")]
        public string BranchName { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "Joining Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime JoiningDate { get; set; }
        public bool ActivityStatus { get; set; }
        [Required, DataType(DataType.Currency), Display(Name = "Salary"), DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal Salary { get; set; }
        [Required, StringLength(20)]
        public string Phone { get; set; }
        public string Picture { get; set; }
        public virtual List<Experience> Experiences { get; set; } = new List<Experience>();
    }
}