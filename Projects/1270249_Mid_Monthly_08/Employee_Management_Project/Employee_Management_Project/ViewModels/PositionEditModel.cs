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
    public class PositionEditModel
    {
        [Key]
        public int PositionID { get; set; }
        [Required, DataType(DataType.Currency), Display(Name = "Daily Rate"), DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal DailyRate { get; set; }
        [Required, Display(Name = "Working Days Per Month")]
        public int WorkingDaysPerMonth { get; set; }
        [Required, ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
    }
}