using DatabaseLayer.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeControllerAPI.Classes;

namespace TimeControllerAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

      

        [HttpPost("signin")]
        public ActionResult SignIn(SignInRequest request) 
        {
            using (var ctx = new TimeControllerContext())
            {
                try
                {
                    var employee = ctx.Employees.Where(x => x.Login == request.Login && x.Password == request.Password).Include(e => e.Gender).Include(e => e.Access).ThenInclude(a => a.TradePoint).FirstOrDefault();
                    return Ok(employee);
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                
            }
        }

    }
}
