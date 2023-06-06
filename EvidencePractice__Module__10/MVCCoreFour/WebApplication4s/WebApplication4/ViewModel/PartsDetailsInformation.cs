using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication4.Models;

namespace WebApplication4.ViewModel
{
    public class PartsDetailsInformation
    {
        public int PartsId { get; set; }
        public int Door { get; set; }
        public string FuelSystem { get; set; } = default!;
        public decimal MaxLoad { get; set; }
        [Required, ForeignKey("CarDetail")]
        public int CarId { get; set; }
        public virtual CarDetail CarDetail { get; set; } = default!;
    }
}
