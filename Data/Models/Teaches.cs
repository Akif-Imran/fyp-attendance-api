namespace AttendanceApi.Data.Models
{
  public class Teaches
  {
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public string CourseCode { get; set; }
    public Course Course { get; set; }
    public int ClassId { get; set; }
    public Class Class { get; set; }
    public string Session { get; set; }
  }
}