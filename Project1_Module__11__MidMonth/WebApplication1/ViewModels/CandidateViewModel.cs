﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class CandidateViewModel
    {
        public int CandidateId { get; set; }
        
        public string CandidateName { get; set; } = default!;

        public System.DateTime BirthDate { get; set; } = default!;

        public string AppliedFor { get; set; } = default!;

        public decimal ExpectedSalary { get; set; } = default!;
        public bool WorkFromHome { get; set; }
        
        public string Picture { get; set; } = default!;
        
        public int QualifactionCount { get; set; }
        public bool CanDelete { get; set; }
    }
}