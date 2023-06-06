using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_8_1270809.ViewModel
{
    public class TraineeViewModel
    {
        public int TraineeId { get; set; }
       
        public string TraineeName { get; set; }
        
        public decimal AdmitionFee { get; set; }
       
        public DateTime DateOfBirth { get; set; }
       
        public bool OnAddmited { get; set; }
       
        public string Picture { get; set; }
      public byte[] Image { get; set; }
    }
}