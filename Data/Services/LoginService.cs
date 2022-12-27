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
        throw new Exception("Username or Password can not be empty");
      }

      var result = _context.User
        .Where(u => u.Username == userLogin.Username && u.Password == userLogin.Password)
        .AsEnumerable()
        .First();

      switch (result.UserType)
      {
        case UserType.Teacher:
        {
          var teacher = _context.Teachers.Single(t => t.Id == result.SpecificUserId);
          return new TeacherDetailsViewModel(teacher, result.Username, result.UserType);
        }
        case UserType.Student:
        {
          var student = _context.Students.Single(t => t.Id == result.SpecificUserId);
          return new StudentDetailsViewModel(student, result.Username, result.UserType);
        }
        case UserType.Admin:
        {
          return new UserDetailsViewModel();
        }
        case UserType.Parent:
        {
          return new UserDetailsViewModel();
        }
        default:
          //TODO - fix this empty return
          return new UserDetailsViewModel();
      }
    }
  }
}