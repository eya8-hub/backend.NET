
namespace TechnicalAssesments.API.Data;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TechnicalAssements.Core.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Employee> Employee { get; set; }
    public DbSet<LeaveRequest> LeaveRequest { get; set; }
}


