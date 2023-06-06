using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project_09_Mid_Term_.Models
{
    public class Computer
    {
        public int ComputerId { get; set; }
        [Required,StringLength(100)]    
        public string ComputerName { get; set;}
        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Required, Column(TypeName = "date")]
        public DateTime MGFDate { get; set; }
        [Required,StringLength(100)]
        public string Picture { get; set; }
        public virtual List <OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
    public class Customer
    {
        public int CustomerId { get; set;}
        [Required,StringLength(100)]    
        public string CustomerName { get; set;}
        [Required,StringLength(50)]    
        public string phone { get; set; }
        [Required,StringLength(150)]
        public string Address { get; set; }
        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
    public class Order
    {
        public int OrderId { get; set;}
        [Required,Column(TypeName ="date")]
        public DateTime OrderDate { get; set;}
        [Required, Column(TypeName = "date")]
        public DateTime DelivaryDate { get; set;}
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }= new List<OrderItem>();
    }
    public class OrderItem
    {
        public int OrderItemId { get; set;}
        [ForeignKey("Order")]
        public int OrderId { get; set;}
        [ForeignKey("Computer")]
        public int ComputerId { get; set; }
        public int Quantity { get; set;}
        public virtual Order Order { get; set; }
        public virtual Computer Computer { get; set; }
    }
    public class ComputerDbContext: DbContext
    {
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrdersItem { get; set;}
    }
}