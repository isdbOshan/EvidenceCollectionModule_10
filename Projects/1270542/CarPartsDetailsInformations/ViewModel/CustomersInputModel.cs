using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarPartsDetailsInformations.ViewModel
{
    public class CustomersInputModel
    {
        public int CustomerId { get; set; }
        [Required, StringLength(50)]
        public string CustomerName { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, StringLength(100)]
        public string Address { get; set; }
        
    }
}