using AttendanceApi.Data;
using AttendanceApi.Data.Services;
using AttendanceApi.Exceptions;
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
      //CORS Policy
      /*var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

      builder.Services.AddCors(options =>
      {
        options.AddPolicy(name: MyAllowSpecificOrigins,
          policy =>
          {
            policy.WithOrigins("https://localhost:7049", "https://127.0.0.1:7049", "https://192.168.100.12:7049");
          });
      });*/

      //Configure my services
      builder.Services.AddTransient<StudentService>();
      builder.Services.AddTransient<LoginService>();
      builder.Services.AddTransient<AdminService>();
      builder.Services.AddTransient<UserService>();
      builder.Services.AddTransient<TimetableService>();
      builder.Services.AddTransient<TeacherService>();
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

      app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin());

      app.UseStaticFiles();

      app.UseAuthorization();

      app.ConfigureBuiltinExceptionHandler();

      app.MapControllers();

      app.Run();
    }
  }
}