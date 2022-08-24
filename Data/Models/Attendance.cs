using System.Globalization;

namespace AttendanceApi.Data.Models
{
  public class Attendance
  {

    public string StudentId { get; set; }
    public Student Student { get; set; }
    public int LectureId { get; set; }
    public Lecture Lecture { get; set; }
    public AttendanceStatus Status { get; set; }
    public TimeOnly AttendanceTime { get; set; }
    public int AttendanceNo { get; set; }
  }

  public enum AttendanceStatus
  {
    Absent,
    Present,
    Late,
    Leave,
  }
}