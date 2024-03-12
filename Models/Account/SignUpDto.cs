using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Account
{
    public class SignUpDto 
    {
        [Required(ErrorMessage = "Enter First Name....")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter Last Name....")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter Email...."), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Username....")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Password...."), Compare("ConfirmPassword")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter ConfirmPassword....")]
        public string ConfirmPassword { get; set; }
    }
}