using AttendanceApi.Data.Models;
using AttendanceApi.Data.ViewModels.Timetable;

namespace AttendanceApi.Data.ViewModels.Teacher
{
  public class InfoWithTimetableViewModel
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Department { get; set; }
    public ICollection<ResponseTimetableViewModel> Timetables { get; set; }

    public InfoWithTimetableViewModel(Models.Teacher teacher)
    {
      this.Id = teacher.Id;
      this.FirstName = teacher.FirstName;
      this.LastName = teacher.LastName;
      this.Department = teacher.Department;
      this.Timetables = new List<ResponseTimetableViewModel>();
      foreach (var timetable in teacher.Timetables)
      {
        Timetables.Add(new ResponseTimetableViewModel(timetable));
      }
    }
  }
}
