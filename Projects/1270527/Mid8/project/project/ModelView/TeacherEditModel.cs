using project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project.ModelView
{
    public class TeacherEditModel
    {
        [Key]
        public int TeacherId { get; set; }
        [Required, StringLength(50)]
        public string TeacherName { get; set; }
        [Required, Column(TypeName = "money"), DataType(DataType.Currency)]
        public decimal ExpectedAmount { get; set; }
        [Required, Column(TypeName = "date"), DataType(DataType.Date)]
        public DateTime Teacherdob { get; set; }
        [Required, StringLength(50)]
        public string TeacherPhone { get; set; }
        [Required, StringLength(50)]
        public string TeacherEmail { get; set; }

        public bool IsAvailable { get; set; }

        public string Picture { get; set; }

        public int AreaId { get; set; }
        [ForeignKey("AreaId")]
        public virtual Area Areas { get; set; }
        public virtual List<TeacherQualification> TeacherQualifications { get; set; } = new List<TeacherQualification>();


    }
}