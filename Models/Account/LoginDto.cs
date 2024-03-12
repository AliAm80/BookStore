using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Account
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Enter Username....")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter Password....")]
        public string Password { get; set; }
    }
}