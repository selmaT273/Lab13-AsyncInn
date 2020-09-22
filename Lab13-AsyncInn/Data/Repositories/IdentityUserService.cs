using System;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Api;
using Microsoft.AspNetCore.Identity;

namespace Lab13_AsyncInn.Data.Repositories
{
    public class IdentityUserService : IUserService
    {
        private readonly UserManager<Applicationuser> userManager;

        public IdentityUserService(UserManager<Applicationuser> userManager)
        {
            this.userManager = userManager;         
        }
        public async Task<Applicationuser> Register(RegisterData data)
        {
            var user = new Applicationuser
            {
                UserName = data.UserName,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber,
            };

            var result = await userManager.CreateAsync(user, data.Password);
            if (result.Succeeded)
            {
                return user;
            }

            return null;

        }

        
    }

}
