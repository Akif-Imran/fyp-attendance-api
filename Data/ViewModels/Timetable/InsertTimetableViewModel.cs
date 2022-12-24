using AttendanceApi.Data.Models;

namespace AttendanceApi.Data.ViewModels.Timetable
{
  public class InsertTimetableViewModel
  {
    public string Day { get; set; }//monday, tuesday, wednesday etc,
    public string Course { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string Venue { get; set; }
    public int Slot { get; set; }
    public string ClassName { get; set; }
    public int TeacherId { get; set; }

    public InsertTimetableViewModel(){}

    public InsertTimetableViewModel(Models.Timetable t)
    {
      this.Day = t.Day;
      this.Course = t.Course;
      this.StartTime = t.StartTime.ToShortTimeString();
      this.EndTime = t.EndTime.ToShortTimeString();
      this.Venue = t.Venue;
      this.TeacherId = t.TeacherId;
      this.Slot = t.Slot;
      this.ClassName = t.ClassName;
    }
  }
}
