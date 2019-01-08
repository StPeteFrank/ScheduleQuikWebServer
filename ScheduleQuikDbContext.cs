using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ScheduleQuikWebServer.Models;

namespace ScheduleQuikWebServer
{
  public partial class ScheduleQuikDbContext : DbContext
  {
    public ScheduleQuikDbContext()
    {
    }

    public ScheduleQuikDbContext(DbContextOptions<ScheduleQuikDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseNpgsql("server=localhost;database=ScheduleQuikDb");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");
    }

    public DbSet<EmployeesTable> Employees { get; set; }

    public DbSet<PositionsTable> Positions { get; set; }

  }
}
