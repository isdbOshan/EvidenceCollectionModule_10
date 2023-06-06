using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Area
    {
        public int AreaId { get; set; }
        [Required, StringLength(50)]
        public string Locations { get; set; }
        public virtual List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public virtual List<Student> Students { get; set; } = new List<Student>();

    }
    public class Teacher
    {
        public int TeacherId { get; set; }
        [Required, StringLength(50)]
        public string TeacherName { get; set; }
        [Required, Column(TypeName ="money"), DataType(DataType.Currency)]
        public decimal ExpectedAmount { get; set; }
        [Required, Column(TypeName = "date"), DataType(DataType.Date)]
        public DateTime Teacherdob { get; set; }
        [Required, StringLength(50)]
        public string TeacherPhone { get; set; }
        [Required, StringLength(50)]
        public string TeacherEmail { get; set; }
         
        public bool IsAvailable { get; set; }
        [Required, StringLength(50)]
        public string Picture { get; set; }
        
        public int AreaId { get; set; }
        [ForeignKey("AreaId")]
        public virtual Area Areas { get; set; }
        public virtual List<TeacherQualification> TeacherQualifications { get; set; } = new List<TeacherQualification>();

    }
    public class TeacherQualification
    {
        [Key]
        public int QualificationId { get; set; }
        [Required, StringLength(50)]
        public string Degree { get; set; }
        [Required,]
        public int PassingYear { get; set; }
        [Required, StringLength(50)]
        public string Result { get; set; }
        [Required, StringLength(50)]
        public string Institute { get; set; }
        
        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Teacher Teachers { get; set; }

    }
    public class Student
    {
        public int StudentId { get; set; }
        [Required, StringLength(50)]
        public string StudentName { get; set; }
        [Required, StringLength(50)]
        public string StudentPhone { get; set; }
        [Required, StringLength(50)]
        public string StudentEmail { get; set; }
        [Required, Column(TypeName = "date"), DataType(DataType.Date)]
        public DateTime Studentdob { get; set; }
        [Required, StringLength(50)]
        public string StudentClass { get; set; }
        
        public int AreaId { get; set; }
        [ForeignKey("AreaId")]
        public virtual Area Areas { get; set; }

    }
    public class TutorDbContext : DbContext
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherQualification> TeacherQualifications { get; set; }
        public DbSet<Student> Students { get; set; } 

    }


}