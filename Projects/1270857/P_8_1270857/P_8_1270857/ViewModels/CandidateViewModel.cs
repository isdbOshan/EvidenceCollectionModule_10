using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P_8_1270857.ViewModels
{
    public class CandidateViewModel
    {
        public int CandidateId { get; set; }

        public string CandidateName { get; set; }

        public System.DateTime BirthDate { get; set; }

        public string AppliedFor { get; set; }

        public decimal ExpectedSalary { get; set; }
        public bool WorkFromHome { get; set; }

        public string Picture { get; set; }
        public byte[] Image { get; set; }
    }
}