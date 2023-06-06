using EquipmentPart_Mid_Month_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EquipmentPart_Mid_Month_Project.ViewModels
{
    public class PartReportModel
    {
        public int PartId { get; set; }
        [Required, StringLength(50)]
        public string PartName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, ForeignKey("Equipment")]
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }


    }
}