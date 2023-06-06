using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;

namespace Project_8_1270809.Models
{
    public class Trainee
    {
        public int TraineeId { get; set; }
        [Required,StringLength(50)]
        public string TraineeName { get; set; }
        [Required,Column("money")]
        public decimal AdmitionFee { get; set; }
        [Required,Column("date")]
         public DateTime DateOfBirth { get; set; }
        [Required]
        public bool OnAddmited { get; set; }
        [Required, StringLength(50)]
        public string Picture { get; set; } 
        public virtual List<Module> Modules { get; set; }= new List<Module>();
       
    }
    public class Module
    {
        public int ModuleId { get; set; }
        [Required]
        public string ModuleName { get; set; }
        public int TimeDuration { get; set; }
        [Required]
        public int TraineeId { get; set; }
        [ForeignKey("TraineeId")]
        public virtual Trainee Trainee { get; set; }
        public virtual List<Exam> Exams { get; set; } = new List<Exam>();
    }
    public class Exam
    {
        public int ExamId { get; set; }
        [Required,StringLength(50)]
        public string ExamName { get; set; }
        [Required, Column("date")]
        public DateTime ExamDate { get; set; }
        [Required]
        public int ModuleId { get; set; }
        [ForeignKey("ModuleId")]
        public virtual Module Module { get; set; }
        public virtual List<ExamResult> ExamResults { get; set; } = new List<ExamResult>();
    }
    public class ExamResult
    {
        [Key]
        public int ResutlId { get; set; }
        public string Result { get; set; }
        public DateTime PublishDate { get; set; }
        [Required, ForeignKey("Exam")]
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
    }
    public class TraineesDbContext  : DbContext
    {
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }

    }
}