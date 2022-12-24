using System.Reflection;
using AttendanceApi.Data.EntityModelConfigurations;
using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AttendanceApi.Data
{
  public class AppDbContext : DbContext
  {
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Class> Class { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Timetable> Timetable { get; set; }


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