namespace AttendanceApi.Data.Models
{
  public class ClassLecturePhotos
  {
    public int Id { get; set; }
    public string Path { get; set; }
    public int LectureId { get; set; }
    public Lecture Lecture { get; set; }
  }
}