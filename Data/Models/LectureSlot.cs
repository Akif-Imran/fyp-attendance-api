namespace AttendanceApi.Data.Models
{
  public class LectureSlot
  {
    public int Id { get; set; }

    //TODO - define custom conversion for these props
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    public ICollection<Lecture> Lectures { get; set; }
  }
}