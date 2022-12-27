namespace AttendanceApi.Data.ViewModels.Timetable
{
  public class ClassSessionViewModel
  {
    public string Subject { get; set; }
    public string Class { get; set; }
    public string Venue { get; set; }
    public string Start { get; set; }
    public string Stop { get; set; }

    public int Slot { get; set; }

  }
}
