using DatabaseLayer.Database;
using DatabaseLayer.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace TimeControllerAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {

        [HttpPost("shiftInterruct")]
        public async Task<IActionResult> ShiftInterruct(TradePoint tradePoint)
        {

            using (var ctx = new TimeControllerContext())
            {
                var currentShift = ctx.OpenedShifts.Where(x => x.TradePointID == tradePoint.ID).FirstOrDefault();
                if (currentShift != null)
                {
                    ctx.OpenedShifts.Remove(currentShift);
                    await ctx.SaveChangesAsync();
                    return BadRequest("Смена успешно закрыта.");
                }

                var shift = new OpenedShift
                {
                    TradePointID = tradePoint.ID,
                    OpenedDate = DateTime.Now,
                };

                ctx.OpenedShifts.Add(shift);
                await ctx.SaveChangesAsync();
                return Ok(shift);
            }
            

        }

    }
}
