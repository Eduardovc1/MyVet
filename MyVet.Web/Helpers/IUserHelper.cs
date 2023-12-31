﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using MyVet.Web.Data.Entities;
using MyVet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyVet.Web.Helpers
{
 public   interface IUserHelper
    {
        Task<User> GetuserByEmailAsync(string email);
        Task<IdentityResult> AddUserAsync(User user,string password);
        Task CheckroleAsync(string roleName);
        Task AdduserToRoleAsync(User user,string roleName);
        Task<bool> IsUserInRoleAsync(User user, string roleName);
        Task<Microsoft.AspNetCore.Identity.SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();

    }
}
