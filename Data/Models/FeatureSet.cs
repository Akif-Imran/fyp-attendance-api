namespace AttendanceApi.Data.Models
{
  public class FeatureSet
  {
    public int Id { get; set; }
    public string Path { get; set; }
    public Pose Pose { get; set; }

    public string StudentId { get; set; }
    public Student Student { get; set; }
  }
}