using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace R52_M12_Class_01_Work_02.ViewModels
{
    public class WorkerViewModel
    {
        public int Id { get; set; }
      
        public string Name { get; set; } = default!;
       
        public decimal PayRate { get; set; }
       
        public DateTime StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }

        public int? DaysWorked { get;  set; }
        public decimal? TotalEarning { get;  set; }
    }
}
