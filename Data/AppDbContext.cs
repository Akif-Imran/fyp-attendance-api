using System.Reflection;
using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AttendanceApi.Data
{
  public class AppDbContext : DbContext
  {
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
  }
}