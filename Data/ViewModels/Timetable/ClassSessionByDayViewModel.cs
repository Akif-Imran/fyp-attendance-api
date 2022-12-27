namespace AttendanceApi.Data.ViewModels.Timetable
{
  public class ClassSessionByDayViewModel
  {
    public string Day { get; set; }
    public int WeekDay { get; set; }
    public IList<ClassSessionViewModel> Sessions { get; set; }


  }
}
