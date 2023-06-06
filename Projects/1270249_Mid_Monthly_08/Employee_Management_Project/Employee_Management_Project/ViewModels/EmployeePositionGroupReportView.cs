using Employee_Management_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Employee_Management_Project.ViewModels
{
    public class EmployeePositionGroupReportView
    {
        [Key]
        public int PositionID { get; set; }
        public decimal DailyRate { get; set; }
        public int WorkingDaysPerMonth { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public virtual Employee Employee { get; set; }
    }
}