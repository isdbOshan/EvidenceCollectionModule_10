using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarPartsDetailsInformations.ViewModel
{
    public class CustomerReportView
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}