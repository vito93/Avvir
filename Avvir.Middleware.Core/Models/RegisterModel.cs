using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avvir.Middleware.Core.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
    }
}
