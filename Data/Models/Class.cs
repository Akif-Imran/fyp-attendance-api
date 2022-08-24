namespace AttendanceApi.Data.Models
{
  public class Class
  {
    public int Id { get; set; }
    public string ClassIdentifier { get; set; }
    public ICollection<Teaches> Teaches { get; set; }
    public ICollection<Student> Students { get; set; }
  }
}