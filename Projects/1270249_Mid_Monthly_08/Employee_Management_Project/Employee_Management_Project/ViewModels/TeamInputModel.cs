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
    public class TeamInputModel
    {
        [Key]
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
}