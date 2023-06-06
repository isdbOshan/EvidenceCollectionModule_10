using Project_09_Mid_Term_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_09_Mid_Term_.ViewModels
{
    public class OrderReportModel
    {
        public int OrderId { get; set; }
       
        public DateTime OrderDate { get; set; }
        
        public DateTime DelivaryDate { get; set; }
        
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}