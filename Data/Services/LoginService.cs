using AttendanceApi.Data.Enums;
using AttendanceApi.Data.Models;
using AttendanceApi.Data.ViewModels;

namespace AttendanceApi.Data.Services
{
  public class LoginService
  {
    private readonly AppDbContext _context;

    public LoginService(AppDbContext context)
    {
      _context = context;
    }

    //TODO - maybe use switch and separate authentication logic for each user into a separate method
    public UserDetailsViewModel AuthenticateUser(LoginViewModel userLogin)
    {
      if (string.IsNullOrEmpty(userLogin.Username) || string.IsNullOrEmpty(userLogin.Password))
      {
        throw new Exception("Invalid Username or Password");
      }

      //if (userLogin.UserType == UserType.Teacher)
      //{
      //  var teacher = _context.Teachers
      //    .SingleOrDefault(t => userLogin.Username.Equals(t.Username));

      //  if (teacher is null || teacher.Password != userLogin.Password)
      //  {
      //    throw new Exception("Username or Password invalid");
      //  }

      //  return new TeacherDetailsViewModel(teacher.Department, teacher.FirstName, teacher.LastName, teacher.Username);
      //}

      //TODO - fix this empty return
      return new UserDetailsViewModel();
    }
  }
}