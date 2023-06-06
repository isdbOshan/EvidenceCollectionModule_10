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
    public class EmployeeExperienceReportModel
    {
        public int ExperienceID { get; set; }
        public string Designation { get; set; }
        public string CompanyName { get; set; }
        public int ExperienceYear { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        
    }
}