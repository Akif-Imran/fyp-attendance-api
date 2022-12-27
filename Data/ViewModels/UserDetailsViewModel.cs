using AttendanceApi.Data.Enums;

namespace AttendanceApi.Data.ViewModels
{
  public class UserDetailsViewModel
  {
    public int Id { get; set; }
    public string Username { get; set; }
    public string UserType { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public UserDetailsViewModel(){}

    public UserDetailsViewModel(Models.Teacher t, string username, UserType type)
    {
      this.Id = t.Id;
      this.Username = username;
      this.UserType = type.ToString();
      this.FirstName = t.FirstName;
      this.LastName = t.LastName;
    }

    public UserDetailsViewModel(Models.Student s, string username, UserType type)
    {
      this.Id = s.Id;
      this.Username = username;
      this.UserType = type.ToString();
      this.FirstName = s.FirstName;
      this.LastName = s.LastName;
    }
  }
}
