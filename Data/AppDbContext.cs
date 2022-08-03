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


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfiguration(new ParentEntityConfiguration());
      modelBuilder.ApplyConfiguration(new StudentEntityConfiguration());
      modelBuilder.ApplyConfiguration(new TeacherEntityConfiguration());
      modelBuilder.ApplyConfiguration(new AdminEntityConfiguration());
      // modelBuilder.ApplyConfiguration<Admin>(new AdminEntityConfiguration());
      // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
  }
}