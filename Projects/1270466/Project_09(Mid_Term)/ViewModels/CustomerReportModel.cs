using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_09_Mid_Term_.ViewModels
{
    public class CustomerReportModel
    {
        public int CustomerId { get; set; }
       
        public string CustomerName { get; set; }
        
        public string phone { get; set; }
       
        public string Address { get; set; }
    }
}