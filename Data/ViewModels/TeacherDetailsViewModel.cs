namespace AttendanceApi.Data.ViewModels
{
  public class TeacherDetailsViewModel : UserDetailsViewModel
  {
    public string Department { get; set; }

    public TeacherDetailsViewModel(string department, string firstName, string lastName, string username)
    {
      Department = department;
      Username = username;
      FirstName = firstName;
      LastName = lastName;
    }
  }
}