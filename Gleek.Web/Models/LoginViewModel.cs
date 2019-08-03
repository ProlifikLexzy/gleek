using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleek.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email or  Username is required")]
        [EmailAddress]
        public string Username { get; set; } = "admin@admin.com";

        [Required]
        public string Password { get; set; }
    }
}
