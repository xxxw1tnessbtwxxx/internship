using DatabaseLayer.Database;
using DatabaseLayer.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using TimeControllerAPI.Classes;

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


        [HttpGet("GetEmployeeData")]
        public async Task<IActionResult> GetEmployeeData(string employeeId)
        {
            if (string.IsNullOrEmpty(employeeId))
            {
                return BadRequest("ID пуст.");
            }

            using (var ctx = new TimeControllerContext())
            {
                var shifts = ctx.ShiftStories.Where(x => x.EmployeeID.ToString() == employeeId
                && x.ComeDate.Month == DateTime.Now.Month && x.LeaveDate != null).Include(t => t.TradePoint).ToList();

         

                return Ok(shifts);
            }
        }

        [HttpPost("ShiftEmployeeInteract")]
        public async Task<IActionResult> ShiftEmployeeInteract([FromBody]EnterShiftRequest enterShiftRequest)
        {
            Console.WriteLine($"{enterShiftRequest.ShiftID}, {enterShiftRequest.EmployeeID}");
            if (string.IsNullOrEmpty(enterShiftRequest.ShiftID) || string.IsNullOrEmpty(enterShiftRequest.EmployeeID))
            {
                return BadRequest("Один из параметров не указан.");
            }

            using (var ctx = new TimeControllerContext())
            {

                var currentShift = ctx.ShiftStories.Where(x => x.EmployeeID.ToString() == enterShiftRequest.EmployeeID).OrderBy(x => x.ComeDate).LastOrDefault();
                if (currentShift != null)
                {
                    if (currentShift.LeaveDate == null)
                    {
                        currentShift.LeaveDate = DateTime.Now;
                        ctx.ShiftStories.Update(currentShift);
                        ctx.SaveChanges();
                        return Ok("Вы успешнно вышли со смены.");
                    }
                }

                var shift = ctx.OpenedShifts.FirstOrDefault(x => x.Id.ToString() == enterShiftRequest.ShiftID);
                if (shift == null)
                {
                    return BadRequest("Такая смена не найдена.");
                }

                try
                {
                    ctx.ShiftStories.Add(new ShiftStory
                    {
                        ComeDate = DateTime.Now,
                        EmployeeID = Guid.Parse(enterShiftRequest.EmployeeID),
                        TradePointID = Guid.Parse(enterShiftRequest.TradePointID),
                    });
                    ctx.SaveChanges();
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                
                return Ok("Вы успешно заступили на смену.");
            }
            

        }


    }
}
