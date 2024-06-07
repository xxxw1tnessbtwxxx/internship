using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeControllerAPI.Classes;

namespace TimeControllerAPI.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        [HttpPost("signin")]
        public Task<IActionResult> SignIn(SignInRequest request) 
        { 
            
        }

    }
}
