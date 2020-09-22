using System;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Api;

namespace Lab13_AsyncInn.Data.Repositories
{
    public interface IUserService
    {
        Task<Applicationuser> Register(RegisterData data);
    }
}
