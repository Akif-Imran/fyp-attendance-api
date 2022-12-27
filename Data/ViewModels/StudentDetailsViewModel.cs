using AttendanceApi.Data.Enums;

namespace AttendanceApi.Data.ViewModels
{
  public class StudentDetailsViewModel:UserDetailsViewModel
  {
    public string Degree { get; set; }
    public string Discipline { get; set; }
    public string Section { get; set; }
    public int Semester { get; set; }
    public int ClassId { get; set; }

    public StudentDetailsViewModel(Models.Student s, string username, UserType type):base(s,username,type)
    {
      this.Semester = s.Semester;
      this.Discipline = s.Discipline;
      this.Degree = s.Degree;
      this.Section = s.Section;
      this.ClassId = s.ClassId;
    }
  }
}
