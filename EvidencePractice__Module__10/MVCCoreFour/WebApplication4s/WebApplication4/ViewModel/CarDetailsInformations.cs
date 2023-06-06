using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication4.Models;

namespace WebApplication4.ViewModel
{
    public class CarDetailsInformations
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
}
