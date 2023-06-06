using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project.ModelView
{
    public class TeacherViewModel
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public decimal ExpectedAmount { get; set; }
        public DateTime Teacherdob { get; set; }
        public string TeacherPhone { get; set; }
        public string TeacherEmail { get; set; }
        public bool IsAvailable { get; set; }
        public string Picture { get; set; }
        public byte[] Image { get; set; }
    }
}