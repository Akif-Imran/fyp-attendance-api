namespace AttendanceApi.Data.Models
{
  public class Course
  {
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
    public int CreditHours { get; set; }
    public ICollection<Teaches> Teaches { get; set; }
    public ICollection<Lecture> Lectures { get; set; }
  }
}