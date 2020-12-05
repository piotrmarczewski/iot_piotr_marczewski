using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class SignInVm
    {
        [Required(ErrorMessage = "User name is required")]
        [MinLength(length:3, ErrorMessage = "The user name can't be shorter than 3.")]
        public string UserName { get; set; }
    }
}
