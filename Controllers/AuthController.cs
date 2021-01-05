using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private IRoleService _roleService;

        public AuthController(IUserService userService,IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [HttpPost("Login")]
        [Route("Login")]
        public IActionResult Login(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return new ObjectResult(new { ok = false, message = "Username or password is incorrect" });

            return new OkObjectResult(new { ok = true, data= response });
        }

        [Authorize]
        [HttpPost("GetRoles")]
        [Route("GetRoles")]
        public IActionResult GetRoles(GetRolesRequest request)
        {
            var user = _userService.GetById(request.UserId);

            if (user == null)
                return new ObjectResult(new { ok = false, message = "User not found" });

            var roles = _roleService.GetByIds(user.Roles);

            return new OkObjectResult(new { ok = true, data = roles.ToList() });
        }

        [Authorize]
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllAdmin")]
        public IActionResult GetAllAdmin()
        {
            var users = _userService.GetAll();
            return Ok(new { users, isAdmin = true });
        }
    }
}
