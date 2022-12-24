using AttendanceApi.Data.ViewModels.Timetable;

namespace AttendanceApi.Data.Models
{
  public class Timetable
  {
    public int Id { get; set; }
    public string Day { get; set; }//monday, tuesday, wednesday etc,
    public string Course { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Venue { get; set; }
    public int Slot { get; set; }
    public string ClassName { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    // public int ClassId { get; set; }
    // public Class Class { get; set; }

    public Timetable(){}

    public Timetable(InsertTimetableViewModel tb)
    {
      this.Day = tb.Day;
      this.Course = tb.Course;
      this.StartTime = TimeOnly.Parse(tb.StartTime);
      this.EndTime = TimeOnly.Parse(tb.EndTime);
      this.Venue = tb.Venue;
      this.TeacherId = tb.TeacherId;
      // this.ClassId = tb.ClassId;
      this.Slot = tb.Slot;
    }
  }
}
