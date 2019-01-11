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
    // DELETE /api/employees/3
    // localhost:5000/api/employees/{id}
    [HttpDelete("{id}")]
    public ActionResult<Object> DeleteEmployees([FromRoute]int id)
    {
      var db = new ScheduleQuikDbContext();
      var employeesToDelete = db.Employees.FirstOrDefault(employees => employees.Id == id);
      if (employeesToDelete != null)
      {
        db.Employees.Remove(employeesToDelete);
        db.SaveChanges();
        return employeesToDelete;
      }
      else
      {
        return new { message = "Employee not found" };
      }
    }

    [HttpDelete("firstName/{firstName}")]
    public ActionResult<Object> DeleteEmployees([FromRoute]string firstname)
    {
      var db = new ScheduleQuikDbContext();
      var employeesToDelete = db.Employees.FirstOrDefault(employees => employees.FirstName == firstname);
      if (employeesToDelete != null)
      {
        db.Employees.Remove(employeesToDelete);
        db.SaveChanges();
        return employeesToDelete;
      }
      else
      {
        return new { message = "Employee not found" };
      }
    }


    // [HttpDelete("list")]
    // public ActionResult DeleteGroupOfEmployees([FromBody]DeleteEmployeesViewModel vm)
    // {
    //   var db = new ScheduleQuikDbContext();
    //   var employeeIDsSelectedForDelete = db.Employees.Where(employee => vm.EmployeeIds.Contains(employee.Id));
    //   if (employeeIDsSelectedForDelete != null)
    //   {
    //     db.Employees.RemoveRange(employeeIDsSelectedForDelete);
    //     db.SaveChanges();
    //     return employeeIDsSelectedForDelete;
    //   }
    //   else
    //   {
    //     return Ok(vm);
    //   }
    // }
    //////////////////////////////////////////////////////////

    [HttpPut("{id}")]
    public ActionResult UpdateEmployees([FromRoute]int id, [FromBody]EmployeesTable newInformation)
    {
      var db = new ScheduleQuikDbContext();
      // find the employee
      var employees = db.Employees.FirstOrDefault(f => f.Id == id);
      if (employees != null)
      {
        //update the information
        employees.FirstName = newInformation.FirstName;
        employees.LastName = newInformation.LastName;
        employees.PhoneNumber = newInformation.PhoneNumber;
        employees.EmailAddress = newInformation.EmailAddress;

        //save changes
        db.SaveChanges();
      }
      else
      {
        //do something n not found
        return NotFound();
      }
      return Ok(employees);
      //Havent been able to get this to work
      //Also would like to add a search controller
    }
  }
}