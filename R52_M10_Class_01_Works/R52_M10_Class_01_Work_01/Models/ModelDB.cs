using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace R52_M10_Class_01_Work_01.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } = default!;
        [Required, Column(TypeName ="money")]
        public decimal Price { get; set; }
        [Required, Column(TypeName="date")]
        public DateTime MfgDate { get; set;}
    }
    public class ProductDbContext : DbContext 
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; } = default!;
    }
}
