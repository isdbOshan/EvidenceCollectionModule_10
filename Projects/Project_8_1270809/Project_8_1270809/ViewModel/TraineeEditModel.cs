using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Project_8_1270809.Models;

namespace Project_8_1270809.ViewModel
{
    public class TraineeEditModel
    {
        [Key]
        public int TraineeId { get; set; }
        [Required, StringLength(50)]
        public string TraineeName { get; set; }
        [Required, Column("money")]
        public decimal AdmitionFee { get; set; }
        [Required, Column("date")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public bool OnAddmited { get; set; }
        public string Picture { get; set; }
        public virtual List<Module> Modules { get; set; } = new List<Module>();

    }
}
