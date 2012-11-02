using System;
using System.ComponentModel.DataAnnotations;

namespace Skeletor.Web.UI.Areas.Installation.ViewModels
{
    public class AdminAccountViewModel
    {
        [Required]
        [StringLength(200)]
        public string Username { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        [Required]
        [StringLength(200)]
        public string PasswordVerified { get; set; }

        [Required]
        [StringLength(200)]
        public string FirstName{ get; set; }

        [Required]
        [StringLength(200)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }
    }
}