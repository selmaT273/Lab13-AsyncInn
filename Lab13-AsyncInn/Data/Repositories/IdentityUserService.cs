using System;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Api;
using Microsoft.AspNetCore.Identity;

namespace Lab13_AsyncInn.Data.Repositories
{
    public class IdentityUserService : IUserService
    {
        public Task<Applicationuser> Register(RegisterData data)
        {
            throw new System.NotImplementedException(); 
        }
        //private readonly UserManager<UserDTO> usermanager;

        //public IdentityUserService(UserManager<UserDTO> userManager)
        //{
        //    this.usermanager = userManager; 
        //}

        //public  async Task<UserDTO> Register(RegisterData data)
        //{
        //    var user = new Applicationuser
        //    {
        //        UserName = data.UserName,
        //        Email = data.Email,
        //        PhoneNumber = data.PhoneNumber,
        //    };

        //    var result = await usermanager.CreateAsync(user, data.Password);
        //    if (result.Succeeded) 
        //    {
        //        return new UserDTO
        //        {
        //            Id = user.Id,
        //            UserName = user.UserName,
        //        };
        //    }

        //    return null;
        //}
        
    }

}
