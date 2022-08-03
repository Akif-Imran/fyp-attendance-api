using AttendanceApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AttendanceApi
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);
      var configuration = builder.Configuration;
      var connectionString = configuration.GetConnectionString("defaultConnectionString");

      // Add services to the container.

      builder.Services.AddControllers();

      //Configure DbContext with SQL
      builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

      //Configure my services
      // builder.Services.AddTransient<UserService>();

      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
    }
  }
}