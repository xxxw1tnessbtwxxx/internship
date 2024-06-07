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

        [HttpGet("test")]
        public ActionResult Get()
        {

            return Ok(new
            {
                work = "rabotaet"
            });

        }


        [HttpPost("signin")]
        public ActionResult SignIn(SignInRequest request) 
        {
            try
            {
                using (var ctx = new TimeControllerContext())
                {
                    try
                    {
                        var employee = ctx.Employees.Where(x => x.Login == request.Login && x.Password == request.Password).Include(e => e.TradePoint).FirstOrDefault();
                        return Ok(employee);
                    }
                    catch (Exception ex)
                    {

                        return BadRequest(ex.Message);

                    }
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

    }
}
