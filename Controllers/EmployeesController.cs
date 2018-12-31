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
    //GET /api/employees
    [HttpGet]

    public ActionResult<IEnumerable<EmployeesTable>> GetAction()
    {
      // query my database
      var db = new ScheduleQuikDbContext();
      var employee = db.Employees.OrderBy(employees => employees.FirstName);
      // return the results
      return employee.ToList();
      //should I update this to OrderBy(employees => employees.FirstName || employees.LastName);  ?
    }
    [HttpPost]
    public ActionResult<EmployeesTable> AddEmployees([FromBody] EmployeesTable incomingEmployees)
    {
      var db = new ScheduleQuikDbContext();
      db.Employees.Add(incomingEmployees);
      db.SaveChanges();
      return incomingEmployees;
    }
  }
}