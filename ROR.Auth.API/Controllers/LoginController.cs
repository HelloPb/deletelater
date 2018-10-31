using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ROR.Auth.Interfaces;
using ROR.DataAccess.Mongo;

namespace ROR.Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private IAuthRepo _authRepo;
        private ITokenRepo _tokenRepo;

        public LoginController(IConfiguration config, IAuthRepo authRepo, ITokenRepo tokenRepo)
        {
            _config = config;
            _authRepo = authRepo;
            _tokenRepo = tokenRepo;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody]UserDto login)
        {
            IActionResult response = Unauthorized();

            var user = _authRepo.Authenticate(login);

            if (user != null)
            {
                var tokenString = _tokenRepo.createToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
    }
}
