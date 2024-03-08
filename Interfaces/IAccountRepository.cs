using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using BookStore.Models.Account;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Interfaces
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUp(SignUpDto signUpDto);
    }
}