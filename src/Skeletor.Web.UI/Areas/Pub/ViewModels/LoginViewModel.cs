﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Skeletor.Web.UI.Pub.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}