using CarPartsDetailsInformations.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarPartsDetailsInformations.ViewModel
{
    public class InputViewModel
    {

        [Key]
        public int VehicleId { get; set; }
        [Required, StringLength(50)]
        public string VehicleName { get; set; }
        [Required, Column(TypeName = "money"), DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        public int MakeYear { get; set; }
        public bool IsStock { get; set; }
        [Required, StringLength(50)]
        public string Picture { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual List<Customer> Customer { get; set; } = new List<Customer>();
    }
}