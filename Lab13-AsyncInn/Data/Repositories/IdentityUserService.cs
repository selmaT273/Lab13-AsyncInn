using System;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Api;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lab13_AsyncInn.Data.Repositories
{
    public class IdentityUserService : IUserService
    {
        private readonly UserManager<Applicationuser> userManager;
        private readonly JwtTokenService tokenService;

        public IdentityUserService(UserManager<Applicationuser> userManager, JwtTokenService tokenService)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;         
        }

        public async Task<UserDTO> Authenticate(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);

            if (await userManager.CheckPasswordAsync(user, password))
            {
                return new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                };
            }

            return null;
        }

        public async Task<UserDTO> Register(RegisterData data, ModelStateDictionary modelState)
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
                return new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                };
            }

            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.UserName) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }

            return null;

        }

        
    }

}
