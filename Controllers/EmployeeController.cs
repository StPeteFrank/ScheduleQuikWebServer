using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleQuikWebServer.Models;

namespace ScheduleQuikWebServer.Controllers
{
  [Route("api/[controller]")]
  // localhost:5001/api/values
  [ApiController]
  public class EmployeesController : ControllerBase
  {
    //GET that returns all employees
    //GET /api/employee
    [HttpGet]

    public ActionResult<IEnumerable<EmployeesTable>> GetAction()
    {
      // query my database
      var db = new ScheduleQuikDbContext();
      var results = db.Employees.OrderBy(employee => employee.FirstName);
      // return the results
      return results.ToList();

    }
  }
}