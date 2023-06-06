﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Project.ViewModels.Identity
{
    public class RegisterViewModel
    {
        [Required, StringLength(20)]
        public string Username { get; set; }
        [Required, StringLength(20, MinimumLength = 6), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, StringLength(20, MinimumLength = 6), DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}