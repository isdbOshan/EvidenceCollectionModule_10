using EquipmentPart_Mid_Month_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EquipmentPart_Mid_Month_Project.ViewModels
{
    public class CustomerEditModel
    {
        [Key]
        public int CustomerId { get; set; }
        [Required, StringLength(50)]
        public string CustomerName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required, StringLength(50)]
        public string City { get; set; }
        [Required, StringLength(50)]
        public string Country { get; set; }
        [Required, StringLength(50)]
        public string Phone { get; set; }
        [Required, StringLength(50)]
        public string Email { get; set; }
        [Required, ForeignKey("Equipment")]
        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}