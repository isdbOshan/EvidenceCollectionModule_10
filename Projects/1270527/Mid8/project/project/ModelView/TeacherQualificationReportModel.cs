using project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project.ModelView
{
    public class TeacherQualificationReportModel
    {
        public int QualificationId { get; set; }

        public string Degree { get; set; }
        [Required,]
        public int PassingYear { get; set; }

        public string Result { get; set; }

        public string Institute { get; set; }

        public int TeacherId { get; set; }

        public virtual Teacher Teachers { get; set; }
    }
}