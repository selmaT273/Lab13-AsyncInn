using System;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Api;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lab13_AsyncInn.Data.Repositories
{
    public interface IUserService
    {
        Task<UserDTO> Register(RegisterData data, ModelStateDictionary modelState);

        Task<UserDTO> Authenticate(string username, string password);
    }
}
