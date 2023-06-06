using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Employee_Management_Project.ViewModels
{
    public class EmployeeReportViewModel
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string BranchName { get; set; }
        public DateTime JoiningDate { get; set; }
        public bool ActivityStatus { get; set; }
        public decimal Salary { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; }
        public byte[] Image { get; set; }
    }
}