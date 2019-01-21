using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleQuikWebServer.Models;


namespace ScheduleQuikWebServer.Controllers
{
  [Route("api/[controller]")]

  [ApiController]
  public class ShiftsController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<ShiftsTable>> GetAction()
    {
      // query my database
      var db = new ScheduleQuikDbContext();
      var shift = db.Shifts.Include(i => i.Positions);
      // includes positions
      return shift.ToList();
    }

    [HttpPost]
    public ActionResult<ShiftsTable> AddShifts([FromBody] ShiftsTable incomingShifts)
    {
      var db = new ScheduleQuikDbContext();
      db.Shifts.Add(incomingShifts);
      db.SaveChanges();
      return incomingShifts;
    }

    [HttpPut("{id}")]
    public ActionResult UpdateShifts([FromRoute] int id, [FromBody] ShiftsTable updateInformation)
    {
      var db = new ScheduleQuikDbContext();
      var shifts = db.Shifts.FirstOrDefault(shift => shift.Id == id);
      if (shifts != null)
      {
        shifts.InTime = updateInformation.InTime;
        shifts.OutTime = updateInformation.OutTime;
        shifts.EmployeesTableId = updateInformation.EmployeesTableId;
        shifts.PositionsTableId = updateInformation.PositionsTableId;
        db.SaveChanges();
        return Ok(shifts);
      }
      else
      {
        return NotFound(new { message = "Shift not found" });

      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Object> DeleteShifts([FromRoute]int id)
    {
      var db = new ScheduleQuikDbContext();
      var shiftsToDelete = db.Shifts.FirstOrDefault(shifts => shifts.Id == id);
      if (shiftsToDelete != null)
      {
        db.Shifts.Remove(shiftsToDelete);
        db.SaveChanges();
        return shiftsToDelete;
      }
      else
      {
        return new { message = "Shift not found" };
      }
    }

    /////////////////////////// DELETE SCHEDULE BUTTON //////////////////////// 

    [HttpDelete()]
    public ActionResult DeleteSchedule()
    {
      var db = new ScheduleQuikDbContext();

      var shifts = db.Shifts.Where(shift => true);

      db.Shifts.RemoveRange(shifts);
      db.SaveChanges();

      return Ok();
    }

    ///////////////////////////////////////////////////////////////////////////

  }
}