using Project_09_Mid_Term_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_09_Mid_Term_.ViewModels
{
    public class ComputerEditModel
    {
        [Key]
        public int ComputerId { get; set; }
        [Required, StringLength(100)]
        public string ComputerName { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Required, Column(TypeName = "date")]
        public DateTime MGFDate { get; set; }
        
        public string Picture { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}