using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Project.ViewModels
{
    public class ImageUpload
    {
        public HttpPostedFileBase Picture { get; set; }
    }
}