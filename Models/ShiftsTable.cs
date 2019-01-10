using System;

namespace ScheduleQuikWebServer.Models


{
  public class ShiftsTable
  {
    public int Id { get; set; }

    public DateTime InTime { get; set; }

    public DateTime OutTime { get; set; }

    public int EmployeesTableId { get; set; }

    public PositionsTable Positions { get; set; }

    public int PositionsTableId { get; set; }

    public EmployeesTable Employees { get; set; }


  }
}