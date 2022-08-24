namespace AttendanceApi.Data.Models
{
  public class Lecture
  {
    public int Id { get; set; }
    public string Session { get; set; }

    public string Venue { get; set; }

    //TODO - build a custom converter for DateOnly from DateTime using HasConversion();
    public DateOnly HeldOnDate { get; set; }

    //Lecture has LectureSlot
    public int LectureSlotId { get; set; }

    //Navigation Property
    public LectureSlot LectureSlot { get; set; }

    //Teacher Conducts Lecture
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    //Course has Lecture
    public string CourseCode { get; set; }
    public Course Course { get; set; }

    public ICollection<ClassLecturePhotos> ClassLecturePhotos { get; set; }
    public ICollection<Student> Students { get; set; }
    public ICollection<Attendance> Attendances { get; set; } 
  }
}