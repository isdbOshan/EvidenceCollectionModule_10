using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_09_Mid_Term_.ViewModels
{
    public class OrderItemReport
    {
        public int OrderItemId { get; set; }
        
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public int ComputerId { get; set; }
        public string ComputerName { get; set; }
        public int Quantity { get; set; }
    }
}