using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Details.Business.Interfaces;
using Bank.Details.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Details.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthHelper _authHelper;

        public LoginController(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            IActionResult response = Unauthorized();
            var token = await _authHelper.AuthenticateUser(user.UserName, user.Password);

            if (!string.IsNullOrEmpty(token))
                return Ok(new { auth_token = token });

            return response;
        }
    }
}