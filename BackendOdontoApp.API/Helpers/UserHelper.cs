using BackendOdontoApp.API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace BackendOdontoApp.API.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserHelper(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task<IdentityResult> AddUserAsync(User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task AddUserToRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task CheckRoleAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
