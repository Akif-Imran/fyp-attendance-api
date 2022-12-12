using AttendanceApi.Data.Enums;

namespace AttendanceApi.Data.ViewModels
{
  public class LoginViewModel
  {
    public string? Username { get; set; }
    public string? Password { get; set; }
    public UserType UserType { get; set; }

    public LoginViewModel(string? username, string? password, UserType userType)
    {
      Username = username;
      Password = password;
      UserType = userType;
    }

    public LoginViewModel()
    {
    }
  }
}