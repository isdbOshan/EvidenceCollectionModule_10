using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_09_Mid_Term_.ViewModels
{
    public class ComputerViewModel
    {
        public int ComputerId { get; set; }
       
        public string ComputerName { get; set; }
       
        public decimal Price { get; set; }
       
        public DateTime MGFDate { get; set; }
       
        public string Picture { get; set; }
        public byte[] Image { get; set; }
    }
}