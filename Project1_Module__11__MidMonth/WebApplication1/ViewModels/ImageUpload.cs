using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class ImageUpload
    {

        public IFormFile Picture { get; set; } = default!;
    }
}