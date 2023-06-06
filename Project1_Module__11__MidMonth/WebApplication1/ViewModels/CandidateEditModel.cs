
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class CandidateEditModel
    {
        [Key]
        public int CandidateId { get; set; }
        [Required, StringLength(50)]
        public string CandidateName { get; set; } = default!;
        [Required, DataType(DataType.Date)]
        public System.DateTime BirthDate { get; set; }
        [Required, StringLength(30)]
        public string AppliedFor { get; set; } = default!;
        [Required, Column(TypeName = "money"), DataType(DataType.Currency)]
        public decimal ExpectedSalary { get; set; }
        public bool WorkFromHome { get; set; }
        
        public string Picture { get; set; } = default!;
        public virtual List<Qualification>? Qualifications { get; set; } = new List<Qualification>();
    }
}