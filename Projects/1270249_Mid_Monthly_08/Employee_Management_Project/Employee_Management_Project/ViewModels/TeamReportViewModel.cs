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
    public class TeamReportViewModel
    {
        public int TeamID { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string TeamName { get; set; }
        public string TeamLeader { get; set; }
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
    }
}