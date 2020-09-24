using System;
using Lab13_AsyncInn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Lab13_AsyncInn.Data.Repositories
{
    public class JwtTokenService
    {
        private readonly IConfiguration configuration;
        private readonly SignInManager<Applicationuser> signInManager;

        public JwtTokenService(IConfiguration configuration, SignInManager<Applicationuser> signInManager)
        {
            this.configuration = configuration;
            this.signInManager = signInManager;
        }
    }
}
