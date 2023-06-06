using project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project.ModelView
{
    public class QualificationReportModel
    {
        public int QualificationId { get; set; }
        [Required, StringLength(50)]
        public string Degree { get; set; }
        [Required,]
        public int PassingYear { get; set; }
        [Required, StringLength(50)]
        public string Result { get; set; }
        [Required, StringLength(50)]
        public string Institute { get; set; }
        [Required, ForeignKey("Teacher")]
        public int TeacherId { get; set; }
         
        public string TeacherName { get; set; }
    }
}