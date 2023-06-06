using BookShopProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShopProject.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        [Required]
        public int Quantity { get; set; }

        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Required, Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        [Required, ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}