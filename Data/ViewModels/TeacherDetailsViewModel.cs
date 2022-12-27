using AttendanceApi.Data.Enums;

namespace AttendanceApi.Data.ViewModels
{
  public class TeacherDetailsViewModel : UserDetailsViewModel
  {
    public string Department { get; set; }

    public TeacherDetailsViewModel(Models.Teacher t, string username, UserType type) : base(t, username, type)
    {
      this.Department = t.Department;
    }
  }
}