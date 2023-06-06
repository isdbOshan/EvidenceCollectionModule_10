using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_09_Mid_Term_.ViewModels.Identity
{
    public class LoginViewModel
    {
        [Required, StringLength(20)]
        public string Username { get; set; }
        [Required, StringLength(20, MinimumLength = 6), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}