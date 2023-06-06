using Project_8_1270809.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_8_1270809.ViewModel
{
    public class ModuleView
    {
        public int ModuleId { get; set; }

        public string ModuleName { get; set; }
        public int TimeDuration { get; set; }

        public int TraineeId { get; set; }
      
    }
}