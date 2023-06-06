using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_8_1270809.ViewModel
{
    public class ImageUpload
    {
        [Required]
        public HttpPostedFileBase Picture { get; set; }
    }
}