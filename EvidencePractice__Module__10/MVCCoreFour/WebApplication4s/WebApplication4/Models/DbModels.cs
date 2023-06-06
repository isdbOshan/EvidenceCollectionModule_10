using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
//Microsoft.EntityFrameworkCore.SqlServer
//Microsoft.EntityFrameworkCore.Design
//Microsoft.EntityFrameworkCore.Tools

namespace WebApplication4.Models
{
    public class CarDetail
    {
   
        public int CarId { get; set; }
        [Required, StringLength(50)]
        public string CarName { get; set; } = default!;
        [Required, DataType(DataType.DateTime)]
        public DateTime MakeYear { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }
        public bool Available { get; set; }
        [Required, StringLength(50)]
        public string Picture { get; set; } = default!;
        public virtual List<PartsDetails> PartsDetail { get; set; } = new List<PartsDetails>();
    }
    public class PartsDetails
    {
      
        public int PartsId { get; set; }
        public int Door { get; set; }
        public string FuelSystem { get; set; } = default!;
        public decimal MaxLoad { get; set; }
        [Required, ForeignKey("CarDetail")]
        public int CarId { get; set; }
        public virtual CarDetail CarDetail { get; set; } = default!;

    }
    public class CarPartsDetailDbContext: DbContext
    {
        public CarPartsDetailDbContext(DbContextOptions<CarPartsDetailDbContext> option):base(option)
        {

        }
        public DbSet<CarDetail> CarDetails { get; set; }
        public DbSet<PartsDetails> PartsDetails { get; set; }
    }
}
