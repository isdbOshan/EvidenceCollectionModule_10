using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EquipmentPart_Mid_Month_Project.Models
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        [Required, StringLength(50)]
        public string EquipmentName { get; set; }
        [Required, Column(TypeName = "Date"), DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }
        [Required, Column(TypeName = "money"), DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public bool Available { get; set; }
        [Required, StringLength(30)]
        public string Picture { get; set; }
        public virtual List<Part> Part { get; set; } = new List<Part>();
        public virtual List<Customer> Customer { get; set; } = new List<Customer>();
    }
    public class Part
    {
        public int PartId { get; set; }
        [Required, StringLength(50)]
        public string PartName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, ForeignKey("Equipment")]
        public int EquipmentId { get; set; }
        public virtual  Equipment Equipment { get; set; }
        public virtual List<PartDetail> PartDetail { get; set; }=new List<PartDetail>();
    }
    public class PartDetail
    {
        public int PartDetailId { get; set; }
        [Required, StringLength(50)]
        public string Description { get; set; }
        [Required, Column(TypeName = "date"), DataType(DataType.Date)]
        public DateTime Expiredate { get; set; }
        [Required, StringLength(50)]
        public string Material { get; set; }
        [Required, StringLength(50)]
        public string Company { get; set; }
        [Required, ForeignKey("Part")]
        public int PartId { get; set; }
        public virtual Part Part { get; set; }
    }
    public class Customer
    {
        public int CustomerId { get; set;}
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
        public int EquipmentId { get; set;}
        public virtual Equipment Equipment { get; set; } 
    }
    public class EquipmentDbContext : DbContext
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartDetail> PartDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}