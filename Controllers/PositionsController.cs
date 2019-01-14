using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleQuikWebServer.Models;
using ScheduleQuikWebServer.ViewModels;

namespace ScheduleQuikWebServer.Controllers
{
  [Route("api/[controller]")]
  // localhost:5001/api/values
  [ApiController]
  public class PositionsController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<PositionsTable>> GetAction()
    {
      // query my database
      var db = new ScheduleQuikDbContext();
      var position = db.Positions.OrderBy(positions => positions.PositionName);
      // return the results
      return position.ToList();
    }
    [HttpPost]
    public ActionResult<PositionsTable> AddPositions([FromBody] PositionsTable incomingPositions)
    {
      var db = new ScheduleQuikDbContext();
      db.Positions.Add(incomingPositions);
      db.SaveChanges();
      return incomingPositions;
    }
    // localhost:5000/api/employees/{id}
    [HttpDelete("{id}")]
    public ActionResult<Object> PositionsEmployees([FromRoute]int id)
    {
      var db = new ScheduleQuikDbContext();
      var positionsToDelete = db.Positions.FirstOrDefault(positions => positions.Id == id);
      if (positionsToDelete != null)
      {
        db.Positions.Remove(positionsToDelete);
        db.SaveChanges();
        return positionsToDelete;
      }
      else
      {
        return new { message = "Position not found" };
      }
    }

    [HttpDelete("list")]
    public ActionResult DeleteGroupOfPositions([FromBody]DeletePositionsViewModel vm)
    {
      var db = new ScheduleQuikDbContext();
      var positionIDsSelectedForDelete = db.Positions.Where(position => vm.PositionIds.Contains(position.Id));
      if (positionIDsSelectedForDelete != null)
      {
        db.Positions.RemoveRange(positionIDsSelectedForDelete);
        db.SaveChanges();
        return Ok();
      }
      else
      {
        return Ok(vm);
      }
    }




    [HttpPut("{id}")]
    public ActionResult UpdatePositions([FromRoute]int id, [FromBody]PositionsTable newInformation)
    {
      var db = new ScheduleQuikDbContext();
      // find the position
      var positions = db.Positions.FirstOrDefault(f => f.Id == id);
      if (positions != null)
      {
        positions.PositionName = newInformation.PositionName;
        db.SaveChanges();
      }
      else
      {
        return NotFound();
      }
      return Ok(positions);

    }
  }
}