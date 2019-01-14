using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
      var shift = db.Shifts.OrderBy(shifts => shifts.InTime);
      // return the results
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

  }
}