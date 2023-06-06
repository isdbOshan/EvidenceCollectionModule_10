using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_09_Mid_Term_.ViewModels
{
    public class ImageUp
    {
        [Required]
        public HttpPostedFileBase Picture { get; set; }
    }
}