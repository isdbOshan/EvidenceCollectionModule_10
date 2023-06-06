using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarPartsDetailsInformations.ViewModel
{
    public class VehicleInputModel
    {
        [Key]
        public int VehicleId { get; set; }
   
        public string VehicleName { get; set; }
  
        public decimal Price { get; set; }
 
        public int MakeYear { get; set; }
        public bool IsStock { get; set; }
       
        public string Picture { get; set; }
        public byte[] Image { get; set; }
    }
}