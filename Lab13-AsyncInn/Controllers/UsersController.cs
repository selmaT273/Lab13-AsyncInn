using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab13_AsyncInn.Data.Repositories;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Api;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab13_AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterData data) 
        {
            UserDTO user = await userService.Register(data, this.ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(new ValidationProblemDetails(ModelState));
            }

            return user;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginData data)
        {
            var user = await userService.Authenticate(data.UserName, data.Password); 

            if (user == null)
            {
                return Unauthorized();
            }

            return user;
        }
    }
}
